using RampfyWebApi.Domain.Entities;

namespace RampfyWebApi.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Task<Usuario> AuthenticationAsync(Usuario usuario);
    }
}
