namespace Memory.Tester.Core.Data;

using Memory.Tester.Core.Data.AccessLayers.Implementations;
using Memory.Tester.Core.Data.AccessLayers.Interfaces;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

/// <summary>
/// Class providing extensions methods to register dependencies and configure services.
/// </summary>
public static class ServicesExtensions
{
    /// <summary>
    /// Adds data access layer services to the specified service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The same instance of <see cref="IServiceCollection"/> that was provided, to support method chaining.</returns>
    public static IServiceCollection AddDataServices(this IServiceCollection services) 
        => services.AddAccessLayers();

    private static IServiceCollection AddAccessLayers(this IServiceCollection services)
    {
        services.TryAddTransient<IQuestionAccessLayer, QuestionAccessLayer>();

        return services;
    }
}
