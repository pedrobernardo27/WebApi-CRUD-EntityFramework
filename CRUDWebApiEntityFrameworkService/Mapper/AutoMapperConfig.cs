using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRUDWebApiEntityFrameworkService.Mapper
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(config =>
               new MapperConfiguration(mc => mc.AddProfiles(new List<Profile> {
                   new DomainToModelMappingProfile(),
                   new ModelToDomainMappingProfile()})).CreateMapper());
        }
    }
}
