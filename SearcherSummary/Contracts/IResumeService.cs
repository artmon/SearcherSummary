using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearcherSummary.Model;

namespace SearcherSummary.Contracts
{
    public interface IResumeService
    {
        List<Resume> ParseResume(dynamic resumesJson);
    }
}
