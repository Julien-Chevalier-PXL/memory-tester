namespace Memory.Tester.Common.Pagination;

/// <summary>
/// Represents a single page of results from a paginated query.
/// </summary>
/// <typeparam name="TResult">The type of the items contained in the page.</typeparam>
public class PageResult<TResult>
{
    /// <summary>
    /// Gets or sets the collection of items of the page.
    /// </summary>
    public TResult[] Items { get; set; } = [];

    /// <summary>
    /// Gets or sets the total number of items.
    /// </summary>
    public int TotalCount { get; set; }
}
