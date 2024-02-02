using System;
using System.Collections.Generic;

namespace GigsNearMe.Models
{
    public static class SeedData
    {
        private const string TheMarillosArtistName = "The Marillos";
        private const string FishmeisterArtistName = "Fishmeister";
        private const string PaleRedArtistName = "Pale Red";
        private const string FenderDudeArtistName = "Fender Dude";
        private const string SlightlyFumingArtistName = "Slightly Fuming";
        private const string ChunkyRainStormArtistName = "Chunky Rain Storm";
        private const string ElectrifyingArtistName = "Electrifying";
        private const string DepartingArtistName = "DepartingArtist";
        private const string BouncyArtistName = "BouncyArtist";

        private const string NorthAmericanTourName = "North American";
        private const string EuropeanTourName = "European";
        private const string OneAndDoneTourName = "One and Done";
        private const string OneNightOnlyTourName = "One Night Only";
        private const string DownUnderGoneTopsideTourName = "Down Under Gone Topside";
        private const string MeWithoutThemTourName = "Me Without Them";
        private const string NotMissingThemTourName = "Not Missing Them";
        private const string FollowingThemTourName = "Following Them";

        // keep track of seeded data so we can search for IDs etc
        private static List<Artist> _seedArtists;
        private static List<Venue> _seedVenues;
        private static List<Tour> _seedTours;
        private static List<Gig> _seedGigs;

        internal static IEnumerable<Artist> Artists
        {
            get
            {
                if (_seedArtists == null)
                {
                    _seedArtists = new List<Artist>
                    {
                        new Artist { ArtistID = 1, Name = TheMarillosArtistName },
                        new Artist { ArtistID = 2, Name = FishmeisterArtistName },
                        new Artist { ArtistID = 3, Name = PaleRedArtistName },
                        new Artist { ArtistID = 4, Name = FenderDudeArtistName },
                        new Artist { ArtistID = 5, Name = SlightlyFumingArtistName },
                        new Artist { ArtistID = 6, Name = ChunkyRainStormArtistName },
                        new Artist { ArtistID = 7, Name = ElectrifyingArtistName },
                        new Artist { ArtistID = 8, Name = DepartingArtistName },
                        new Artist { ArtistID = 9, Name = BouncyArtistName }
                    };
                }

                return _seedArtists;
            }
        }

        internal static IEnumerable<Venue> Venues
        {
            get
            {
                if (_seedVenues == null)
                {
                    var id = 1;
                    _seedVenues = new List<Venue>
                    {
                        new Venue
                        {
                            VenueID = id++,
                            Name = "A Hall in Ulster",
                            City = "Belfast",
                            StateOrCounty = "County Antrim",
                            Country = HostCountry.NorthernIreland
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "Vicarage Street",
                            City = "Dublin",
                            StateOrCounty = "County Dublin",
                            Country = HostCountry.Ireland
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "The Sage Plant",
                            City = "Gateshead",
                            StateOrCounty = "Tyne and Wear",
                            Country = HostCountry.England
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "A Corn Exchange",
                            City = "Cambridge",
                            StateOrCounty = "Cambridgeshire",
                            Country = HostCountry.England
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "Large Symphony Hall",
                            City = "Birmingham",
                            StateOrCounty = "West Midlands",
                            Country = HostCountry.England
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "The Shiny Dome",
                            City = "Brighton",
                            StateOrCounty = "Sussex",
                            Country = HostCountry.England
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "A Six-Sider",
                            City = "Reading",
                            StateOrCounty = "Berkshire",
                            Country = HostCountry.England
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "Oran Mor or Less",
                            City = "Glasgow",
                            StateOrCounty = "Strathclyde",
                            Country = HostCountry.Scotland
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "Chateau de chateau",
                            City = "Villersexel",
                            StateOrCounty = "Haute-Saone",
                            Country = HostCountry.France
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "Thunderthalle",
                            City = "Frankfurt",
                            StateOrCounty = "Hesse",
                            Country = HostCountry.Germany
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "Rounded Colosseum",
                            City = "Essen",
                            StateOrCounty = "North Rhine-Westphalia",
                            Country = HostCountry.Germany
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "Admiralsbalast",
                            City = "Berlin",
                            StateOrCounty = "Brandenburg",
                            Country = HostCountry.Germany
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "Progresjaorno",
                            City = "Warsaw",
                            StateOrCounty = "Masovia",
                            Country = HostCountry.Poland
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "Boat Trip to the Edge",
                            City = "Tampa",
                            StateOrCounty = "FL",
                            Country = HostCountry.USA
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "Some Plaza",
                            City = "Orlando",
                            StateOrCounty = "FL",
                            Country = HostCountry.USA
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "The Town Ballroom",
                            City = "Buffalo",
                            StateOrCounty = "NY",
                            Country = HostCountry.USA
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "A Theater",
                            City = "Los Angeles",
                            StateOrCounty = "CA",
                            Country = HostCountry.USA
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "The Old-time Ballroom",
                            City = "San Francisco",
                            StateOrCounty = "CA",
                            Country = HostCountry.USA
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "2:30am Club",
                            City = "Washington",
                            StateOrCounty = "DC",
                            Country = HostCountry.USA
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "PlayMore Theater",
                            City = "New York",
                            StateOrCounty = "NY",
                            Country = HostCountry.USA
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "The Imperial Ball",
                            City = "Quebec",
                            StateOrCounty = "QC",
                            Country = HostCountry.Canada
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "Phone Theatre",
                            City = "Montreal",
                            StateOrCounty = "QC",
                            Country = HostCountry.Canada
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "Our Music Hall",
                            City = "Toronto",
                            StateOrCounty = "ON",
                            Country = HostCountry.Canada
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "Majestic Opera House",
                            City = "Sydney, NSW",
                            StateOrCounty = "NSW",
                            Country = HostCountry.Australia
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "Triffids",
                            City = "Brisbane",
                            StateOrCounty = "QLD",
                            Country = HostCountry.Australia
                        },
                        new Venue
                        {
                            VenueID = id++,
                            Name = "Bank Arena",
                            City = "Sydney",
                            StateOrCounty = "NSW",
                            Country = HostCountry.Australia
                        }
                    };
                }

                return _seedVenues;
            }
        }

