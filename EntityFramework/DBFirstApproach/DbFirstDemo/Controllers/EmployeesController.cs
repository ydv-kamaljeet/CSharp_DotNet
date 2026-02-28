using DbFirstDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class EmployeesController : Controller
{
    private readonly TrainingDBContext _db;
    public EmployeesController(TrainingDBContext db) => _db = db;

    public async Task<IActionResult> Index()
    {
        // Read from DB using scaffolded DbSet
        var list = await _db.Employees
                            .AsNoTracking()
                            .OrderBy(r => r.EmployeeId)
                            .ToListAsync();
        ViewData["ITEmployees"] = list.Where(e => e.Department == "IT").ToList();
        ViewBag.Avg = list.Average(s => s.Salary);
        return View(list);
    }
}