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
            SuggestionsBuilder builder = new SuggestionsBuilder("Content/cities_canada-usa.tsv");
            builder.cityInput = q;
            List<Suggestion> suggestions = builder.GetSuggestions();

            var suggestionResult = new { suggestions = suggestions};
            var suggestionsResultJson = Json(suggestionResult);

            suggestionsResultJson.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return suggestionsResultJson;
		}
    }
}
