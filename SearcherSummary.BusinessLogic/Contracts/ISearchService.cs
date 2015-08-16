using System;
using System.Collections.Generic;
using SearcherSummary.Common.Helpers;
using SearcherSummary.Model;
using SearcherSummary.Model.Model;

namespace SearcherSummary.BusinessLogic.Contracts
{
    public interface ISearchService
    {
        void Search(string url, Action<int> setProgress);

        List<Resume> GetAllResume();

        List<Resume> GetAllResumeByFilter(ResumeSearchParameters filter);
    }
}
