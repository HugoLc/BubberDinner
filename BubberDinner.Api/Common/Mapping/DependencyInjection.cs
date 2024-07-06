
using System.Reflection;
using Mapster;
using MapsterMapper;

namespace BubberDinner.Api.Common.Mapping;
public static class DependencyInjection
{
    //Será chamado na depencendy injection da presentation que por sua vez é chamada na program.cs
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }
}
