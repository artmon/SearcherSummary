using System.Collections.Generic;
using SearcherSummary.Model;
using SearcherSummary.Model.Model;

namespace SearcherSummary.BusinessLogic.Contracts
{
    public interface IResumeService
    {
        List<Resume> ParseResume(dynamic resumesJson);
    }
}
