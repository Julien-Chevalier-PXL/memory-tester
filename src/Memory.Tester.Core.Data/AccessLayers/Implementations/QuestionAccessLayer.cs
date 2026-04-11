namespace Memory.Tester.Core.Data.AccessLayers.Implementations;

using Memory.Tester.Core.Data.AccessLayers.Abstractions;
using Memory.Tester.Core.Data.AccessLayers.Interfaces;
using Memory.Tester.Core.Data.Entities;

/// <summary>
/// Implementation of the question access layer, responsible for handling data operations related to questions.
/// </summary>
internal sealed class QuestionAccessLayer : AFileAccessLayer<Question>, IQuestionAccessLayer
{
}
