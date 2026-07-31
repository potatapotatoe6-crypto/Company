

namespace Company.Infrastructure.Repository
{
    public class EmployeeRepository(EmployeeDbContext context) : IEmployeeRepository
    {

        public int Add(Employee employee)
        {
            context.Employees.Add(employee);

            return context.SaveChanges();
        }
    }
}
