using System.Collections.Generic;
using GigsNearMe.Models;

namespace GigsNearMe.ViewModels
{
    public class ArtistViewModel
    {
        public int ArtistID { get; set; }

        public string Name { get; set; }

        public ICollection<Tour> Tours { get; set; }
    }
}
