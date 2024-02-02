using AutoMapper;
using GigsNearMe.Models;
using GigsNearMe.ViewModels;

namespace GigsNearMe
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Artist, ArtistViewModel>();
            CreateMap<Tour, TourViewModel>();

            CreateMap<Gig, GigViewModel>();
            CreateMap<GigViewModel, Gig>();
        }
    }
}
