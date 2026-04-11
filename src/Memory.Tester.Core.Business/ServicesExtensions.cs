namespace Memory.Tester.Core.Business;

using Memory.Tester.Core.Business.Business;
using Memory.Tester.Core.Business.Business.Interfaces;
using Memory.Tester.Core.Data;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

/// <summary>
/// Class providing extensions methods to register dependencies and configure services.
/// </summary>
public static class ServicesExtensions
{
    /// <summary>
    /// Adds business services to the specified service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The same instance of <see cref="IServiceCollection"/> that was provided, to support method chaining.</returns>
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        => services.AddDataServices()
                   .AddBusinesses();

    private static IServiceCollection AddBusinesses(this IServiceCollection services)
    {
        services.TryAddTransient<IQuestionBusiness, QuestionBusiness>();

        return services;
    }
}
