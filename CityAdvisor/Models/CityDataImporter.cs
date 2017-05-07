using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.IO;


namespace CityAdvisor.Models
{
    public class CityDataImporter
    {
        public CityDataImporter()
        {
        }

        public List<City> GetCitiesFromFile(string filePath)
        {
            List<City> cities = new List<City>();

			string line;

			// Read the file and display it line by line.
			using (StreamReader file = new StreamReader(filePath))
			{
                // First line is the headers
                file.ReadLine();

				while ((line = file.ReadLine()) != null)
				{

					char[] delimiters = new char[] { '\t' };
					string[] parts = line.Split(delimiters);
                    City city = GetCityFromStringParts(parts);
                    cities.Add(city);
				}

				file.Close();
			}

            return cities;
        }

		public List<City> GetCitiesFromCsvFile(string filePath)
		{
			List<City> cities = new List<City>();

			string line;

			// Read the file and display it line by line.
			using (StreamReader file = new StreamReader(filePath))
			{
				// First line is the headers
				file.ReadLine();

				while ((line = file.ReadLine()) != null)
				{

					char[] delimiters = new char[] {','};
					string[] parts = line.Split(delimiters);
					City city = GetCityFromStringParts(parts);
					cities.Add(city);
				}

				file.Close();
			}

			return cities;
		}



        City GetCityFromStringParts(string[] parts)
        {
            // Skip wrong cities
            if (parts.GetUpperBound(0) < 4) {
                return new City("", "", "");
            } else {
				string cityName = parts.GetValue(1).ToString();
				string cityAltName = parts.GetValue(3).ToString().Replace('"', ' ').Trim();
				string cityCountry = parts.GetValue(8).ToString();

                double cityLatitude = Convert.ToDouble(parts.GetValue(4));
				double cityLongitude = Convert.ToDouble(parts.GetValue(5));
				City city = new City(cityName, cityAltName, cityCountry);
				city.SetLocation(cityLatitude, cityLongitude);
				return city;   
            }
        }
    }
}
