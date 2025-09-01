using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EmployeeApi.Data
{
    public class EmployeeContextFactory : IDesignTimeDbContextFactory<EmployeeContext>
    {
        public EmployeeContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmployeeContext>();
            optionsBuilder.UseSqlServer("Server=LAPTOP-H9EO19E9\\SQLEXPRESS;Database=EmployeeDB;Trusted_Connection=True;");
            return new EmployeeContext(optionsBuilder.Options);
        }
    }
}
