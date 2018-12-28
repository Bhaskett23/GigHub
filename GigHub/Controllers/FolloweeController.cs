using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class FolloweeController : Controller
    {
        private ApplicationDbContext _context;

        public FolloweeController()
        {
            _context = new ApplicationDbContext();
        }
        

        // GET: Followee
        public ActionResult Index()
        {
            var userID = User.Identity.GetUserId();
            var artists = _context.Followings.Where(x => x.FollowerId == userID)
                .Select(x => x.Followee)
                .ToList();
            var artistFollowing = new ArtistFollowingViewModel()
            {
                FollowingArtists = artists
            };
            return View(artistFollowing);
        }
    }
}