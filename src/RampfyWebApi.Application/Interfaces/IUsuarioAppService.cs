using RampfyWebApi.Application.HttpModels;
using RampfyWebApi.Application.ViewModels;
using RampfyWebApi.Domain.Entities;

namespace RampfyWebApi.Application.Interfaces
{
    public interface IUsuarioAppService : IAppServiceBase<Usuario>
    {
        Task<AuthenticationResponse> AuthenticationAsync(AuthenticationRequest usuario);
        Task<IEnumerable<UsuarioViewModel>> GetTodosAsync();
        Task AdicionarAsync(UsuarioViewModel usuarioViewModel);
    }
}
