using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Temple.Data;
using Temple.Models;
using Temple.Models.TempleViewModel;

namespace Temple.Controllers
{
    public class HomeController : Controller
    {
        private readonly TempleContext _context;

        public HomeController(TempleContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            IQueryable<EnrollmentDateGroup> data =
                from pacient in _context.Pacients
                group pacient by pacient.EnrollmentDate into dateGroup
                select new EnrollmentDateGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    PacientCount = dateGroup.Count()
                };

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
