

namespace Company.Application.Commands.Users
{
    public class LoginUserCommand : IRequest<string?>
    { 
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
