using AutoMapper;
using RampfyWebApi.Application.ViewModels;
using RampfyWebApi.Domain.Entities;

namespace RampfyWebApi.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Venda, VendaViewModel>();
        }
    }
}