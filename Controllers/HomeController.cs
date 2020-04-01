using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment.Models;
using System.Net.Http;
using System.Data;
using Assignment.DAL;
using Microsoft.AspNetCore.Http;

namespace Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public async Task<ActionResult> Index()
        {
            //string apiUrl = "http://dev1-sample.azurewebsites.net/properties.json";
            PropertyList newPropertyList = new PropertyList();
            IEnumerable<Property> propertyList = new List<Property>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Utility.GetAPIURL());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(Utility.GetAPIURL());
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    newPropertyList = Newtonsoft.Json.JsonConvert.DeserializeObject<PropertyList>(data);
                    foreach (var property in newPropertyList.Properties)
                    {
                        propertyList = newPropertyList.Properties.ToList();
                    }
                }


            }
            return View(propertyList);

        }
     
        public ActionResult Save(string address, int yearbuilt, decimal listPrice, decimal monthlyRent, decimal gross)
        {
            PropertyData newProp = new PropertyData();
            newProp.Address = address;
            newProp.YearBuilt = yearbuilt;
            newProp.ListPrice = listPrice;
            newProp.MonthlyRent = monthlyRent;
            newProp.GrossYield = gross;

            UtilityMethods newUtilityMethod = new UtilityMethods();
            bool status = newUtilityMethod.AddProperty(newProp);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
