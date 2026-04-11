namespace Memory.Tester.Core.Business.Business;

using Memory.Tester.Common.Pagination;
using Memory.Tester.Core.Business.Business.Interfaces;
using Memory.Tester.Core.Business.Business.Models;
using Memory.Tester.Core.Business.Business.ViewModels;
using Memory.Tester.Core.Business.Dtos;
using Memory.Tester.Core.Data.AccessLayers.Interfaces;
using Memory.Tester.Core.Data.Entities;

/// <summary>
/// Class implementing the business logic related to questions.
/// </summary>
internal sealed class QuestionBusiness : IQuestionBusiness
{
    private readonly IQuestionAccessLayer _questionAccessLayer;

    /// <summary>
    /// Initialize a new instance of the class <see cref="QuestionBusiness"/>.
    /// </summary>
    /// <param name="questionAccessLayer">The question access layer.</param>
    public QuestionBusiness(IQuestionAccessLayer questionAccessLayer)
    {
        this._questionAccessLayer = questionAccessLayer;
    }

    /// <inheritdoc />
    public BusinessResult<PageResult<QuestionViewModel>> SearchQuestions(PageableQuery pageableQuery)
    {
        try
        {
            var questionsPage = this._questionAccessLayer.GetCollectionPage(
                pageableQuery,
                q => new QuestionViewModel
                {
                    Id = q.Id,
                    Title = q.Title,
                    Answer = q.Answer,
                });
            return BusinessResult<PageResult<QuestionViewModel>>.Success(questionsPage);
        }
        catch (Exception ex)
        {
            return BusinessResult<PageResult<QuestionViewModel>>.Error(ex.Message);
        }
    }

    /// <inheritdoc />
    public BusinessResult<Guid> CreateQuestion(QuestionCreationModel questionCreationModel)
    {
        try
        {
            var questionToCreate = new Question
            {
                Title = questionCreationModel.Title,
                Answer = questionCreationModel.Answer
            };
            this._questionAccessLayer.Add(questionToCreate);
            return BusinessResult<Guid>.Success(questionToCreate.Id);
        }
        catch (Exception ex)
        {
            return BusinessResult<Guid>.Error(ex.Message);
        }
    }

    /// <inheritdoc />
    public BusinessResult UpdateQuestion(Guid id, QuestionUpdateModel updateQuestionModel)
    {
        try
        {
            var questionToDelete = this._questionAccessLayer.GetById(id);
            if (questionToDelete is null)
                return BusinessResult.Error("Question not found");

            questionToDelete.Title = updateQuestionModel.Title;
            questionToDelete.Answer = updateQuestionModel.Answer;

            this._questionAccessLayer.Update(questionToDelete);

            return BusinessResult.Success();
        }
        catch (Exception ex)
        {
            return BusinessResult.Error(ex.Message);
        }
    }

    /// <inheritdoc />
    public BusinessResult DeleteQuestion(Guid id)
    {
        try
        {
            var questionToDelete = this._questionAccessLayer.GetById(id);
            if (questionToDelete is null)
                return BusinessResult.Error("Question not found");

            this._questionAccessLayer.Delete(questionToDelete);
            return BusinessResult.Success();
        }
        catch (Exception ex)
        {
            return BusinessResult.Error(ex.Message);
        }
    }
}
