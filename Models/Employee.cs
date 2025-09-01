namespace EmployeeApi.Models;

public class Employee
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string Department { get; set; } = null!;
    public DateTime HireDate { get; set; } = DateTime.UtcNow;
    public decimal Salary { get; set; }
}
