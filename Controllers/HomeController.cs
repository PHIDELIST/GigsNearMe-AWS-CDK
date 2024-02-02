using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using GigsNearMe.Models;
using GigsNearMe.Contracts;
using GigsNearMe.ViewModels;

namespace GigsNearMe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGigsNearMeRepository _repository;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IGigsNearMeRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var touringArtists = await _repository.ArtistRepository.GetArtistsWithToursAsync();

            var viewData = _mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistViewModel>>(touringArtists);
            return View(viewData);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
