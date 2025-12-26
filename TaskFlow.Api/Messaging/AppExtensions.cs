using MassTransit;

namespace TaskFlow.Api.Messaging
{
    public static class AppExtensions
    {
        public static void AddRabbitMQService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(new Uri(configuration["RabbitMQ:Host"] + ":" + configuration["RabbitMQ:Port"]), host =>
                    {
                        host.Username(configuration["RabbitMQ:Username"]);
                        host.Password(configuration["RabbitMQ:Password"]);
                    });

                    cfg.ConfigureEndpoints(ctx);
                });
            });
        }
    }
}
