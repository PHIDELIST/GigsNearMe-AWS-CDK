using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GigsNearMe.Models
{
    public class Tour
    {
        public int TourID { get; set; }
        
        public int ArtistID { get; set; }
        
        // the 'Name' of the tour, e.g. "Yet another farewell from us 2021"
        public string Name { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }
        
        public Artist Artist { get; set; }
        
        // a 'gig' is slang for a concert or event
        public ICollection<Gig> Gigs { get; set; }
    }
}