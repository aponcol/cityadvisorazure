using System;
using System.Collections.Generic;
using CityAdvisor.Models;
using NUnit.Framework;
using Geolocation;

namespace CityAdvisor.Tests.Models
{
    [TestFixture]
    public class SuggestionTest
    {
        [Test]
        public void SuggestionsHaveProperValues()
        {
            City city1 = new City("New York", "NY", "US");
			city1.SetLocation(49.05798, -122.25257);

            Suggestion suggestion = new Suggestion(city1, 0.5f);
            Assert.AreEqual("New York", suggestion.name);
            Assert.AreEqual("49.05798", suggestion.latitude);
            Assert.AreEqual("-122.25257", suggestion.longitude);
            Assert.AreEqual(0.5, suggestion.score);
        }
    }
}
