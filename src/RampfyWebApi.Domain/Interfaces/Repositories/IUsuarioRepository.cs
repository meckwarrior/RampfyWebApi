using RampfyWebApi.Domain.Entities;

namespace RampfyWebApi.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<Usuario> AuthenticationAsync(Usuario usuario);
    }
}
