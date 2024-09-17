using AutoMapper;
using backend_app.Controllers;
using BackendApp.Controllers;
using BackendApp.Models;


namespace backend_app
{
    public class MappingProfile: Profile
    {
      private  MappingProfile()
        {
            CreateMap<LocationRequest, LocationModel>();
            CreateMap<CategoryRequest, CategoryModel>();
            // CreateMap<UserModel, UserRequest>();
        }
    }
}
