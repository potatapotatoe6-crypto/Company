namespace Company.Infrastructure.DbNext
{
    
    namespace WebApplication3.Data
    {
        public class EmployeeDbContext(DbContextOptions options) : DbContext(options)
        {
            public DbSet<Employee> Employees { get; set; }

            public DbSet<User> Users { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                //  modelBuilder.Entity<Employee>().Property(e => e.Name).HasMaxLength(450).IsRequired(false);
                modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
                modelBuilder.ApplyConfiguration(new UserConfiguration());
            }
        }
    }

}
