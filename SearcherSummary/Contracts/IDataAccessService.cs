using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearcherSummary.Helpers;
using SearcherSummary.Model;

namespace SearcherSummary.Contracts
{
    public interface IDataAccessService
    {
        void SaveResumes(List<Resume> resumes);

        void InsertOrUpdateResumes(List<Resume> resumes);

        List<Resume> GetAllResumes();

        List<Resume> GetAllResumeByFilter(ResumeSearchParameters filter);

    }
}
