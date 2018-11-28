using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;
        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var currentUser = User.Identity.GetUserId();
            var exists = _context.Attendances.Any(x => x.AttendeeId == currentUser && x.GigId == dto.GigId);

            if(exists)
            {
                return BadRequest("Already attending");
            }

            var attendance = new Attendance()
            {
                GigId = dto.GigId,
                AttendeeId = currentUser
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
