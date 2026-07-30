

namespace Company.Infrastructure.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
       .ValueGeneratedOnAdd();
            //one to one
            builder.Property(x => x.Name).HasMaxLength(500).HasDefaultValue("John");
            builder.ToTable("Employees");
           

        }
    }
}
