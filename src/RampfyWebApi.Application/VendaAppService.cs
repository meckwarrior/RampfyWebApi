using RampfyWebApi.Application.HttpModels;
using RampfyWebApi.Application.Interfaces;
using RampfyWebApi.Domain.Entities;
using RampfyWebApi.Domain.Interfaces.Services;

namespace RampfyWebApi.Application
{
    public class VendaAppService : AppServiceBase<Venda>, IVendaAppService
    {
        private readonly IVendaService _vendaService;
        public VendaAppService(IVendaService vendaService) : base(vendaService)
        {
            _vendaService = vendaService;
        }

        public async Task AddRangeAsync(IEnumerable<Venda> vendas)
        {
            await _vendaService.AddRangeAsync(vendas);
        }

        public async Task<IEnumerable<Venda>> GetVendasByDateAsync(VendasRequest request)
        {
            return await _vendaService.GetVendasByDateAsync(request.DataInicio, request.DataFim);
        }
    }
}
