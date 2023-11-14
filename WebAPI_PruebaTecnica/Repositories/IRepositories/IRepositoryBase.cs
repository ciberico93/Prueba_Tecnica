namespace WebAPI_PruebaTecnica.Repositories.IRepositories
{
    public interface IRepositoryBase<TEntity>
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync (int id);
    }
}
