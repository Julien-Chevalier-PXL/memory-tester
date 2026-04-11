namespace Memory.Tester.Web.Service.Services.Questions.Requests;

using Memory.Tester.Core.Business.Business.Models;

/// <summary>
/// Record which represents the model to update a question.
/// </summary>
public sealed record QuestionUpdateRequest : AQuestionEditionRequest
{
    /// <inheritdoc />
    public override QuestionUpdateModel ToModel() => new() { Title = this.Title, Answer = this.Answer };
}
