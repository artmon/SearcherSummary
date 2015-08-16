using System.Collections.Generic;
using SearcherSummary.Common.Helpers;
using SearcherSummary.Model;
using SearcherSummary.Model.Model;

namespace SearcherSummary.DataAccess.Contracts
{
    public interface IDataAccessService
    {
        void SaveResumes(List<Resume> resumes);

        void InsertOrUpdateResumes(List<Resume> resumes);

        List<Resume> GetAllResumes();

        List<Resume> GetAllResumeByFilter(ResumeSearchParameters filter);

    }
}
