using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CityAdvisor.Models;

namespace CityAdvisor.Controllers
{
    public class SuggestionsController : Controller
    {
        [HttpGet]
        public JsonResult Main(string q = "")
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = baseDirectory + "Content/cities_test_clean_csv.csv";

            CityDataImporter importer = new CityDataImporter();
            List<City> cities = importer.GetCitiesFromCsvFile(filePath);

            List<Suggestion> suggestions = new List<Suggestion>();
            foreach (City city in cities)
            {
                suggestions.Add(new Suggestion(city, 1));
            }

            var suggestionResult = new { suggestions = suggestions };
            var suggestionsResultJson = Json(suggestionResult);

            suggestionsResultJson.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return suggestionsResultJson;
        }

        [HttpGet]
        public JsonResult Index(string q = "", double latitude = 0.0d, double longitude = 0.0d)
		{
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = baseDirectory + "Content/cities_canada-usa_clean_csv.csv";

            SuggestionsBuilder builder = new SuggestionsBuilder(filePath);
            builder.cityInput = q;
            builder.latitudeInput = latitude;
            builder.longitudeInput = longitude;
            List<Suggestion> suggestions = builder.GetSuggestions();

            var suggestionResult = new { suggestions = suggestions};
            var suggestionsResultJson = Json(suggestionResult);

            suggestionsResultJson.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return suggestionsResultJson;
		}
    }
}
