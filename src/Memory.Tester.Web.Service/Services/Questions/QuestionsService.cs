namespace Memory.Tester.Web.Service.Services.Questions;

using Memory.Tester.Common.Pagination;
using Memory.Tester.Core.Business.Business.Interfaces;
using Memory.Tester.Web.Service.Dtos;
using Memory.Tester.Web.Service.Services.Interfaces;
using Memory.Tester.Web.Service.Services.Questions.Requests;
using Memory.Tester.Web.Service.Services.Questions.Responses;

/// <summary>
/// Implementation of the <see cref="IQuestionsService"/> interface.
/// </summary>
internal sealed class QuestionsService : IQuestionsService
{
    private readonly IQuestionBusiness _questionBusiness;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestionsService"/> class.
    /// </summary>
    /// <param name="questionBusiness">The question business.</param>
    public QuestionsService(IQuestionBusiness questionBusiness)
    {
        this._questionBusiness = questionBusiness;
    }

    /// <inheritdoc />
    public ServiceResult<PageResult<QuestionView>> SearchQuestions(PageableQuery pageableQuery)
    {
        var businessResult = this._questionBusiness.SearchQuestions(pageableQuery);
        return new ServiceResult<PageResult<QuestionView>> { IsSuccess = businessResult.IsSuccess, Result = businessResult.Result?.SelectItems(QuestionView.FromModel), ErrorMessage = businessResult.ErrorMessage };
    }

    /// <inheritdoc />
    public ServiceResult<Guid> CreateQuestion(QuestionCreationRequest questionCreationModel)
    {
        var businessResult = this._questionBusiness.CreateQuestion(questionCreationModel.ToModel());
        return new ServiceResult<Guid> { IsSuccess = businessResult.IsSuccess, Result = businessResult.Result, ErrorMessage = businessResult.ErrorMessage };
    }

    /// <inheritdoc />
    public ServiceResult UpdateQuestion(Guid id, QuestionUpdateRequest updateQuestionModel)
    {
        var businessResult = this._questionBusiness.UpdateQuestion(id, updateQuestionModel.ToModel());
        return new ServiceResult { IsSuccess = businessResult.IsSuccess, ErrorMessage = businessResult.ErrorMessage };
    }

    /// <inheritdoc />
    public ServiceResult DeleteQuestion(Guid id)
    {
        var businessResult = this._questionBusiness.DeleteQuestion(id);
        return new ServiceResult { IsSuccess = businessResult.IsSuccess, ErrorMessage = businessResult.ErrorMessage };
    }
}
