using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearcherSummary.Helpers;
using SearcherSummary.Model;

namespace SearcherSummary.Contracts
{
    public interface ISearchService
    {
        void Search(string url, Action<int> setProgress);

        List<Resume> GetAllResume();

        List<Resume> GetAllResumeByFilter(ResumeSearchParameters filter);
    }
}
