using EmployeeApi.Models;

namespace EmployeeApi.Data;

public static class EmployeeSeeder
{
    public static void Seed(EmployeeContext context)
    {
        if (!context.Employees.Any())
        {
            context.Employees.AddRange(
                new Employee { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Department = "HR", Salary = 50000, Phone = "1234567890" },
                new Employee { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Department = "IT", Salary = 60000, Phone = "2345678901" },
                new Employee { FirstName = "Robert", LastName = "Johnson", Email = "robert.johnson@example.com", Department = "Finance", Salary = 55000, Phone = "3456789012" },
                new Employee { FirstName = "Emily", LastName = "Davis", Email = "emily.davis@example.com", Department = "Marketing", Salary = 52000, Phone = "4567890123" },
                new Employee { FirstName = "Michael", LastName = "Brown", Email = "michael.brown@example.com", Department = "IT", Salary = 61000, Phone = "5678901234" }
            );
            context.SaveChanges();
        }
    }
}
