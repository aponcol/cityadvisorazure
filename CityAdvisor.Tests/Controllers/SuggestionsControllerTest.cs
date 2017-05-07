using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using CityAdvisor;
using CityAdvisor.Controllers;

namespace CityAdvisor.Tests.Controllers
{
    [TestFixture]
    public class SuggestionsControllerTest
    {
        protected SuggestionsController controller;

        [SetUp]
        public void Init()
        {
            controller = new SuggestionsController();
        }

        [Test]
        public void resultOfIndexIsJsonObject()
        {
			var result = controller.Index();
            Assert.IsInstanceOf(typeof(JsonResult), result);
        }

        //[Test]
        //public void resultWithNoParamsIsEmptySuggestionsArray()
        //{
        //    var result = controller.Index();
        //    var suggestions = result.Data.ToString();

        //    Console.WriteLine(suggestions);

        //    //Assert.IsNull(result.Data.GetType().GetProperty("suggestions"));
        //}

        [Test]
        public void resultOfIndexWithExactMatchIsProperJsonObject()
        {
            var result = controller.Index("Alma");
            Assert.IsNotEmpty(result.Data.ToString());
        }
    }
}
