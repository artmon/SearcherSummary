using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearcherSummary.Helpers
{
    public static class ResumeHelper
    {
        public static string ResolveAbsoluteUrl(string relativeUrl)
        {
            return Configuration.RootOfTheSite + relativeUrl;
        }


        public static DateTime? ParseDateTime(dynamic dateTimeJson)
        {
            if (dateTimeJson == null)
            {
                return null;
            }

            if (dateTimeJson.Value is DateTime)
            {
                return dateTimeJson.Value;
            }

            DateTime birthday;
            if (DateTime.TryParse(dateTimeJson.Value, out birthday))
            {
                return birthday;
            }

            return null;
        }

    }



}
