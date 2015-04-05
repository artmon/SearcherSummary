using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearcherSummary.Helpers
{
    public static class Configuration
    {
        public static string DefaultUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["DefaultUrl"];
            }
        }

        public static string RootOfTheSite
        {
            get
            {
                return ConfigurationManager.AppSettings["RootOfTheSite"];
            }
        }

    }
}
