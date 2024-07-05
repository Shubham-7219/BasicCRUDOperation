using BasicCRUDOperation.Data;
using BasicCRUDOperation.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicCRUDOperation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var employee = _context.Employees.ToList();
            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var emp = _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }
            return View(employee);
        }

        public IActionResult Details(int id)
        {
            var employeeDetail = _context.Employees.FirstOrDefault(x=> x.Id == id);
            if (employeeDetail == null)
            {
                return NotFound();
            }
            return View(employeeDetail);
        }

        public IActionResult Edit(int id)
        {
            var employeeEdit = _context.Employees.FirstOrDefault(x=>x.Id ==id);
            if (employeeEdit == null)
            {
                return NotFound();
            }
            return View(employeeEdit);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }
            return View(employee);
        }
        public IActionResult Delete(int id)
        {
            var employeeDelete = _context.Employees.FirstOrDefault(y=>y.Id == id);
            return View(employeeDelete);
        }
        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
