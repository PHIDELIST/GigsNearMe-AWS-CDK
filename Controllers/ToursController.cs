using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using GigsNearMe.Contracts;
using GigsNearMe.ViewModels;
using GigsNearMe.Models;

namespace GigsNearMe.Controllers
{
    public class ToursController : Controller
    {
        private readonly ILogger<ToursController> _logger;
        private readonly IGigsNearMeRepository _repository;
        private readonly IMapper _mapper;

        public ToursController(ILogger<ToursController> logger, IGigsNearMeRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: Tours
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            var tours = _repository.TourRepository.FindAll();

            switch (sortOrder)
            {
                case "name_desc":
                    tours = tours.OrderByDescending(t => t.Name);
                    break;
                case "Date":
                    tours = tours.OrderBy(t => t.Start);
                    break;
                case "date_desc":
                    tours = tours.OrderByDescending(t => t.Start);
                    break;
                default:
                    tours = tours.OrderBy(t => t.Name);
                    break;
            }

            var viewData = _mapper.Map<IEnumerable<Tour>, IEnumerable<TourViewModel>>(await tours.ToListAsync());
            return View(viewData);
        }

        // GET: Tours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || !id.HasValue)
            {
                return NotFound();
            }

            var tour = await _repository.TourRepository.GetTourDetailsAsync(id.Value);
            if (tour == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<TourViewModel>(tour));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
