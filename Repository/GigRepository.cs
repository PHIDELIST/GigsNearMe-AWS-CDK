using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GigsNearMe.Contracts;
using GigsNearMe.Data;
using GigsNearMe.Models;

namespace GigsNearMe.Repository
{
    public class GigRepository : RepositoryBase<Gig>, IGigRepository
    {
        public GigRepository(GigsNearMeDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Gig>> FindAllWithDetailsAsync()
        {
            return await RepositoryContext.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Tour)
                .Include(g => g.Venue)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Gig> GetGigWithDetailsAsync(int gigID)
        {
            return await RepositoryContext.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Tour)
                .Include(g => g.Venue)
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.GigID == gigID);
        }
    }
}
