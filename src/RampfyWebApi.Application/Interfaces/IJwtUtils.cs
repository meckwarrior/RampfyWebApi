using RampfyWebApi.Application.ViewModels;

namespace RampfyWebApi.Application.Interfaces
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(UsuarioViewModel usuarioViewModel);
        public int? ValidateJwtToken(string? token);
    }
}
