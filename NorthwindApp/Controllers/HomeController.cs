using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindApp.Model;
using NorthwindApp.Models;
using System.Diagnostics;

namespace NorthwindApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NorthwindContext _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = new NorthwindContext();
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            if (!employees.Any())
            {
                _logger.LogInformation("Employees list is empty.");
            }

            return View(employees);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(employee);
        }



        public IActionResult Orders(int id)
        {
            var orders = _context.Orders.Where(o => o.EmployeeId == id).ToList();
            if (!orders.Any())
            {
                _logger.LogInformation("Orders list is empty.");
            }

            return View(orders);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}