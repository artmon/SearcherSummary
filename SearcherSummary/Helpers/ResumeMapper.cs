using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearcherSummary.Model;

namespace SearcherSummary.Helpers
{
    public static class ResumeMapper
    {
        public static Resume ConvertToResume(ShortResume shortResume)
        {
            var result = new Resume();

            result.Content = shortResume.ResumeView;
            result.AddDate = shortResume.PublicateDate;
            result.Url = shortResume.ReferenceOnFullVersion;

            return result;
        }
    }
}
