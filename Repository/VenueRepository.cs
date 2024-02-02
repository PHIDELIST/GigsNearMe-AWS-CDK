using GigsNearMe.Contracts;
using GigsNearMe.Data;
using GigsNearMe.Models;

namespace GigsNearMe.Repository
{
    public class VenueRepository : RepositoryBase<Venue>, IVenueRepository
    {
        public VenueRepository(GigsNearMeDbContext context)
            : base(context)
        {
        }
    }
}
