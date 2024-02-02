using System.Collections.Generic;

namespace GigsNearMe.Models
{
    public class Artist
    {
        public int ArtistID { get; set; }
        
        public string Name { get; set; }

        public ICollection<Tour> Tours { get; set; }

    }
}