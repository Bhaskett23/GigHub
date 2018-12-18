using GigHub.Models;
using System.Linq;

namespace GigHub.ViewModels
{
    public class HomeViewModel
    {
        public IQueryable<Gig> UpcomingGigs { get; set; }
        public bool ShowActions { get; set; }
    }
}