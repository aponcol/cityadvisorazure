using System;
using System.Collections.Generic;
using CityAdvisor.Models;
using NUnit.Framework;

namespace CityAdvisor.Tests.Models
{
    [TestFixture]
    public class CityDataImporterTest
    {
        int TotalNumberOfCities = 7237;
        CityDataImporter importer = new CityDataImporter();
        List<City> cities;

        [Test]
        public void GetDataFromTestFileTotalNumberOfCities()
        {
            cities = importer.GetCitiesFromFile("cities_test.txt");
            Assert.AreEqual(10, cities.Count);
        }

        [Test]
        public void FirstCityFromFileIsProperlyCreated()
        {
            cities = importer.GetCitiesFromFile("cities_test.txt");
            City city1 = cities.Find(x => x.name == "Abbotsford");
            string altNameFromFile = "Abbotsford,YXX,Ð\u0090Ð±Ð±Ð¾Ñ‚Ñ\u0081Ñ„Ð¾Ñ€Ð´";
            string countryFromFile = "CA";
            double latitudeFromFile = 49.05798;
            double longitudeFromFile = -122.25257;

            Assert.AreEqual(altNameFromFile, city1.alt_name);
            Assert.AreEqual(countryFromFile, city1.country);
            Assert.AreEqual(latitudeFromFile, city1.location.Latitude);
            Assert.AreEqual(longitudeFromFile, city1.location.Longitude);
        }

		[Test]
        [Ignore]
		public void GetDataFromRealFileTotalNumberOfCities()
		{
			cities = importer.GetCitiesFromFile("cities_canada-usa.tsv");
            Assert.AreEqual(TotalNumberOfCities, cities.Count);
		}
    }
}
