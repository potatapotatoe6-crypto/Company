

namespace Company.Application.Commands.Users
{
    public class RegisterUserHandler(IUserRepository repo, IMapper mapper)  :IRequestHandler<RegisterUserCommand,bool>
    {
        private readonly PasswordHasher<User> _passwordHasher = new();
        public async Task<bool> Handle(RegisterUserCommand command,CancellationToken cancellationToken)
        {
            var existingUser = await repo.GetByUserNameAsync(command.UserName);
            if (existingUser != null)
            {
                return false;
            }

            User user = mapper.Map<User>(command);
            user.PasswordHash = _passwordHasher.HashPassword(user, command.Password);
            return await repo.RegisterAsync(user);
        }
    }
}
