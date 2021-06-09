using Api.Dtos;
using AutoMapper;
using Core.Entities;

namespace Api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category , CategoryDto>();
            CreateMap<ProductItem , ProductItemDto>()
                .ForMember(destination => destination.SubCategory ,
                    options => options.MapFrom(source => source.SubCategory.Name)); 
        }
    }
}