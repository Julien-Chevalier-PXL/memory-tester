namespace Memory.Tester.Core.Business.Dtos;

/// <summary>
/// Record representing the result of a business operation.
/// </summary>
public record BusinessResult
{
    /// <summary>
    /// Gets a value indicating whether the operation completed successfully.
    /// </summary>
    public bool IsSuccess { get; init; }

    /// <summary>
    /// Gets the error message if the operation failed.
    /// </summary>
    public string? ErrorMessage { get; init; }
}

/// <summary>
/// Record representing the result of a business operation that returns a value.
/// </summary>
public sealed record BusinessResult<TResult> : BusinessResult
{
    /// <summary>
    /// Gets the result of the operation if it completed successfully.
    /// </summary>
    public TResult? Result { get; init; }
}
