

namespace Company.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public int Add(Employee employee)
        {
            _context.Employees.Add(employee);

            return _context.SaveChanges();
        }
    }
}
