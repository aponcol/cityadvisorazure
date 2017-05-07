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
            cities = importer.GetCitiesFromCsvFile("cities_test_clean_csv.csv");
            Assert.AreEqual(10, cities.Count);
        }

        [Test]
        public void FirstCityFromFileIsProperlyCreated()
        {
            cities = importer.GetCitiesFromCsvFile("cities_test_clean_csv.csv");
            City city1 = cities.Find(x => x.name == "Abbotsford");
            foreach(City cityFromFile in cities) {
                Console.WriteLine("city:" + cityFromFile.name);
            }

            Assert.NotNull(city1);

            string altNameFromFile = "Abbotsford;YXX";
            string countryFromFile = "CA";
            double latitudeFromFile = 49.05798;
            double longitudeFromFile = -122.25257;

            Assert.AreEqual(altNameFromFile, city1.alt_name.Substring(0, 14));
            Assert.AreEqual(countryFromFile, city1.country);
            Assert.AreEqual(latitudeFromFile, city1.location.Latitude);
            Assert.AreEqual(longitudeFromFile, city1.location.Longitude);
        }

		[Test]
		public void GetDataFromRealFileTotalNumberOfCities()
		{
			cities = importer.GetCitiesFromCsvFile("cities_canada-usa_clean_csv.txt");
            Assert.AreEqual(TotalNumberOfCities, cities.Count);
		}

		[Test]
		public void GetDataFromCsvTestFileTotalNumberOfCities()
		{
			cities = importer.GetCitiesFromCsvFile("cities_test_csv.csv");
			Assert.AreEqual(10, cities.Count);
		}
    }
}
