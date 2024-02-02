using System.Collections.Generic;
using System.Threading.Tasks;
using GigsNearMe.Models;

namespace GigsNearMe.Contracts
{
    public interface IArtistRepository : IRepositoryBase<Artist>
    {
        public Task<IEnumerable<Artist>> GetArtistsWithToursAsync();
    }
}
