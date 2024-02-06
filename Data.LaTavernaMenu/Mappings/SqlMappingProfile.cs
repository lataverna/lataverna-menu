using AutoMapper;
using Core.LaTavernaMenu.Models;
using Data.LaTavernaMenu.Models;

namespace Data.LaTavernaMenu.Mappings
{
    class SqlMappingProfile : Profile
    {
        public SqlMappingProfile()
        {
            CreateMap<DataDish, Dish>().ReverseMap();
            CreateMap<DataSection, Section>().ReverseMap();
        }
    }
}
