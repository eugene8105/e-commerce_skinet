using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // creating a map between Product and ProductToReturnDto classes
            CreateMap<Product, ProductToReturnDto>()
                // formating output properties.
                // Inside of Product class this two properties are class not string but in our 
                // ProductToReturnDto class we need only strings.
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                // specifies mapping for pictures
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}