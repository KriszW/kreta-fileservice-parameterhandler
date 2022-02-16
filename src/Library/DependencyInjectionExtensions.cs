using Kreta.FileService.ParameterHandler.Library.Abstractions;
using Kreta.FileService.ParameterHandler.Library.Handlers;
using Kreta.FileService.ParameterHandler.Library.Handlers.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.FileService.ParameterHandler.Library
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddQueryParameterHandlers(this IServiceCollection services)
        {
            return services.AddQueryParameterHandlers<HandlerService>(typeof(DependencyInjectionExtensions).Assembly);
        }

        public static IServiceCollection AddQueryParameterHandlers(this IServiceCollection services, params Assembly[] assemblies)
        {
            return services.AddQueryParameterHandlers<HandlerService>(assemblies);
        }

        public static IServiceCollection AddQueryParameterHandlers<IHandlerServiceImplementation>(this IServiceCollection services, params Assembly[] assemblies)
            where IHandlerServiceImplementation : class, IHandlerService
        {
            foreach (var assembly in assemblies)
            {
                var commands = assembly.GetTypes()
                    .Where(x => !x.IsAbstract
                    && x.IsClass
                    && x.GetInterface(nameof(IParameterHandlerCommandBase)) == typeof(IParameterHandlerCommandBase));

                foreach (var command in commands)
                {
                    services.Add(new ServiceDescriptor(typeof(IParameterHandlerCommandBase), command, ServiceLifetime.Singleton));
                }
            }

            return services.AddSingleton<IHandlerRepository, HandlerRepository>()
                           .AddSingleton<IHandlerService, IHandlerServiceImplementation>();
        }
    }
}
