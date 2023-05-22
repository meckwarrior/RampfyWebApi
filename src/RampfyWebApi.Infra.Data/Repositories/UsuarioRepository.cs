using Microsoft.EntityFrameworkCore;
using RampfyWebApi.Domain.Entities;
using RampfyWebApi.Domain.Interfaces.Repositories;
using RampfyWebApi.Infra.Data.Context;

namespace RampfyWebApi.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        private readonly RampfyContext _context;

        public UsuarioRepository(RampfyContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario> AuthenticationAsync(Usuario usuario)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email== usuario.Email 
                                                    && u.Senha == usuario.Senha);
        }
    }
}
