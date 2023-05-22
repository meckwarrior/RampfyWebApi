using RampfyWebApi.Application.ViewModels;

namespace RampfyWebApi.Application.HttpModels
{
    public class AuthenticationResponse
    {
        public int Codigo { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }


        public AuthenticationResponse(UsuarioViewModel usuarioViewModel, string token)
        {
            Codigo = usuarioViewModel?.Codigo??0;
            Email = usuarioViewModel?.Email;
            Token = token;
        }
    }
}
