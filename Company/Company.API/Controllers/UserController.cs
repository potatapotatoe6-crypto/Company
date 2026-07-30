

namespace Company.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IMediator mediator , IMapper mapper) : ControllerBase
    {
        
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            RegisterUserCommand command = mapper.Map<RegisterUserCommand>(model);
            bool result = await mediator.Send(command);
            if (!result)
            {
                return BadRequest("Username Already exists");
            }
            return Ok("User register successfully");
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            LoginUserCommand command = mapper.Map<LoginUserCommand>(model);
            string? token = await mediator.Send(command);
            if (token == null)
            {
                return Unauthorized("Invalid username or password");
            }
            return Ok(token);
        }
        //claims
        //[Authorize]
        //[HttpGet("Profile")]
        //public IActionResult Profile()
        //{
        //    var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    var name = User.Identity?.Name;
        //    var email = User.FindFirst(ClaimTypes.Email)?.Value;
        //    var role = User.FindFirst(ClaimTypes.Role)?.Value;
        //    return Ok(new
        //    {
        //        Id = id,
        //        Name = name,
        //        Email = email,
        //        Role = role
        //    });
        //}

        [Authorize(Policy = "SeniorAdminUser")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsersAsync(int id)
        {
            GetUserQuery query = new()
            {
                Id = id
            };
            UserDto? dto = await mediator.Send(query);
            if (dto == null)
            {
                return NotFound();
            }
            UserModel model = mapper.Map<UserModel>(dto);
            return Ok(model);
        }

    }
}
