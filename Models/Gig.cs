using System;
using System.ComponentModel.DataAnnotations;

namespace GigsNearMe.Models
{
    /// <summary>
    /// A 'gig' is an event, for example a concert
    /// </summary>
    public class Gig
    {
        public int GigID { get; set; }
        
        public int ArtistID { get; set; }
        
        // nullable to prevent circular cascade delete errors in migrations code
        public int? TourID { get; set; }
        
        public int VenueID { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public Artist Artist { get; set; }
        public Venue Venue { get; set; }
        public Tour Tour { get; set; }
    }
}