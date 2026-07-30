
using Company.Application.Commands.Users;
using Company.Application.Queries;

namespace Company.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterModel, RegisterUserCommand>();
            CreateMap<RegisterUserCommand, User>();
            CreateMap<User, UserModel>();
            CreateMap<User, GetUserQuery>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, UserModel>();
            CreateMap<LoginModel, LoginUserCommand>();
        }
    }
}
