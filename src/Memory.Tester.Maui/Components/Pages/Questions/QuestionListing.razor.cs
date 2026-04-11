namespace Memory.Tester.Maui.Components.Pages.Questions;

using Memory.Tester.Maui.Components.Dialogs.Questions;
using Memory.Tester.Maui.Components.Pages.Questions.ViewModels;
using Memory.Tester.Web.Service.Services.Interfaces;

using Microsoft.FluentUI.AspNetCore.Components;

/// <summary>
/// Code-behind of the <see cref="QuestionListing"/> component.
/// </summary>
public partial class QuestionListing
{
    private readonly IQuestionsService _questionsService;
    private readonly IDialogService _dialogService;
    private readonly IToastService _toastService;

    private readonly PaginationState pagination = new() { ItemsPerPage = 10 };

    private GridItemsProvider<QuestionViewModel> itemsProvider = static (req) => new ValueTask<GridItemsProviderResult<QuestionViewModel>>(new GridItemsProviderResult<QuestionViewModel>());

    private FluentDataGrid<QuestionViewModel>? _questionsDataGrid;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestionListing"/> class.
    /// </summary>
    /// <param name="questionsService">The questions service.</param>
    /// <param name="dialogService">The dialog service.</param>
    /// <param name="toastService">The toest service.</param>
    public QuestionListing(IQuestionsService questionsService, IDialogService dialogService, IToastService toastService)
    {
        this._questionsService = questionsService;
        this._dialogService = dialogService;
        this._toastService = toastService;
    }

    protected override Task OnInitializedAsync()
    {
        this.itemsProvider = this.LoadQuestions;

        return base.OnInitializedAsync();
    }

    private async ValueTask<GridItemsProviderResult<QuestionViewModel>> LoadQuestions(GridItemsProviderRequest<QuestionViewModel> req)
    {
        var result = await this._questionsService.SearchQuestionsAsync(new() { IsPaginated = req.Count.HasValue, StartIndex = req.StartIndex, PageSize = req.Count.HasValue ? req.Count.Value : 10 }).ConfigureAwait(true);
        if (!result.IsSuccess)
        {
            this._toastService.ShowToast(ToastIntent.Error, $"Erreur lors de la récupération des questions: {result.ErrorMessage}");
            return new GridItemsProviderResult<QuestionViewModel>();
        }

        return new GridItemsProviderResult<QuestionViewModel>()
        {
            Items = [.. result.Result?.Items.Select(q => new QuestionViewModel()
            {
                Id = q.Id,
                Title = q.Title,
                Answer = q.Answer,
            }) ?? []],
            TotalItemCount = result.Result?.TotalCount ?? 0,
        };
    }

    private async Task EditQuestionAsync(QuestionViewModel question)
    {
        var dialogReference = await this._dialogService.ShowDialogAsync<QuestionEditionDialog>(
            question,
            new()
            {
                Height = "400",
                PreventDismissOnOverlayClick = true,
                PreventScroll = true,
            }).ConfigureAwait(true);

        if (!(await dialogReference.Result).Cancelled && this._questionsDataGrid is not null)
            await this._questionsDataGrid.RefreshDataAsync().ConfigureAwait(true);
    }

    private async Task DeleteQuestionAsync(QuestionViewModel question)
    {
        var dialogReference = await this._dialogService.ShowDialogAsync<QuestionDeletionDialog>(
            question,
            new()
            {
                Height = "400",
                PreventDismissOnOverlayClick = true,
                PreventScroll = true,
            }).ConfigureAwait(true);

        if (!(await dialogReference.Result).Cancelled && this._questionsDataGrid is not null)
            await this._questionsDataGrid.RefreshDataAsync().ConfigureAwait(true);
    }

    private async Task ReloadQuestionsAsync()
    {
        if (this._questionsDataGrid is not null)
            await this._questionsDataGrid.RefreshDataAsync().ConfigureAwait(true);
    }
}