        internal static IEnumerable<Tour> Tours
        {
            get
            {
                if (_seedTours == null)
                {
                    var now = DateTime.UtcNow;
                    var id = 1;

                    _seedTours = new List<Tour>
                    {
                        // Tours for The Marillos
                        new Tour
                        {
                            TourID = id++,
                            ArtistID = _seedArtists.Find(a => a.Name == TheMarillosArtistName).ArtistID,
                            Name = NorthAmericanTourName,
                            Start = now.AddMonths(1)
                        },
                        new Tour
                        {
                            TourID = id++,
                            ArtistID = _seedArtists.Find(a => a.Name == TheMarillosArtistName).ArtistID,
                            Name = EuropeanTourName,
                            Start = now.AddMonths(5)
                        },
                        // Tours for Fishmeister
                        new Tour
                        {
                            TourID = id++,
                            ArtistID = _seedArtists.Find(a => a.Name == FishmeisterArtistName).ArtistID,
                            Name = EuropeanTourName,
                            Start = now.AddMonths(2)
                        },
                        new Tour
                        {
                            TourID = id++,
                            ArtistID = _seedArtists.Find(a => a.Name == FishmeisterArtistName).ArtistID,
                            Name = OneAndDoneTourName,
                            Start = now.AddMonths(5)
                        },
                        // Tours for Slightly Fuming
                        new Tour
                        {
                            TourID = id++,
                            ArtistID = _seedArtists.Find(a => a.Name == SlightlyFumingArtistName).ArtistID,
                            Name = OneNightOnlyTourName,
                            Start = now.AddMonths(4)
                        },
                        // Tours for Electrifying
                        new Tour
                        {
                            TourID = id++,
                            ArtistID = _seedArtists.Find(a => a.Name == ElectrifyingArtistName).ArtistID,
                            Name = DownUnderGoneTopsideTourName,
                            Start = now.AddMonths(5)
                        },
                        // Tours for DepartingArtist
                        new Tour
                        {
                            TourID = id++,
                            ArtistID = _seedArtists.Find(a => a.Name == DepartingArtistName).ArtistID,
                            Name = MeWithoutThemTourName,
                            Start = now.AddMonths(0)
                        },
                        new Tour
                        {
                            TourID = id++,
                            ArtistID = _seedArtists.Find(a => a.Name == DepartingArtistName).ArtistID,
                            Name = NotMissingThemTourName,
                            Start = now.AddMonths(2)
                        },
                        // Tours for BouncyArtist
                        new Tour
                        {
                            TourID = id++,
                            ArtistID = _seedArtists.Find(a => a.Name == BouncyArtistName).ArtistID,
                            Name = FollowingThemTourName,
                            Start = now.AddMonths(0)
                        }
                    };
                }

                return _seedTours;
            }
        }

