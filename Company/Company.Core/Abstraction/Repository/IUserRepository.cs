namespace Company.Core.Abstraction.Repository
{
    public interface IUserRepository
    {
        Task<bool> RegisterAsync(User user);

        Task<User?> GetByUserNameAsync(string userName);

        Task<User?> GetUserByIdAsync(int id);
    }
}
