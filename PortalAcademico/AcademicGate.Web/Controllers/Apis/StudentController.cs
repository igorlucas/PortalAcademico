using AcademicGate.Web.Models;
using System.Linq;
using System.Web.Http;

namespace AcademicGate.Web.Controllers.Apis
{
    public class StudentController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/Frequence
        public IHttpActionResult GetStudentsByTeam(int teamId)
        {
            var turmas = _context.RegistrationStudentTeams.Where(t=> t.TeamId == teamId);
            return Ok();
        }

        // GET: api/Frequence/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Frequence
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Frequence/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Frequence/5
        public void Delete(int id)
        {
        }
    }
}