        internal static IEnumerable<Gig> Gigs
        {
            get
            {
                if (_seedGigs == null)
                {
                    _seedGigs = new List<Gig>();
                    var id = 1;
                    Artist artistData;
                    Tour tourData;

                    // Generate sample (and fake!) gig data - for artists with multiple tours,
                    // look up the artist each time so any inserted changes don't cause data
                    // errors

                    // Gigs for The Marillos, North American tour
                    artistData = _seedArtists.Find(a => a.Name == TheMarillosArtistName);
                    tourData = _seedTours.Find(t => t.Name == NorthAmericanTourName && t.ArtistID == artistData.ArtistID);
                    _seedGigs.AddRange(new[]
                    {
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[16].VenueID,
                            Date = tourData.Start.AddDays(0)
                        },
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[17].VenueID,
                            Date = tourData.Start.AddDays(1)
                        },
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[18].VenueID,
                            Date = tourData.Start.AddDays(5)
                        },
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[19].VenueID,
                            Date = tourData.Start.AddDays(9)
                        },
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[15].VenueID,
                            Date = tourData.Start.AddDays(20)
                        },
                    });

                    // Gigs for The Marillos, European tour
                    artistData = _seedArtists.Find(a => a.Name == TheMarillosArtistName);
                    tourData = _seedTours.Find(t => t.Name == EuropeanTourName && t.ArtistID == artistData.ArtistID);
                    _seedGigs.AddRange(new[]
                    {
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[0].VenueID,
                            Date = tourData.Start.AddDays(0)
                        },
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[1].VenueID,
                            Date = tourData.Start.AddDays(2)
                        },
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[2].VenueID,
                            Date = tourData.Start.AddDays(4)
                        },
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[3].VenueID,
                            Date = tourData.Start.AddDays(6)
                        },
                    });

                    // Gigs for Fishmeister, European tour
                    artistData = _seedArtists.Find(a => a.Name == FishmeisterArtistName);
                    tourData = _seedTours.Find(t => t.Name == EuropeanTourName && t.ArtistID == artistData.ArtistID);
                    _seedGigs.AddRange(new[]
                    {
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[4].VenueID,
                            Date = tourData.Start.AddDays(0)
                        },
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[5].VenueID,
                            Date = tourData.Start.AddDays(1)
                        },
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[6].VenueID,
                            Date = tourData.Start.AddDays(3)
                        },
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[7].VenueID,
                            Date = tourData.Start.AddDays(5)
                        },
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[8].VenueID,
                            Date = tourData.Start.AddDays(7)
                        },
                    });

                    // Gigs for Fishmeister, One and Done tour
                    artistData = _seedArtists.Find(a => a.Name == FishmeisterArtistName);
                    tourData = _seedTours.Find(t => t.Name == OneAndDoneTourName && t.ArtistID == artistData.ArtistID);
                    _seedGigs.AddRange(new[]
                    {
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[3].VenueID,
                            Date = tourData.Start.AddDays(0)
                        }
                    });

                    // Gigs for Slightly Fuming, One Night Only tour
                    artistData = _seedArtists.Find(a => a.Name == SlightlyFumingArtistName);
                    tourData = _seedTours.Find(t => t.Name == OneNightOnlyTourName && t.ArtistID == artistData.ArtistID);
                    _seedGigs.AddRange(new[]
                    {
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[12].VenueID,
                            Date = tourData.Start
                        },
                    });

                    // Gigs for Electrifying, Down Under Gone TopsIde tour
                    artistData = _seedArtists.Find(a => a.Name == ElectrifyingArtistName);
                    tourData = _seedTours.Find(t => t.Name == DownUnderGoneTopsideTourName && t.ArtistID == artistData.ArtistID);
                    _seedGigs.AddRange(new[]
                    {
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[3].VenueID,
                            Date = tourData.Start
                        },
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[5].VenueID,
                            Date = tourData.Start.AddDays(6)
                        },
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[6].VenueID,
                            Date = tourData.Start.AddDays(8)
                        },
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[7].VenueID,
                            Date = tourData.Start.AddDays(15)
                        },
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[9].VenueID,
                            Date = tourData.Start.AddDays(20)
                        },
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[10].VenueID,
                            Date = tourData.Start.AddDays(25)
                        },
                    });

                    // Gigs for DepartingArtist, Me Without Them tour
                    artistData = _seedArtists.Find(a => a.Name == DepartingArtistName);
                    tourData = _seedTours.Find(t => t.Name == MeWithoutThemTourName && t.ArtistID == artistData.ArtistID);
                    _seedGigs.AddRange(new[]
                    {
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[23].VenueID,
                            Date = tourData.Start.AddDays(7)
                        },
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[24].VenueID,
                            Date = tourData.Start.AddDays(9)
                        },
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[25].VenueID,
                            Date = tourData.Start.AddDays(11)
                        },
                    });

                    // Gigs for DepartingArtist, Not Missing Them tour
                    artistData = _seedArtists.Find(a => a.Name == DepartingArtistName);
                    tourData = _seedTours.Find(t => t.Name == NotMissingThemTourName && t.ArtistID == artistData.ArtistID);
                    _seedGigs.AddRange(new[]
                    {
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[15].VenueID,
                            Date = tourData.Start.AddDays(0)
                        },
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[17].VenueID,
                            Date = tourData.Start.AddDays(9)
                        },
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[21].VenueID,
                            Date = tourData.Start.AddDays(11)
                        },
                    });

                    // gigs for BouncyArtist, Following Them tour
                    artistData = _seedArtists.Find(a => a.Name == BouncyArtistName);
                    tourData = _seedTours.Find(t => t.Name == FollowingThemTourName && t.ArtistID == artistData.ArtistID);
                    _seedGigs.AddRange(new[]
                    {
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[23].VenueID,
                            Date = tourData.Start.AddDays(0)
                        },
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[24].VenueID,
                            Date = tourData.Start.AddDays(10)
                        },
                        new Gig
                        {
                            GigID = id++,
                            ArtistID = artistData.ArtistID,
                            TourID = tourData.TourID,
                            VenueID = _seedVenues[25].VenueID,
                            Date = tourData.Start.AddDays(12)
                        },
                    });
                }

                return _seedGigs;
            }
        }
    }
}
