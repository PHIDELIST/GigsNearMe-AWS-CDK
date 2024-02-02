using System.Threading.Tasks;

namespace GigsNearMe.Contracts
{
    public interface IGigsNearMeRepository
    {
        IArtistRepository ArtistRepository { get; }
        IVenueRepository VenueRepository { get; }
        ITourRepository TourRepository { get; }
        IGigRepository GigRepository { get; }

        Task SaveAsync();
    }
}
