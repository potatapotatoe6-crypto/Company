

//namespace Company.API.Controller
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class EmployeeController : ControllerBase
//    {
//        private readonly IEmployeeService _service;

//        public EmployeeController(IEmployeeService service)
//        {
//            _service = service;
//        }

//        [HttpPost]
//        public IActionResult Add(AddEmployeeDto dto)
//        {
//            bool result = _service.AddEmployee(dto);

//            if (result)
//                return Ok("Employee Added");

//            return BadRequest();
//        }
//    }

//}