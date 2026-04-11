namespace Memory.Tester.Web.Service.Services.Questions.Responses;

using Memory.Tester.Core.Business.Business.ViewModels;

/// <summary>
/// Record representing the view model for a question.
/// </summary>
public record QuestionView
{
    /// <summary>
    /// Gets the unique identifier for the entity.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the title of the question.
    /// </summary>
    public string Title { get; init; } = string.Empty;

    /// <summary>
    /// Gets the answer of the question.
    /// </summary>
    public string Answer { get; init; } = string.Empty;

    /// <summary>
    /// Method to create a <see cref="QuestionView"/> from a <see cref="QuestionViewModel">.
    /// </summary>
    /// <param name="model">The view model to convert.</param>
    /// <returns>The converted view.</returns>
    public static QuestionView FromModel(QuestionViewModel model) =>
        new()
        {
            Id = model.Id,
            Title = model.Title,
            Answer = model.Answer
        };
}
