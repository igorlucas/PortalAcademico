using AcademicGate.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AcademicGate.Web.Controllers
{
    public class RegisterController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private readonly ApplicationDbContext _context;

        public RegisterController()
        {
            _context = new ApplicationDbContext();
        }

        public RegisterController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        [AllowAnonymous]
        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterUser(RegisterViewModel model, string permission)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Name = model.Name,
                    Cpf = model.Cpf,
                    PhoneNumber = model.Phone,
                    BirthDate = model.BirthDate,
                    Address = model.Address,
                    Permission = permission,
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");

                AddErrors(result);
            }

            // Se chegamos até aqui e houver alguma falha, exiba novamente o formulário
            return View(model);
        }


        [AllowAnonymous]
        public ActionResult RegisterTeacher()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterTeacher(RegisterViewModel model, string permission)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Name = model.Name,
                    Cpf = model.Cpf,
                    PhoneNumber = model.Phone,
                    BirthDate = model.BirthDate,
                    Address = model.Address,
                    Formation = model.Formation,
                    Permission = permission,
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                AddErrors(result);
            }

            // Se chegamos até aqui e houver alguma falha, exiba novamente o formulário
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult RegisterStudent()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterStudent(RegisterViewModel model, string serie)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Name = model.Name,
                    MotherName = model.MotherName,
                    IngressedYear = DateTime.Now,
                    IngressedSerie = serie,
                    Cpf = model.Cpf,
                    RA = model.RA,
                    Permission = "Aluno",
                    PhoneNumber = model.Phone,
                    UserName = model.Email,
                    BirthDate = model.BirthDate,
                    Address = model.Address,
                    Email = model.Email
                };

                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // Se chegamos até aqui e houver alguma falha, exiba novamente o formulário
            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult RegisterCalendar()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult RegisterCalendar(AcademicCalendar model)
        {
            _context.AcademicCalendars.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult RegisterTeam()
        {

            ViewBag.DisciplineId = new SelectList(_context.Disciplines, "Id", "Name");
            ViewBag.UserId = new SelectList(_context.Users.Where(u => u.Permission == "Professor"), "Id", "Name");
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult RegisterTeam(Team model)
        {
            model.Discipline = _context.Disciplines.Find(model.DisciplineId);

            model.Name = model.Discipline.Name + " - sala " + model.Room;
            _context.Teams.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult RegisterDicipline()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult RegisterDicipline(Discipline model)
        {
            _context.Disciplines.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult RegisterNote()
        {

            ViewBag.TeamId = new SelectList(_context.Teams, "Id", "Name");
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult RegisterNote(NotesStudentTeamViewModel model, string typeNote, double valueNote)
        {

            var aluno = _context.Users.FirstOrDefault(u => u.Name == model.StudentName);

            var notes = _context
                .RegistrationStudentTeams
                .FirstOrDefault(n => n.StudentId == aluno.Id && n.TeamId == model.TeamId);

            if (typeNote == "AP1")
            {
                if (notes.AP1 != 0)
                {
                    ViewBag.TeamId = new SelectList(_context.Teams, "Id", "Name");
                    ViewBag.Message = "AP1 já foi lançada nessa turma";
                    return View();
                }
                else
                    model.AP1 = valueNote;
            }

            if (typeNote == "AP2")
            {
                if (notes.AP2 != 0)
                {
                    ViewBag.Message = "AP2 já foi lançada nessa turma";
                    return View();
                }
                model.AP2 = valueNote;
            }

            if (notes == null)
            {
                var notesStudentTeam = new RegistrationStudentTeam()
                {
                    StudentId = aluno.Id,
                    TeamId = model.TeamId,
                    AP1 = model.AP1,
                    AP2 = model.AP2
                };

                _context.RegistrationStudentTeams.Add(notesStudentTeam);
            }
            else
            {
                notes.AP1 = (notes.AP1 > 0) ? notes.AP1 : model.AP1;
                notes.AP2 = (notes.AP2 > 0) ? notes.AP2 : model.AP2;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult RegisterStudentTeam()
        {

            ViewBag.TeamId = new SelectList(_context.Teams, "Id", "Name");
            return View();
        }

        public ActionResult RegisterStudentTeam(NotesStudentTeamViewModel model, string serie)
        {
            var aluno = _context.Users.FirstOrDefault(u => u.Name == model.StudentName);

            if (_context.RegistrationStudentTeams.Any(r => r.StudentId == aluno.Id && r.TeamId == model.TeamId))
            {
                ViewBag.TeamId = new SelectList(_context.Teams, "Id", "Name");
                ViewBag.Message = "Já exite matricula para esse aluno nessa turma";
                return View();
            }

            var registration = new RegistrationStudentTeam()
            {
                StudentId = aluno.Id,
                TeamId = model.TeamId,
                Serie = serie
            };
            _context.RegistrationStudentTeams.Add(registration);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetTeamRegistred()
        {

            //if (user.Permission != "Professor")
            //    ViewBag.Message = "Somente professor pode registrar frequência de alunos";

            var listaTurmas = new List<Team>();

            var model = _context.RegistrationStudentTeams;
            var userID = User.Identity.GetUserId();
            var listTurmasId = _context.Teams.Where(t => t.UserId == "42e3962f-4c3e-4f0b-97ce-3e051fa62adb").Select(t => t.Id).ToList();

            foreach (var turmaId in listTurmasId)
            {
                var item = model.FirstOrDefault(m => m.TeamId == turmaId);

                if (item != null)
                {
                    var _item = _context.Teams.FirstOrDefault(t => t.Id == item.TeamId);
                    listaTurmas.Add(_item);
                }
            }
            ViewBag.ListaTurmasId = listaTurmas.Select(l => l.Id);    
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult RegisterFrequence(Team turma) 
        {
            var model = _context.RegistrationStudentTeams.Where(m=> m.TeamId == turma.Id).ToList();

            var students = new List<ApplicationUser>();

            foreach (var item in model)
            {
                var student = _context.Users.Find(item.StudentId);
                students.Add(student);
            }
            
            foreach (var item in students)
            {
                item.Name = item.Name+" - " + item.RA;
            }
            ViewBag.TurmaId = turma.Id;
            ViewBag.StudentsId = students.Select(n => n.Id).ToList();
            ViewBag.Students = students.Select(n => n.Name).ToList();
            return View();  
        }

        [AllowAnonymous]
        [HttpPost]      
        public ActionResult RegisterFrequence(Frequence model, string student)
        {
            return View();
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

    }
}