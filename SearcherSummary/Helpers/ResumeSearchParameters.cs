using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearcherSummary.Helpers
{
    public class ResumeSearchParameters
    {
        public string  Header { get; set; }

        public decimal? SalaryLower { get; set; }

        public decimal? SalaryUpper { get; set; }
    }
}
