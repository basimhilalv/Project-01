using AutoMapper;
using Project_01.Models;

namespace Project_01.Mappings
{
    public class ProjectMappings : Profile
    {
        public ProjectMappings()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
