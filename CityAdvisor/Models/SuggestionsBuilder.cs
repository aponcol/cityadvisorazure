using System;
using System.Collections.Generic;

namespace CityAdvisor.Models
{
    public class SuggestionsBuilder
    {
        public string cityInput;

        List<City> cities;

        public SuggestionsBuilder(string file)
        {
            CityDataImporter importer = new CityDataImporter();
            cities = importer.GetCitiesFromFile(file);
        }

        public List<Suggestion> GetSuggestions()
        {
            List<Suggestion> suggestions = new List<Suggestion>();

            List<City> citiesForSuggestions = cities.FindAll(x => x.name == cityInput);
            foreach(City cityForSuggestion in citiesForSuggestions) {
                suggestions.Add(new Suggestion(cityForSuggestion, 1));
            }

            return suggestions;
        }

    }
}
