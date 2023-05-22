using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RampfyWebApi.Domain.Entities;

namespace RampfyWebApi.Infra.Data.EntityConfig
{
    public class VendasConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(p => p.Codigo);

        }
    }
}
