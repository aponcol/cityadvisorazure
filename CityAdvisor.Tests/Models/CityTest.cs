using System;
using System.Collections.Generic;
using CityAdvisor.Models;
using NUnit.Framework;
using Geolocation;

namespace CityAdvisor.Tests.Models
{
    [TestFixture]
    public class CityTest
    {
        [Test]
        public void CitiesHaveBasicStringProperties()
        {
            City city1 = new City("New York", "NY", "US");
            Assert.AreEqual("New York", city1.name);
            Assert.AreEqual("NY", city1.alt_name);
            Assert.AreEqual("US", city1.country);
        }

        [Test]
        public void CitiesHaveLocation()
        {
            City city1 = new City("New York", "NY", "US");
            city1.SetLocation(49.05798, -122.25257);
            Assert.AreEqual(49.05798, city1.location.Latitude);
            Assert.AreEqual(-122.25257, city1.location.Longitude);
        }
    }
}
