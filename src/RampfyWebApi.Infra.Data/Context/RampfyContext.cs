using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RampfyWebApi.Domain.Entities;
using RampfyWebApi.Infra.Data.EntityConfig;

namespace RampfyWebApi.Infra.Data.Context
{
    public class RampfyContext : DbContext
    {
        public RampfyContext() : base()
        { }
        public RampfyContext(DbContextOptions<RampfyContext> options): base(options)
        { 
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UsuariosConfiguration().Configure(modelBuilder.Entity<Usuario>());
            new VendasConfiguration().Configure(modelBuilder.Entity<Venda>());
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            optionsBuilder.UseMySQL(configuration.GetConnectionString("RampfyWebApi"));
        }
    }
}
