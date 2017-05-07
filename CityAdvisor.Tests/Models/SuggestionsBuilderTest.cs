using System;
using System.Collections.Generic;
using CityAdvisor.Models;
using NUnit.Framework;
using Geolocation;

namespace CityAdvisor.Tests.Models
{
    [TestFixture]
    public class SuggestionsBuilderTest
    {
        

        [Test]
        public void WhenAPerfectCityNameMatchIsFoundReturnItWithFullWeight()
        {
            SuggestionsBuilder builder = new SuggestionsBuilder("cities_test_csv.csv");
            builder.cityInput = "Alma";
            List<Suggestion> suggestions = builder.GetSuggestions();
            Assert.AreEqual(1, suggestions.Count);
            foreach(Suggestion suggestion in suggestions) {
                Assert.AreEqual("Alma", suggestion.name);
            }
        }

        [Test]
        public void WhenNoCityIsProvidedButLocationIsProvidedShouldReturnAtLeast10Cities()
        {
            SuggestionsBuilder builder = new SuggestionsBuilder("cities_canada-usa_clean_csv.csv");
            builder.cityInput = "";
            // Location : San Francisco
            builder.latitudeInput = 37.77493;
            builder.longitudeInput = -122.41942;

			List<Suggestion> suggestions = builder.GetSuggestions();
			Assert.AreEqual(10, suggestions.Count);
        }

        [Test]
        public void WhenLocationOfSanFranciscoProvidedSausalitoShouldBeWithinTheResultSuggestions()
		{
			SuggestionsBuilder builder = new SuggestionsBuilder("cities_canada-usa_clean_csv.csv");
			builder.cityInput = "";
			// Location : San Francisco
			builder.latitudeInput = 37.77493;
			builder.longitudeInput = -122.41942;

			List<Suggestion> suggestions = builder.GetSuggestions();
            Assert.AreEqual(1, suggestions.FindAll(x => x.name == "Sausalito").Count);
		}
    }
}
