using System;
using Geolocation;
namespace CityAdvisor.Models
{
    public class City
    {
        public string name { get; set; }  
        public string alt_name { get; set; }
        public Coordinate location { get; set; }
        public string country { get; set; }

        public City(
            string nameFromFile, 
            string alt_nameFromFile, 
            string countryFromFile
        )
        {
            name = nameFromFile;
            alt_name = alt_nameFromFile;
            country = countryFromFile;
        }

        public void SetLocation(double latitude, double longitude)
        {
            Coordinate locationFromFile = new Coordinate();
            locationFromFile.Latitude = latitude;
            locationFromFile.Longitude = longitude;
            location = locationFromFile;
        }

    }
}
