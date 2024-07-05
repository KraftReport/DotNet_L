using Microsoft.AspNetCore.Mvc;
using MVCApp.Models;
using System.Diagnostics;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MVCAppDbContext _context;

        public HomeController(ILogger<HomeController> logger, MVCAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateEditExpense()
        {
            return View();
        }

        public IActionResult CreateEditExpenseForm(Expense model)
        {
            _context.Expense.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Expense");
        }

        public IActionResult Expense()
        {
            var AllExpenses = _context.Expense.ToList();
            return View(AllExpenses);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
