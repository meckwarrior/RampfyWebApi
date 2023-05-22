using RampfyWebApi.Domain.Entities;

namespace RampfyWebApi.Domain.Interfaces.Services
{
    public interface IVendaService : IServiceBase<Venda>
    {
        Task AddRangeAsync(IEnumerable<Venda> vendas);
        Task<IEnumerable<Venda>> GetVendasByDateAsync(DateTime? dataInicio, DateTime? dataFim);
    }
}
