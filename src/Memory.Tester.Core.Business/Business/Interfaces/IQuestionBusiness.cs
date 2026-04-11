namespace Memory.Tester.Core.Business.Business.Interfaces;

using Memory.Tester.Common.Pagination;
using Memory.Tester.Core.Business.Business.Models;
using Memory.Tester.Core.Business.Business.ViewModels;
using Memory.Tester.Core.Business.Dtos;

/// <summary>
/// Defines the contract for business logic operations related to questions.
/// </summary>
public interface IQuestionBusiness
{
    /// <summary>
    /// Method to search for questions based on the provided pageable query.
    /// </summary>
    /// <param name="pageableQuery">The query used to paginate and filter.</param>
    /// <returns>A <see cref="BusinessResult{TResult}"/> containing a page of questions.</returns>
    BusinessResult<PageResult<QuestionViewModel>> SearchQuestions(PageableQuery pageableQuery);

    /// <summary>
    /// Method to create a question.
    /// </summary>
    /// <param name="questionCreationModel">The model to create a question.</param>
    /// <returns>A <see cref="BusinessResult{TResult}"/> containing the id of the created question.</returns>
    BusinessResult<Guid> CreateQuestion(QuestionCreationModel questionCreationModel);

    /// <summary>
    /// Method to update a question.
    /// </summary>
    /// <param name="id">The id of the question.</param>
    /// <param name="updateQuestionModel">The model to update the question.</param>
    /// <returns>A <see cref="BusinessResult"/> representing the result of the operation.</returns>
    BusinessResult UpdateQuestion(Guid id, QuestionUpdateModel updateQuestionModel);

    /// <summary>
    /// Method to delete a question.
    /// </summary>
    /// <param name="id">The id of the question.</param>
    /// <returns>A <see cref="BusinessResult"/> representing the result of the operation.</returns>
    BusinessResult DeleteQuestion(Guid id);
}
