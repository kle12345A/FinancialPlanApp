using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Common
{
    public static class Constants
    {


        public static IConfiguration CONFIGURATION = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .Build();

        public static string ISSUER = CONFIGURATION["JWT:Issuer"];
        public static string AUDIENCE = CONFIGURATION["JWT:Audience"];
        public static string SECRET_KEY = CONFIGURATION["JWT:SecretKey"];
        public static int EXPIRES = CONFIGURATION["JWT:Expires"].GetIntFromString();

        public static string Unauthorized = "401";
        public static string NotFound = "404";
        public static string UnprocessableEntity = "422";
        public static string BadRequest = "400";
    }
}
