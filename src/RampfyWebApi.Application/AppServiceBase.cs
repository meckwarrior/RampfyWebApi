using RampfyWebApi.Application.Interfaces;
using RampfyWebApi.Domain.Interfaces.Services;

namespace RampfyWebApi.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public async Task AddAsync(TEntity obj)
        {
            await _serviceBase.AddAsync(obj);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _serviceBase.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _serviceBase.GetByIdAsync(id);
        }

        public async Task DeleteAsync(TEntity obj)
        {
            _serviceBase.DeleteAsync(obj);
        }

        public async Task UpdateAsync(TEntity obj)
        {
            _serviceBase.UpdateAsync(obj);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
