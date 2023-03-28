using System.Diagnostics;
using Global.UserAudit.Application.Models.Events.Users;
using Global.UserAudit.Application.Models.Events.Users.Maps;
using MassTransit;
using MassTransit.Metadata;
using MediatR;

namespace GlobalTask.UserAudit.Worker.Consumers;

public class UserInsertedConsumer : IConsumer<UserInsertedEvent>
{
    readonly ILogger<UserInsertedConsumer> _logger;
    readonly IMediator _mediator;

    public UserInsertedConsumer(ILogger<UserInsertedConsumer> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<UserInsertedEvent> context)
    {
        var timer = Stopwatch.StartNew();

        try
        {
            var message = context.Message;

            if (message == null)
                return;

            _logger.LogInformation("A new user has been received Id:{UserId}", message.Id);
            await _mediator.Send(UserInsertedMapper.MapTo(message));

            await context.NotifyConsumed(timer.Elapsed, TypeMetadataCache<UserInsertedEvent>.ShortName);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error ocurred when try to receive the new user: {exception}", ex.Message);
            await context.NotifyFaulted(timer.Elapsed, TypeMetadataCache<UserInsertedEvent>.ShortName, ex);
        }
    }
}

public class QueueClientConsumerDefinition : ConsumerDefinition<UserInsertedConsumer>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<UserInsertedConsumer> consumerConfigurator)
    {
        consumerConfigurator.UseMessageRetry(retry => retry.Interval(3, TimeSpan.FromSeconds(3)));
    }
}