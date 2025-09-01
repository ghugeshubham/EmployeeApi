using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.DTOs
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
