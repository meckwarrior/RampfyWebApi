namespace RampfyWebApi.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity obj);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity obj);
        Task DeleteAsync(TEntity obj);
        void Dispose();
    }
}
    