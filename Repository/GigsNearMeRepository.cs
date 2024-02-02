using System.Threading.Tasks;
using GigsNearMe.Contracts;
using GigsNearMe.Data;

namespace GigsNearMe.Repository
{
    public class GigsNearMeRepository : IGigsNearMeRepository
    {
        private GigsNearMeDbContext _context;
        private IArtistRepository _artist;
        private IVenueRepository _venue;
        private ITourRepository _tour;
        private IGigRepository _gig;

        public IArtistRepository ArtistRepository
        {
            get
            {
                if (_artist == null)
                {
                    _artist = new ArtistRepository(_context);
                }

                return _artist;
            }
        }

        public IVenueRepository VenueRepository
        {
            get
            {
                if (_venue == null)
                {
                    _venue = new VenueRepository(_context);
                }

                return _venue;
            }
        }

        public ITourRepository TourRepository
        {
            get
            {
                if (_tour == null)
                {
                    _tour = new TourRepository(_context);
                }

                return _tour;
            }
        }

        public IGigRepository GigRepository
        {
            get
            {
                if (_gig == null)
                {
                    _gig = new GigRepository(_context);
                }

                return _gig;
            }
        }

        public GigsNearMeRepository(GigsNearMeDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
