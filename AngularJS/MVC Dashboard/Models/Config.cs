using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MVC_Dashboard.Helpers.Config;

namespace MVC_Dashboard.Models
{
    public static class Config
    {
        public static string ConnectionString
        {
            get { return ConfigManager.GetConnectionString("Dashboard"); }
        }
    }
}