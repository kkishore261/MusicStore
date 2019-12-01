using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace BusinessLayer
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper;
        public static void ConfigureAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            Mapper = config.CreateMapper();
            config.AssertConfigurationIsValid();
        }
    }

    public class MappingProfile : Profile
    {
       
    }
}