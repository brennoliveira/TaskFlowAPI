using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Infrastructure.Messaging.Config
{
    public static class MessagingConfig
    {
        public static IServiceCollection AddMessaging(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();

                busConfigurator.AddConsumers(typeof(MessagingConfig).Assembly);

                busConfigurator.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(
                        configuration["RabbitMQ:Host"],
                        h =>
                        {
                            h.Username(configuration["RabbitMQ:Username"]);
                            h.Password(configuration["RabbitMQ:Password"]);
                        }
                    );
                    cfg.ConfigureEndpoints(context);
                });
            });
            return services;
        }
    }
}
