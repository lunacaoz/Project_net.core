using AutoMapper;
using Net_API.DTO;
using Net_API.Entities;
using Net_API.Model;

namespace Net_API.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                CreateMap<Users, UserDTO>();
                CreateMap<Users, User>();

            });
            IMapper mapper = mappingConfig.CreateMapper();
            ServiceCollection services = new ServiceCollection();   
            services.AddSingleton(mapper);
        }  
    }
}
