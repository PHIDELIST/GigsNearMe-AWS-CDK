using System;
using System.ComponentModel.DataAnnotations;
using GigsNearMe.Models;

namespace GigsNearMe.ViewModels
{
    public class GigViewModel
    {
        public int GigID { get; set; }

        public int ArtistID { get; set; }

        // nullable to prevent circular cascade delete errors in migrations code
        public int? TourID { get; set; }

        public int VenueID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime Date { get; set; }

        public Artist Artist { get; set; }
        public Venue Venue { get; set; }
        public Tour Tour { get; set; }

    }
}
