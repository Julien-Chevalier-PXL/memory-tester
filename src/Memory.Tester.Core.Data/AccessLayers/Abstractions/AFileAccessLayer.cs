namespace Memory.Tester.Core.Data.AccessLayers.Abstractions;

using System.Text.Json;

using Memory.Tester.Common.Pagination;
using Memory.Tester.Core.Data.Entities.Abstractions;

/// <summary>
/// Abstract class which defines the base for all file access layers, responsible for handling data operations related
/// to files.
/// </summary>
public abstract class AFileAccessLayer<TEntity> : IAccessLayer<TEntity>
    where TEntity : AEntity
{
    /// <inheritdoc/>
    public TEntity? GetById(Guid id)
    {
        var filePath = GetEntityFilePath(id);
        return File.Exists(filePath)
            ? JsonSerializer.Deserialize<TEntity>(File.ReadAllText(filePath))
            : null;
    }

    /// <inheritdoc/>
    public PageResult<TResult> GetCollectionPage<TResult>(PageableQuery pageableQuery, Func<TEntity, TResult> selector)
    {
        var entityFolder = GetEntityFolderPath();
        var allFilesPaths = Directory.GetFiles(entityFolder, "*.json");
        var filesPathsEnumerable = allFilesPaths.AsEnumerable();

        if (pageableQuery.IsPaginated)
        {
            filesPathsEnumerable = filesPathsEnumerable
                .Skip(pageableQuery.StartIndex)
                .Take(pageableQuery.PageSize);
        }

        var entities = filesPathsEnumerable.Select(filePath => JsonSerializer.Deserialize<TEntity>(File.ReadAllText(filePath)));
        if (entities.Any(static e => e is null))
            throw new InvalidDataException("One or more entities could not be deserialized.");

        return new PageResult<TResult>
        {
            Items = [.. entities.Cast<TEntity>().Select(selector)],
            TotalCount = allFilesPaths.Length,
        };
    }

    /// <inheritdoc/>
    public void Add(TEntity entity)
    {
        var id = Guid.NewGuid();
        entity.Id = id;

        var filePath = GetEntityFilePath(id);
        File.WriteAllText(filePath, JsonSerializer.Serialize(entity));
    }

    /// <inheritdoc/>
    public void Update(TEntity entity)
    {
        var filePath = GetEntityFilePath(entity.Id);
        if (!File.Exists(filePath))
        {
            throw new ArgumentException("The entity doesn't exists", nameof(entity));
        }

        File.WriteAllText(filePath, JsonSerializer.Serialize(entity));
    }

    /// <inheritdoc/>
    public void Delete(TEntity entity)
    {
        var filePath = GetEntityFilePath(entity.Id);
        if (!File.Exists(filePath))
        {
            throw new ArgumentException("The entity doesn't exists", nameof(entity));
        }

        File.Delete(filePath);
    }

    private static string GetEntityFilePath(Guid id)
    {
        var folderPath = GetEntityFolderPath();
        return Path.Combine(folderPath, $"{id}.json");
    }

    private static string GetEntityFolderPath()
    {
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var folderPath = Path.Combine(appDataPath, "MemoryTester", "Data", $"{typeof(TEntity).Name}s");
        return Directory.CreateDirectory(folderPath).FullName; // Ensures the directory exists
    }
}
