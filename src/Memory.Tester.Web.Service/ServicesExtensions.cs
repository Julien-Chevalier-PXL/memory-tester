namespace Memory.Tester.Web.Service;

using Memory.Tester.Core.Business;
using Memory.Tester.Web.Service.Services.Interfaces;
using Memory.Tester.Web.Service.Services.Questions;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Class providing extensions methods to register dependencies and configure services.
/// </summary>
public static class ServicesExtensions
{
    /// <summary>
    /// Adds web services to the specified service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>
    /// The same instance of <see cref="IServiceCollection"/> that was provided, to support method chaining.
    /// </returns>
    public static IServiceCollection AddWebServices(this IServiceCollection services)
        => services.AddBusinessServices()
                   .AddServices();

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IQuestionsService, QuestionsService>();

        return services;
    }
}
