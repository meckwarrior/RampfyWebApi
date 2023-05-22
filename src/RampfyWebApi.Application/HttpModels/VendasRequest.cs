using System.ComponentModel.DataAnnotations;

namespace RampfyWebApi.Application.HttpModels
{
    public class VendasRequest
    {
        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataFim { get; set; }
    }
}
