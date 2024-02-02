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
    public class ArtistsController : Controller
    {
        private readonly ILogger<ArtistsController> _logger;
        private readonly IGigsNearMeRepository _repository;

        public ArtistsController(ILogger<ArtistsController> logger, IGigsNearMeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // GET: Artists
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var artists = _repository.ArtistRepository.FindAll();

            switch (sortOrder)
            {
                case "name_desc":
                    artists = artists.OrderByDescending(a => a.Name);
                    break;
                default:
                    artists = artists.OrderBy(a => a.Name);
                    break;
            }

            return View(await artists.AsNoTracking().ToListAsync());
        }

        // GET: Artists/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = _repository.ArtistRepository.FindByCondition(m => m.ArtistID == id).FirstOrDefault();
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
