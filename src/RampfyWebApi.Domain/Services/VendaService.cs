using RampfyWebApi.Domain.Entities;
using RampfyWebApi.Domain.Interfaces.Repositories;
using RampfyWebApi.Domain.Interfaces.Services;

namespace RampfyWebApi.Domain.Services
{
    public class VendaService : ServiceBase<Venda>, IVendaService
    {
        private readonly IVendaRepository _vendasRepository;

        public VendaService(IVendaRepository vendasRepository)  :base(vendasRepository)
        {
            _vendasRepository = vendasRepository;
        }

        public async Task AddRangeAsync(IEnumerable<Venda> vendas)
        {
            await _vendasRepository.AddRangeAsync(vendas);
        }

        public async Task<IEnumerable<Venda>> GetVendasByDateAsync(DateTime? dataInicio, DateTime? dataFim)
        {
            return await _vendasRepository.GetVendasByDateAsync(dataInicio, dataFim);
        }
    }
}
