﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DAL.Models
{
    
        public static class DatabaseHelper
        {
            public static string GetConnectionString()
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
                string connectionString = builder.Build().GetConnectionString("EventDb");
                return connectionString;
            }
        }
    
}
