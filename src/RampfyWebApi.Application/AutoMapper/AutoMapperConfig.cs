using AutoMapper;

namespace RampfyWebApi.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper { get; set; }

        public static void RegisterMappings()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainToViewModelMappingProfile>();
                cfg.AddProfile<ViewModelToDomainMappingProfile>();
            });

            Mapper = configuration.CreateMapper();
        }
    }
}