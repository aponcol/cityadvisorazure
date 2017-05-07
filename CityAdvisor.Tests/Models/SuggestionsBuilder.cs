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
        SuggestionsBuilder builder = new SuggestionsBuilder("cities_test.txt");

        [Test]
        public void WhenAPerfectCityNameMatchIsFoundReturnItWithFullWeight()
        {
            builder.cityInput = "Alma";
            List<Suggestion> suggestions = builder.GetSuggestions();
            Assert.AreEqual(1, suggestions.Count);
            foreach(Suggestion suggestion in suggestions) {
                Assert.AreEqual("Alma", suggestion.name);
            }
        }
    }
}
