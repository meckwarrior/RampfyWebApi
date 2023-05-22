using AutoMapper;
using RampfyWebApi.Application.ViewModels;
using RampfyWebApi.Domain.Entities;

namespace RampfyWebApi.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<VendaViewModel, Venda>();
        }
    }
}