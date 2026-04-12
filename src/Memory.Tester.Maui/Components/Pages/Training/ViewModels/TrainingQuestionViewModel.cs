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
}
