

namespace Company.Application.Queries
{
    public class GetUserQuery : IRequest<UserDto?>
    {
        public int Id { get; set; }
    }
}
