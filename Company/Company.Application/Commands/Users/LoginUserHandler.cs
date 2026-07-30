

namespace Company.Application.Commands.Users
{
    public class LoginUserHandler(IUserRepository repo, IConfiguration configuration) : IRequestHandler<LoginUserCommand, string?>
    {
        private readonly PasswordHasher<User> _passwordHasher = new();
        public async Task<string?> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var user = await repo.GetByUserNameAsync(command.UserName);
            if (user == null)
            {
                return null;
            }
            var result = _passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                command.Password);
            if (result != PasswordVerificationResult.Success)
            {
                return null;
            }
            return GenerateToken(user);
        }
        private string GenerateToken(User user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role,user.Role),
            new Claim("Department",user.Department),
            new Claim("Experience",user.Experience.ToString())
        };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
