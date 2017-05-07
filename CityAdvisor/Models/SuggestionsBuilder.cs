using System;
using System.Collections.Generic;
using Geolocation;

namespace CityAdvisor.Models
{
    public class SuggestionsBuilder
    {
        public string cityInput;
        public double latitudeInput;
        public double longitudeInput;

        List<City> cities;

        public SuggestionsBuilder(string file)
        {
            CityDataImporter importer = new CityDataImporter();
            cities = importer.GetCitiesFromCsvFile(file);
        }

        public List<Suggestion> GetSuggestions()
        {
            List<Suggestion> suggestions = new List<Suggestion>();

            // Only Latitude and Logitude provided
            if (OnlyLocationProvided())
            {
                suggestions = GetSuggestionsFromLocation();
            }
            else
            {
                // Exact match
                List<City> citiesForSuggestions = cities.FindAll(x => x.name == cityInput);
                foreach (City cityForSuggestion in citiesForSuggestions)
                {
                    suggestions.Add(new Suggestion(cityForSuggestion, 1));
                }

            }


            return suggestions;
        }

        protected bool OnlyLocationProvided()
        {
            return String.IsNullOrWhiteSpace(cityInput) &&
                         latitudeInput.GetType() != null &&
                         longitudeInput.GetType() != null;
        }

        protected Coordinate GetTargetLocation()
        {
			Coordinate targetLocation = new Coordinate();
			targetLocation.Latitude = latitudeInput;
			targetLocation.Longitude = longitudeInput;
            return targetLocation;
        }

        protected List<Suggestion> GetSuggestionsFromLocation()
        {
            List<Suggestion> suggestions = new List<Suggestion>();

			Coordinate targetLocation = GetTargetLocation();
			foreach (City city in cities)
			{
				city.distanceToTarget = GeoCalculator.GetDistance(city.location, targetLocation);
			}
			Comparison<City> cityComparison = new Comparison<City>((City x, City y) => x.distanceToTarget.CompareTo(y.distanceToTarget));
			cities.Sort(cityComparison);

			List<City> citiesForSuggestions = cities.GetRange(0, 10);
            float score = 1;
			foreach (City cityForSuggestion in citiesForSuggestions)
			{
				Console.WriteLine(cityForSuggestion.name);
				suggestions.Add(new Suggestion(cityForSuggestion, score));
				score -= 0.1f;
			}
            return suggestions;
        }
    }
}
