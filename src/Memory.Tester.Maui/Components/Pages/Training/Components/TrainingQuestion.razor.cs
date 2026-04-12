namespace Memory.Tester.Maui.Components.Pages.Training.Components;

using Memory.Tester.Maui.Components.Pages.Training.ViewModels;

using Microsoft.AspNetCore.Components;

/// <summary>
/// Code-behind for the <see cref="TrainingQuestion"/> component.
/// </summary>
public partial class TrainingQuestion
{
    private string answer = string.Empty;
    private bool? isAnswerCorrect = null;
    private bool isAnswerShown = false;

    [Parameter]
    public TrainingQuestionViewModel Question { get; set; } = new();

    public bool IsQuestionEnded
        => this.isAnswerShown
            || (this.isAnswerCorrect.HasValue && this.isAnswerCorrect.Value);

    public void Reset()
    {
        this.answer = string.Empty;
        this.isAnswerCorrect = null;
        this.isAnswerShown = false;
    }

    private void ValidateAnswer()
    {
        this.isAnswerCorrect = string.Equals(this.answer, this.Question.Answer, StringComparison.OrdinalIgnoreCase);
    }

    private void Surrender()
    {
        this.isAnswerCorrect = false;
        this.isAnswerShown = true;
    }
}
