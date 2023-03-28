using Global.UserAudit.Application.Entities;
using Global.UserAudit.Application.Models.Events.Users;
using Global.UserAudit.Application.Models.Events.Users.Maps;
using MassTransit;
using MassTransit.Metadata;
using MediatR;
using System.Diagnostics;

namespace GlobalTask.UserAudit.Worker.Consumers;

public class UserUpdatedConsumer : IConsumer<UserUpdatedEvent>
{
    private readonly ILogger<UserUpdatedConsumer> _logger;
    readonly IMediator _mediator;

    public UserUpdatedConsumer(ILogger<UserUpdatedConsumer> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<UserUpdatedEvent> context)
    {
        var timer = Stopwatch.StartNew();

        try
        {
            var message = context.Message;

            if (message == null)
                return;

            _logger.LogInformation("A new user has been changed Id:{UserId}", message.Id);

            var changeType = message.Active ? EChangeType.Update : EChangeType.Delete;

            await _mediator.Send(UserUpdatedMapper.MapTo(message, changeType));

            await context.NotifyConsumed(timer.Elapsed, TypeMetadataCache<UserInsertedEvent>.ShortName);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error:", ex.Message);
            await context.NotifyFaulted(timer.Elapsed, TypeMetadataCache<UserInsertedEvent>.ShortName, ex);
        }
    }
}

public class QueueClientUpdatedConsumerDefinition : ConsumerDefinition<UserUpdatedConsumer>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<UserUpdatedConsumer> consumerConfigurator)
    {
        consumerConfigurator.UseMessageRetry(retry => retry.Interval(3, TimeSpan.FromSeconds(3)));
    }
}