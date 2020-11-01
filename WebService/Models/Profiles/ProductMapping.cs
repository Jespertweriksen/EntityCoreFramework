using Assignment4;
using AutoMapper;
using WebService.Models.DTO;

namespace WebService.Models.Profiles
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductDTO>();
                
                
            CreateMap<Product, ProductCategoryDTO>();
        }
    }
}