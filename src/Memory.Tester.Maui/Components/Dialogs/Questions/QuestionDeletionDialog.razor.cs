namespace Memory.Tester.Maui.Components.Dialogs.Questions;

using Memory.Tester.Maui.Components.Pages.Questions.ViewModels;
using Memory.Tester.Web.Service.Services.Interfaces;

using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

/// <summary>
/// Code-behind of the <see cref="QuestionDeletionDialog"/> component.
/// </summary>
public partial class QuestionDeletionDialog : IDialogContentComponent<QuestionViewModel>
{
    private readonly IQuestionsService _questionsService;
    private readonly IToastService _toastService;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestionDeletionDialog"/> class.
    /// </summary>
    /// <param name="questionsService">The question service.</param>
    /// <param name="toastService">The toast service.</param>
    public QuestionDeletionDialog(IQuestionsService questionsService, IToastService toastService)
    {
        this._questionsService = questionsService;
        this._toastService = toastService;
    }

    /// <summary>
    /// Gets or sets the <see cref="FluentDialog"/> instance.
    /// </summary>
    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    [Parameter]
    /// <inheritdoc />
    public QuestionViewModel Content { get; set; } = new();

    private async Task DeleteAsync()
    {
        var serviceResult = await this._questionsService.DeleteQuestionAsync(this.Content.Id).ConfigureAwait(true);

        if (!serviceResult.IsSuccess)
        {
            this._toastService.ShowToast(ToastIntent.Error, $"Erreur lors de la suppression de la question: {serviceResult.ErrorMessage}");
        }
        else
        {
            this._toastService.ShowToast(ToastIntent.Success, $"Question supprimé");
            await this.Dialog.CloseAsync(this.Content);
        }
    }

    private async Task CancelAsync()
    {
        await this.Dialog.CancelAsync();
    }
}
