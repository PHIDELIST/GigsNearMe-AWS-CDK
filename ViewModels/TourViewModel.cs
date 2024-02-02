using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GigsNearMe.Models;

namespace GigsNearMe.ViewModels
{
    public class TourViewModel
    {
        public int TourID { get; set; }

        public int ArtistID { get; set; }

        // the 'Name' of the tour, e.g. "Yet another farewell from us 2021"
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime Start { get; set; }

        public Artist Artist { get; set; }

        // a 'gig' is slang for a concert or event
        public ICollection<Gig> Gigs { get; set; }

        public string TourTitle => $"{Artist.Name} - {Name}";
    }
}
