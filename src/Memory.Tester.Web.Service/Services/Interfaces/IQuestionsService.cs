namespace Memory.Tester.Web.Service.Services.Interfaces;

using Memory.Tester.Common.Pagination;
using Memory.Tester.Web.Service.Dtos;
using Memory.Tester.Web.Service.Services.Questions.Requests;
using Memory.Tester.Web.Service.Services.Questions.Responses;

/// <summary>
/// Interface which defines the contract for the questions service, responsible for handling operations related to
/// questions in the application.
/// </summary>
public interface IQuestionsService
{
    /// <summary>
    /// Method to search for questions based on the provided pageable query.
    /// </summary>
    /// <param name="pageableQuery">The query used to paginate and filter.</param>
    /// <returns>A <see cref="ServiceResult{TResult}"/> containing a page of questions.</returns>
    Task<ServiceResult<PageResult<QuestionView>>> SearchQuestionsAsync(PageableQuery pageableQuery);

    /// <summary>
    /// Method to create a question.
    /// </summary>
    /// <param name="questionCreationModel">The model to create a question.</param>
    /// <returns>A <see cref="ServiceResult{TResult}"/> containing the id of the created question.</returns>
    Task<ServiceResult<Guid>> CreateQuestionAsync(QuestionCreationRequest questionCreationModel);

    /// <summary>
    /// Method to update a question.
    /// </summary>
    /// <param name="id">The id of the question.</param>
    /// <param name="updateQuestionModel">The model to update the question.</param>
    /// <returns>A <see cref="ServiceResult"/> representing the result of the operation.</returns>
    Task<ServiceResult> UpdateQuestionAsync(Guid id, QuestionUpdateRequest updateQuestionModel);

    /// <summary>
    /// Method to delete a question.
    /// </summary>
    /// <param name="id">The id of the question.</param>
    /// <returns>A <see cref="ServiceResult"/> representing the result of the operation.</returns>
    Task<ServiceResult> DeleteQuestionAsync(Guid id);
}
