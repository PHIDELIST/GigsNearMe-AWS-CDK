using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GigsNearMe.Contracts;
using GigsNearMe.Data;
using GigsNearMe.Models;

namespace GigsNearMe.Repository
{
    public class TourRepository : RepositoryBase<Tour>, ITourRepository
    {
        public TourRepository(GigsNearMeDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<Tour> GetTourDetailsAsync(int tourID)
        {
            return await RepositoryContext.Tours
                        .Include(t => t.Artist)
                        .Include(t => t.Gigs)
                            .ThenInclude(g => g.Venue)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(t => t.TourID == tourID);
        }
    }
}
