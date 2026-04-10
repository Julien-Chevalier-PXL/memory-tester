namespace Memory.Tester.Core.Data.Entities;

using Memory.Tester.Core.Data.Entities.Abstractions;

/// <summary>
/// Class representing a question.
/// </summary>
public sealed class Question : AEntity
{
    /// <summary>
    /// Gets or sets the title of the question.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the answer of the question.
    /// </summary>
    public string Answer { get; set; } = string.Empty;
}
