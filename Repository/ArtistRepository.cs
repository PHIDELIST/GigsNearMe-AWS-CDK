using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GigsNearMe.Contracts;
using GigsNearMe.Data;
using GigsNearMe.Models;

namespace GigsNearMe.Repository
{
    public class ArtistRepository : RepositoryBase<Artist>, IArtistRepository
    {
        public ArtistRepository(GigsNearMeDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Artist>> GetArtistsWithToursAsync()
        {
            return await (from a in RepositoryContext.Artists
                                        .Include(a => a.Tours)
                   where a.Tours.Count > 0
                   select a)
                    .OrderBy(a => a.Name)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}
