using AutoMapper;
using BackendApp.Models;

namespace BackendApp.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {


            // Map between CategoryModel and CategoryRequest
            CreateMap<CategoryModel, CreateCategoryRequest>();
            // CreateMap<CategoryRequest, CategoryModel>();
            CreateMap<ClassModel, ClassResponse>();
            // Map between ClassRequest and ClassModel
            CreateMap<ClassRequest, ClassModel>();
            // Map between TestRequest and Test
            CreateMap<TestRequest, TestModel>();
            // Map between TestOptionRequest and TestOptionModel
            CreateMap<TestOptionRequest, TestOptionModel>();

        }
    }


}
