
namespace Company.Infrastructure.Repository
{
    public class UserRepository(EmployeeDbContext context) : IUserRepository
    {
     
        public async Task<bool> RegisterAsync(User user) { 
           await context.Users.AddAsync(user);
            return await context.SaveChangesAsync() > 0;
        }
        public async Task<User?> GetByUserNameAsync(string userName)
        {
            return await context.Users.FirstOrDefaultAsync(u=>u.UserName == userName);
        }


        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await context.Users.FirstOrDefaultAsync(x=>x.Id==id);
        }
    }
}
