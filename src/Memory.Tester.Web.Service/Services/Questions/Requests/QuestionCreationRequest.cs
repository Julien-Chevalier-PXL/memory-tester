namespace Memory.Tester.Web.Service.Services.Questions.Requests;

using Memory.Tester.Core.Business.Business.Models;

/// <summary>
/// Record which represents the model to create a question.
/// </summary>
public sealed record QuestionCreationRequest : AQuestionEditionRequest
{
    /// <inheritdoc />
    public override QuestionCreationModel ToModel() => new() { Title = this.Title, Answer = this.Answer };
}
