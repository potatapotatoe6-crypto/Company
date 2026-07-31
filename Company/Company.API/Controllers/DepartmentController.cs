namespace Company.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController(IMediator mediator, IMapper mapper) : ControllerBase
    {

        [HttpPost("AddDepartment")]
        public async Task<IActionResult> AddDepartment(DepartmentModel model)
        {
            RegisterUserCommand command = mapper.Map<RegisterUserCommand>(model);
            bool result = await mediator.Send(command);
            if (!result)
            {
                return BadRequest("Username Already exists.....");
            }
            return Ok("User register successfully");
        }
    }
}
