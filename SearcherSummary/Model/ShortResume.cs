using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearcherSummary.Model
{
    public class ShortResume: EntityBase<string>
    {
        public DateTime? PublicateDate { get; set; }

        public string ReferenceOnFullVersion { get; set; }

        public string ResumeView { get; set; }
    }
}
