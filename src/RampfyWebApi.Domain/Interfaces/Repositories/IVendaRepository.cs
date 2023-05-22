using RampfyWebApi.Domain.Entities;

namespace RampfyWebApi.Domain.Interfaces.Repositories
{
    public interface IVendaRepository : IRepositoryBase<Venda>
    {
        Task AddRangeAsync(IEnumerable<Venda> vendas);
        Task<IEnumerable<Venda>> GetVendasByDateAsync(DateTime? dataInicio, DateTime? dataFim);
    }
}
