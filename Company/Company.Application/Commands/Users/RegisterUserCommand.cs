

namespace Company.Application.Commands.Users
{
    public class RegisterUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string Role { get; set; } = "User";
        public string Department { get; set; } = string.Empty;

        public int Experience { get; set; }
    }
}
