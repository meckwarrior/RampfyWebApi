using RampfyWebApi.Domain.Entities;
using RampfyWebApi.Domain.Interfaces.Repositories;
using RampfyWebApi.Domain.Interfaces.Services;

namespace RampfyWebApi.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> AuthenticationAsync(Usuario usuario)
        {
            return await _usuarioRepository.AuthenticationAsync(usuario);
        }
    }
}
