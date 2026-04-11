namespace Memory.Tester.Core.Data.AccessLayers.Interfaces;

using Memory.Tester.Core.Data.AccessLayers.Abstractions;
using Memory.Tester.Core.Data.Entities;

/// <summary>
/// Interface which defines the contract for the question access layer, responsible for handling data operations related
/// to questions.
/// </summary>
public interface IQuestionAccessLayer : IAccessLayer<Question>
{
}
