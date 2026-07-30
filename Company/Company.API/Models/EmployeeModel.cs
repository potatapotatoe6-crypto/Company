namespace Company.API.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        public int Age { get; set; }
        public decimal Salary { get; set; }
        public DateTime JoiningDate { get; set; }
        public bool IsActive { get; set; }
      

    }
}
