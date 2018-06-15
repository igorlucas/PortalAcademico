using AcademicGate.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace AcademicGate.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController()
        {
            _context = new ApplicationDbContext();
        }
        

        [HttpGet]
        public ActionResult ListStudents()  
        {
            ViewBag.Students = _context.Users.Where(u=> u.Permission == "Aluno").Select(a=> a.Name).ToList();

            return View();
        }

        [HttpGet]
        public ActionResult ListTeachers()
        {

            ViewBag.Teachers = _context.Users.Where(u => u.Permission == "Professor").Select(a => a.Name).ToList();
            return View();
        }

        [HttpGet]
        public ActionResult ListUsers()
        {
            ViewBag.Users = _context.Users.Select(a => a.Name).ToList();
            return View();
        }

        [AllowAnonymous]
        public ActionResult ShowAvaliations()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ShowReports()   
        {
            return View();
        }
    }
}