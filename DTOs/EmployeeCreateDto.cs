using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.DTOs;

public class EmployeeCreateDto
{
    [Required, MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [Required, MaxLength(50)]
    public string LastName { get; set; } = null!;

    [Required, EmailAddress, MaxLength(100)]
    public string Email { get; set; } = null!;

    [MaxLength(20)]
    public string? Phone { get; set; }

    [Required, MaxLength(50)]
    public string Department { get; set; } = null!;

    [Range(0.01, double.MaxValue)]
    public decimal Salary { get; set; }
}
