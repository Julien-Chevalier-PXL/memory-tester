namespace Memory.Tester.Maui.Components.Pages.Training.ViewModels;

using System;

/// <summary>
/// Record which represents the training question view model.
/// </summary>
public sealed record TrainingQuestionViewModel
{
    /// <summary>
    /// Gets the id.
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
    /// Gets a value indicating whether the title of the question is shown. If false, the answer is shown and the user
    /// must provide the title.
    /// </summary>
    public bool IsTitleShown { get; init; }

    /// <summary>
    /// Gets the text to display, which is either the title or the answer of the question depending on the value of
    /// <see cref="IsTitleShown"/>.
    /// </summary>
    public string DisplayedText => this.IsTitleShown ? this.Title : this.Answer;

    /// <summary>
    /// Gets the expected answer, which is either the title or the answer of the question depending on the value of
    /// <see cref="IsTitleShown"/>.
    /// </summary>
    public string ExpectedAnswer => this.IsTitleShown ? this.Answer : this.Title;
}
