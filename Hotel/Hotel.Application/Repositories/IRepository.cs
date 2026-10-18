namespace Hotel.Application.Repositories;

/// <summary>
/// Обобщённый интерфейс репозитория
/// </summary>
public interface IRepository<TEntity>
    where TEntity : class
{
    /// <summary>
    /// Получить все сущности
    /// </summary>
    public IReadOnlyList<TEntity> GetAll();

    /// <summary>
    /// Получить сущность по идентификатору
    /// </summary>
    public TEntity? GetById(int id);

    /// <summary>
    /// Добавить новую сущность
    /// </summary>
    public TEntity Add(TEntity entity);

    /// <summary>
    /// Обновить существующую сущность
    /// </summary>
    public TEntity? Update(TEntity entity);

    /// <summary>
    /// Удалить сущность по идентификатору
    /// </summary>
    public bool Delete(int id);
}