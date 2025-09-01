namespace EmployeeApi.DTOs;

public class EmployeeReadDto
{
    public int EmployeeId { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string Department { get; set; } = null!;
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
}
