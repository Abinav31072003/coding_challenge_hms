using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Utility
{
    internal class DataConnectionUtilitycs
    {
        private static IConfiguration iconfiguration;
        static DataConnectionUtilitycs()
        {
            GetAppSettingsFile();
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            iconfiguration = builder.Build();
        }

        public static string GetConnectionString()
        {
            return iconfiguration.GetConnectionString("LocalConnectionString");
        }
    }
}
