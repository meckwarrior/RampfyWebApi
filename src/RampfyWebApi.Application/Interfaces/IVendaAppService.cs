using RampfyWebApi.Application.HttpModels;
using RampfyWebApi.Domain.Entities;

namespace RampfyWebApi.Application.Interfaces
{
    public interface IVendaAppService : IAppServiceBase<Venda>
    {
        Task AddRangeAsync(IEnumerable<Venda> vendas);
        Task<IEnumerable<Venda>> GetVendasByDateAsync(VendasRequest request);
    }
}
