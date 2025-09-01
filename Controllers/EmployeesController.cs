using EmployeeApi.Data;
using EmployeeApi.DTOs;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly EmployeeContext _context;

    public EmployeesController(EmployeeContext context)
    {
        _context = context;
    }

    // GET: api/employees
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var employees = await _context.Employees
            .Select(e => new EmployeeReadDto
            {
                EmployeeId = e.EmployeeId,
                FullName = $"{e.FirstName} {e.LastName}",
                Email = e.Email,
                Phone = e.Phone,
                Department = e.Department,
                HireDate = e.HireDate,
                Salary = e.Salary
            })
            .ToListAsync();

        return Ok(new { success = true, data = employees });
    }

    // GET: api/employees/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var emp = await _context.Employees.FindAsync(id);
        if (emp == null) return NotFound(new { success = false, message = "Employee not found" });

        var empDto = new EmployeeReadDto
        {
            EmployeeId = emp.EmployeeId,
            FullName = $"{emp.FirstName} {emp.LastName}",
            Email = emp.Email,
            Phone = emp.Phone,
            Department = emp.Department,
            HireDate = emp.HireDate,
            Salary = emp.Salary
        };

        return Ok(new { success = true, data = empDto });
    }

    // POST: api/employees
    [HttpPost]
    public async Task<IActionResult> Create(EmployeeCreateDto dto)
    {
        var emp = new Employee
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
            Department = dto.Department,
            Salary = dto.Salary,
            HireDate = DateTime.UtcNow
        };

        _context.Employees.Add(emp);
        await _context.SaveChangesAsync();

        var empDto = new EmployeeReadDto
        {
            EmployeeId = emp.EmployeeId,
            FullName = $"{emp.FirstName} {emp.LastName}",
            Email = emp.Email,
            Phone = emp.Phone,
            Department = emp.Department,
            HireDate = emp.HireDate,
            Salary = emp.Salary
        };

        return CreatedAtAction(nameof(GetById), new { id = emp.EmployeeId }, new { success = true, data = empDto });
    }

    // PUT: api/employees/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, EmployeeCreateDto dto)
    {
        var emp = await _context.Employees.FindAsync(id);
        if (emp == null) return NotFound(new { success = false, message = "Employee not found" });

        emp.FirstName = dto.FirstName;
        emp.LastName = dto.LastName;
        emp.Email = dto.Email;
        emp.Phone = dto.Phone;
        emp.Department = dto.Department;
        emp.Salary = dto.Salary;

        await _context.SaveChangesAsync();

        var empDto = new EmployeeReadDto
        {
            EmployeeId = emp.EmployeeId,
            FullName = $"{emp.FirstName} {emp.LastName}",
            Email = emp.Email,
            Phone = emp.Phone,
            Department = emp.Department,
            HireDate = emp.HireDate,
            Salary = emp.Salary
        };

        return Ok(new { success = true, data = empDto });
    }

    // DELETE: api/employees/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var emp = await _context.Employees.FindAsync(id);
        if (emp == null) return NotFound(new { success = false, message = "Employee not found" });

        _context.Employees.Remove(emp);
        await _context.SaveChangesAsync();
        return Ok(new { success = true, message = "Employee deleted successfully" });
    }
}
