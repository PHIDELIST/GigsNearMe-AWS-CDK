using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using GigsNearMe.Contracts;
using GigsNearMe.ViewModels;

namespace GigsNearMe.Controllers
{
    public class VenuesController : Controller
    {
        private readonly ILogger<VenuesController> _logger;
        private readonly IGigsNearMeRepository _repository;

        public VenuesController(ILogger<VenuesController> logger, IGigsNearMeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // GET: Venues
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var venues = _repository.VenueRepository.FindAll();

            switch (sortOrder)
            {
                case "name_desc":
                    venues = venues.OrderByDescending(v => v.Name);
                    break;
                default:
                    venues = venues.OrderBy(v => v.Name);
                    break;
            }

            return View(await venues.AsNoTracking().ToListAsync());
        }

        // GET: Venues/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venue = _repository.VenueRepository.FindByCondition(v => v.VenueID == id).FirstOrDefault();
            if (venue == null)
            {
                return NotFound();
            }

            return View(venue);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
