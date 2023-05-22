using RampfyWebApi.Application.ViewModels;

namespace RampfyWebApi.Application.HttpModels
{
    public class VendasHttpModel
    {
        IEnumerable<VendaViewModel> vendasViewModel { get; set; }

        public VendasHttpModel() { }
        public VendasHttpModel(IEnumerable<VendaViewModel> vendasViewModel)
        {
            this.vendasViewModel = vendasViewModel;
        }
    }
}
