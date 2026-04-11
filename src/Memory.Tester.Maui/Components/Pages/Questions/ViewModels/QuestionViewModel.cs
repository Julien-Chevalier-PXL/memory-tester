namespace Memory.Tester.Maui.Components.Pages.Questions.ViewModels;

/// <summary>
/// Class which represents the question view model.
/// </summary>
public sealed class QuestionViewModel
{
    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the question.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the answer of the question.
    /// </summary>
    public string Answer { get; set; } = string.Empty;
}
