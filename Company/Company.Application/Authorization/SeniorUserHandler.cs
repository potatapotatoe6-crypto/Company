
namespace Company.Application.Authorization
{
    public class SeniorUserHandler : AuthorizationHandler<SeniorUserRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            SeniorUserRequirement requirement)
        {

            bool isRole = context.User.IsInRole("Admin");
            bool isDepartment = context.User.HasClaim("Department","IT");
            int.TryParse(
             context.User.FindFirst("Experience")?.Value,
             out int experience);
            if (isRole && isDepartment && experience >= requirement.Experience)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
