using System.Configuration;

namespace SearcherSummary.Common.Helpers
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
