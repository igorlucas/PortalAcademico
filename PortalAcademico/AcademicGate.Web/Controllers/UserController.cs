using AcademicGate.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AcademicGate.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }


        //public ActionResult Index(string query = null)
        //{
        //    var upcomingGigs = _context.Gigs
        //        .Include(g => g.Artist)
        //        .Include(g => g.Genre)
        //        .Where(g => g.DateTime > DateTime.Now && !g.IsCanceled);

        //    if (!String.IsNullOrWhiteSpace(query))
        //    {
        //        upcomingGigs = upcomingGigs
        //            .Where(g =>
        //                    g.Artist.Name.Contains(query) ||
        //                    g.Genre.Name.Contains(query) ||
        //                    g.Venue.Contains(query));
        //    }

        //    var viewModel = new GigsViewModel
        //    {
        //        UpcomingGigs = upcomingGigs,
        //        ShowActions = User.Identity.IsAuthenticated,
        //        Heading = "Upcoming Gigs",
        //        SearchTerm = query
        //    };

        //    return View("Gigs", viewModel);
        //}
        // GET: User
        public ActionResult GetStudentByTeam(string nameTeam)   
        {
            if (!String.IsNullOrWhiteSpace(nameTeam)) { }
                var turmas = _context.Teams.Where(t=> t.Name.Contains(nameTeam));

            //var _turmas = _context.RegistrationStudentTeams.Where(t=> t.TeamId == );

            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
