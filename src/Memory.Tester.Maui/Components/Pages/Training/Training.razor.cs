namespace Memory.Tester.Maui.Components.Pages.Training;

using Memory.Tester.Maui.Components.Pages.Questions.ViewModels;
using Memory.Tester.Maui.Components.Pages.Training.Components;
using Memory.Tester.Maui.Components.Pages.Training.ViewModels;
using Memory.Tester.Web.Service.Services.Interfaces;

using Microsoft.FluentUI.AspNetCore.Components;

/// <summary>
/// Code-behind for the <see cref="Training"/> component.
/// </summary>
public partial class Training
{
    private readonly IQuestionsService _questionsService;
    private readonly IToastService _toastService;

    private TrainingQuestion? trainingQuestion;

    private Queue<QuestionViewModel> _questions = [];
    private TrainingQuestionViewModel? _currentTrainingQuestion = null;

    private bool isLoading = false;
    private bool isTrainingStarted = false;

    /// <summary>
    /// Initializes a new instance of the <see cref="Training"/> class.
    /// </summary>
    /// <param name="questionsService">The questions service.</param>
    /// <param name="toastService">The toast service.</param>
    public Training(IQuestionsService questionsService, IToastService toastService)
    {
        this._questionsService = questionsService;
        this._toastService = toastService;
    }

    private async Task LoadQuestions()
    {
        this.isLoading = true;

        var result = await this._questionsService.SearchQuestionsAsync(new() { IsPaginated = false }).ConfigureAwait(true);
        if (result.IsSuccess && result.Result is not null)
        {
            this._questions = new([..result.Result.Items.Select(q => new QuestionViewModel()
            {
                Id = q.Id,
                Title = q.Title,
                Answer = q.Answer,
            }).Shuffle()]);
        }
        else
        {
            this._toastService.ShowToast(ToastIntent.Error, $"Erreur lors de la récupération des questions: {result.ErrorMessage}");
        }

        this.isLoading = false;
    }

    private async Task StartTraining()
    {
        await this.LoadQuestions().ConfigureAwait(true);
        this.NextQuestion();
        this.isTrainingStarted = true;
    }

    private void NextQuestion()
    {
        if (this.trainingQuestion is not null)
            this.trainingQuestion.Reset();

        if (this._questions.Count > 0)
        {
            var currentQuestion = this._questions.Dequeue();
            this._currentTrainingQuestion = new()
            {
                Id = currentQuestion.Id,
                Title = currentQuestion.Title,
                Answer = currentQuestion.Answer,
                IsTitleShown = Random.Shared.Next(2) == 0, // Randomly decide to show the title or not
            };
        }
    }

    private void Restart()
    {
        this.isTrainingStarted = false;
        this._questions = [];
        this._currentTrainingQuestion = null;
    }
}
