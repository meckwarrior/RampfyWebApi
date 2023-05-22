using System.ComponentModel.DataAnnotations;

namespace RampfyWebApi.Application.HttpModels
{
    public class AuthenticationRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
