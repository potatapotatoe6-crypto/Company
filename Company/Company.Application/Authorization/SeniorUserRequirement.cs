

namespace Company.Application.Authorization
{
    public class SeniorUserRequirement : IAuthorizationRequirement
    {
        public string Role { get; set; }
        public string Department { get; set; } = string.Empty;

        public int Experience { get; set; }

        public SeniorUserRequirement(int experience)
        {
            Experience = experience;
        }
    }
}
