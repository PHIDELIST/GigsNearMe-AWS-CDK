using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using GigsNearMe.Contracts;
using GigsNearMe.Models;
using GigsNearMe.ViewModels;

namespace GigsNearMe.Controllers
{
    public class GigsController : Controller
    {
        private readonly ILogger<GigsController> _logger;
        private readonly IGigsNearMeRepository _repository;
        private readonly IMapper _mapper;

        public GigsController(ILogger<GigsController> logger, IGigsNearMeRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: Gigs
        public async Task<IActionResult> Index()
        {
            var gigs = await _repository.GigRepository.FindAllWithDetailsAsync();
            var viewData = _mapper.Map<IEnumerable<Gig>, IEnumerable<GigViewModel>>(gigs);
            return View(viewData);
        }

        // GET: Gigs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || !id.HasValue)
            {
                return NotFound();
            }

            var gig = await _repository.GigRepository.GetGigWithDetailsAsync(id.Value);
            if (gig == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<GigViewModel>(gig));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
