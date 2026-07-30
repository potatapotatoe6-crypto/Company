namespace Company.Core.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string Role {  get; set; } = "User";
        public string Department { get; set; } = string.Empty;

        public int Experience { get; set; }
    }
}
