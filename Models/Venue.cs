using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace GigsNearMe.Models
{
    public enum HostCountry
    {
        Australia,
        Canada,
        England,
        France,
        Germany,
        Ireland,
        NorthernIreland,
        Poland,
        Scotland,
        [Display(Name = "United States")]
        USA,
        Wales
    }

    public class Venue
    {
        public int VenueID { get; set; }

        public string Name { get; set; }

        public string City { get; set; }
        public string StateOrCounty { get; set; }
        public HostCountry Country { get; set; }

        public string Location
        {
            get
            {
                var displayAttr = GetDisplayAttribute(Country);
                var displayCountry = displayAttr != null ? displayAttr.Name : Country.ToString();
                return $"{Name}, {City}, {StateOrCounty}, {displayCountry}";
            }
        }

        private static DisplayAttribute GetDisplayAttribute(object value)
        {
            var type = value.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException($"Type {type} is not an enum");
            }

            // Get the enum field.
            var field = type.GetField(value.ToString());
            return field?.GetCustomAttribute<DisplayAttribute>();
        }
    }
}