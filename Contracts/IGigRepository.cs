using System.Collections.Generic;
using System.Threading.Tasks;
using GigsNearMe.Models;

namespace GigsNearMe.Contracts
{
    public interface IGigRepository : IRepositoryBase<Gig>
    {
        Task<IEnumerable<Gig>> FindAllWithDetailsAsync();

        Task<Gig> GetGigWithDetailsAsync(int gigId);
    }
}
