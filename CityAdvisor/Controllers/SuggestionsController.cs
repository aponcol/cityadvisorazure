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
        public JsonResult Index(string q = "")
		{
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = baseDirectory + "Content/cities_canada-usa_clean_csv.csv";

            SuggestionsBuilder builder = new SuggestionsBuilder(filePath);
            builder.cityInput = q;
            List<Suggestion> suggestions = builder.GetSuggestions();

            var suggestionResult = new { suggestions = suggestions};
            var suggestionsResultJson = Json(suggestionResult);

            suggestionsResultJson.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return suggestionsResultJson;
		}
    }
}
