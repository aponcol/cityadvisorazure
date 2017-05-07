using System;
namespace CityAdvisor.Models
{
    public class Suggestion
    {
        
        public string name;
        public string latitude;
        public string longitude;
        public float score;

		City city;

        public Suggestion(City cityForSuggestion, float scoreForSuggestion)
        {
            city = cityForSuggestion;
            name = city.name;
            latitude = city.location.Latitude.ToString();
            longitude = city.location.Longitude.ToString();
            score = scoreForSuggestion;
        }
    }
}
