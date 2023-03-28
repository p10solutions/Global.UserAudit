using Global.UserAudit.Infra.IoC;
using GlobalTask.UserAudit.Worker.Consumers;
using MassTransit;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        IConfiguration configuration = context.Configuration;
        services.AddProviders(configuration);
        services.AddMassTransit(x =>
        {
            x.AddDelayedMessageScheduler();
            x.AddConsumer<UserInsertedConsumer>(typeof(QueueClientConsumerDefinition));
            x.AddConsumer<UserUpdatedConsumer>(typeof(QueueClientUpdatedConsumerDefinition));

            x.SetKebabCaseEndpointNameFormatter();

            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(configuration.GetConnectionString("RabbitMq"));
                cfg.UseDelayedMessageScheduler();
                cfg.ServiceInstance(instance =>
                {
                    instance.ConfigureJobServiceEndpoints();
                    instance.ConfigureEndpoints(ctx, new KebabCaseEndpointNameFormatter("dev", false));
                });
            });
        });
    })
    .Build();

await host.RunAsync();
