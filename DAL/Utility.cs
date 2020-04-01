using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.DAL
{
    public static class Utility
    {
        public static string GetConnectionString()
        {
            //This configuration must come from the configuration file or from appSettings file
            string connString = @"Data Source=RAJ-HOMEPC;Initial Catalog=Assignment;Integrated Security=SSPI;";
            return connString;
        }
        public static string GetAPIURL()
        {
            //This configuration must come from the configuration file or from appSettings file
            string apiUrl = "http://dev1-sample.azurewebsites.net/properties.json";
            return apiUrl;
        }
    }
}
