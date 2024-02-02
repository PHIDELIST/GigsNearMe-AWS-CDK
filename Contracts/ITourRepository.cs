using System.Threading.Tasks;
using GigsNearMe.Models;

namespace GigsNearMe.Contracts
{
    public interface ITourRepository : IRepositoryBase<Tour>
    {
        Task<Tour> GetTourDetailsAsync(int tourID);
    }
}
