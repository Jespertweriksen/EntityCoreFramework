using Assignment4;
using AutoMapper;
using WebService.Models.DTO;

namespace WebService.Models.Profiles
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
        }
    }
}