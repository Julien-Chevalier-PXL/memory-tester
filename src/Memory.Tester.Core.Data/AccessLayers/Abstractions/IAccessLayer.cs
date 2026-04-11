namespace Memory.Tester.Core.Data.AccessLayers.Abstractions;

using Memory.Tester.Common.Pagination;
using Memory.Tester.Core.Data.Entities.Abstractions;

/// <summary>
/// Interface which defines the contract for a generic access layer, responsible for handling data operations related to
/// entities of type TEntity.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public interface IAccessLayer<TEntity> 
    where TEntity : AEntity
{
    /// <summary>
    /// Method to get an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The id of the entity.</param>
    /// <returns>The entity.</returns>
    TEntity? GetById(Guid id);

    /// <summary>
    /// Method to get a page of the entities.
    /// </summary>
    /// <param name="pageableQuery">The query to paginate the collection.</param>
    /// <param name="selector">The selection function.</param>
    /// <returns>A page of entities.</returns>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    PageResult<TResult> GetCollectionPage<TResult>(PageableQuery pageableQuery, Func<TEntity, TResult> selector);

    /// <summary>
    /// Method to ceate a new entity.
    /// </summary>
    /// <param name="entity">The entity to create.</param>
    void Add(TEntity entity);

    /// <summary>
    /// Method to update an entity.
    /// </summary>
    /// <param name="entity">The updated entity.</param>
    void Update(TEntity entity);

    /// <summary>
    /// Method to delete an entity.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    void Delete(TEntity entity);
}
