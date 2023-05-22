using Microsoft.EntityFrameworkCore;
using RampfyWebApi.Domain.Entities;
using RampfyWebApi.Domain.Interfaces.Repositories;
using RampfyWebApi.Infra.Data.Context;

namespace RampfyWebApi.Infra.Data.Repositories
{
    public class VendaRepository : RepositoryBase<Venda>, IVendaRepository
    {
        private readonly RampfyContext _context;

        public VendaRepository(RampfyContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(IEnumerable<Venda> vendas)
        {
            await _context.AddRangeAsync(vendas);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Venda>> GetVendasByDateAsync(DateTime? dataInicio, DateTime? dataFim)
        {
            return await _context.Vendas.Where(v =>  (dataInicio == null || v.DataVenda >= dataInicio.Value)
                && (dataFim == null || v.DataVenda <= dataFim.Value)).Select(x => x).ToListAsync();
        }
    }
}
