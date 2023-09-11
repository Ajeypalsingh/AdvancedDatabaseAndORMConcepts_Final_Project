using AdvancedDatabaseAndORMConcepts_Final_Project.Data;
using AdvancedDatabaseAndORMConcepts_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AdvancedDatabaseAndORMConcepts_Final_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AdvancedDatabaseAndORMConcepts_Final_ProjectContext _context;

        public HomeController(ILogger<HomeController> logger, AdvancedDatabaseAndORMConcepts_Final_ProjectContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            HashSet<List> allLists = _context.List.Include(l => l.Items).ToHashSet();
            return View(allLists);
        }
                
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}