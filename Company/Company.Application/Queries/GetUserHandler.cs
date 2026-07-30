
namespace Company.Application.Queries
{
    public class GetUserHandler(IUserRepository repo, IMapper mapper) : IRequestHandler<GetUserQuery, UserDto?>
    {
        public async Task<UserDto?> Handle(GetUserQuery query,CancellationToken cancellationToken)
        {
            var user = await repo.GetUserByIdAsync(query.Id);
            if (user == null)
            {
                return null;
            }
            return mapper.Map<UserDto>(user);
        }
    }
}
