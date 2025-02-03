using AutoMapper;
using BackendApp.Models;


public class MappingProfile : Profile
{
    public MappingProfile()
    {

        CreateMap<UserModel, CreatorRespondsDTO>();

        // 🔹 Map CourseModel → CourseResponseDTO
        CreateMap<CourseModel, CourseResponseDTO>()
            .ForMember(dest => dest.Creator, opt => opt.MapFrom(src => src.Creator)) // Map Creator
            .ForMember(dest => dest.CreatorId, opt => opt.MapFrom(src => src.Creator.Id)); // Map CreatorId


        // Map between BlogRequestDTO and BlogModel
        CreateMap<BlogRequestDTO, BlogModel>();
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



