namespace Memory.Tester.Web.Service.Services.Questions.Requests;

using Memory.Tester.Core.Business.Business.Models;

/// <summary>
/// Abstract record which defines the common properties for question edition models.
/// </summary>
public abstract record AQuestionEditionRequest
{
    /// <summary>
    /// Gets the new title of the question.
    /// </summary>
    public string Title { get; init; } = string.Empty;

    /// <summary>
    /// Gets the new answer of the question.
    /// </summary>
    public string Answer { get; init; } = string.Empty;

    /// <summary>
    /// Method to convert the request into the business model.
    /// </summary>
    /// <returns>The business model representing the request.</returns>
    public abstract AQuestionEditionModel ToModel();
}
