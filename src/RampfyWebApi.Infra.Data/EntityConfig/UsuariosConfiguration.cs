using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RampfyWebApi.Domain.Entities;

namespace RampfyWebApi.Infra.Data.EntityConfig
{
    public class UsuariosConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Codigo);

            builder.HasIndex(p => p.Email )
                .IsUnique();

            builder.Property(p => p.Email)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Senha)
                .HasColumnType("varchar(50)");

            builder.HasData(new Usuario 
                {   Codigo = 1, 
                    Email = "teste@rampfy.com",
                    Senha = "123456" 
                });
        }
    }
}
