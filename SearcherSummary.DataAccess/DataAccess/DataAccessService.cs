using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SearcherSummary.Common.Helpers;
using SearcherSummary.DataAccess.Contracts;
using SearcherSummary.Model;
using SearcherSummary.Model.Model;

namespace SearcherSummary.DataAccess.DataAccess
{
    public class DataAccessService : IDataAccessService, IDisposable
    {
        private SearcherSummaryContext _db;

        public DataAccessService()
        {
            _db = new SearcherSummaryContext();
        }

        public void SaveResumes(List<Resume> resumes)
        {
            var idsOnSite = resumes.Select(x => x.IdOnSite).ToList();

            var existsIdsOnSite = _db.Resume.Where(r => idsOnSite.Contains(r.IdOnSite)).Select(r => r.IdOnSite);
            var addResumes = resumes.Where(r => !existsIdsOnSite.Contains(r.IdOnSite)).ToList();

            _db.Resume.AddRange(addResumes);
            _db.SaveChanges();
        }

        public List<Resume> GetAllResumes()
        {
            return _db.Resume.Include("Person").ToList();
        }

        public void InsertOrUpdateResumes(List<Resume> resumes)
        {
            foreach (var resume in resumes)
            {
                _db.Entry(resume).State = resume.Id == 0 ?
                                EntityState.Added :
                                EntityState.Modified; 
            }

            _db.SaveChanges();
        }

        public List<Resume> GetAllResumeByFilter(ResumeSearchParameters filter)
        {
                return
                    ApplyFilter(filter)
                        .Include("Person")
                        .ToList();
        }


        private IQueryable<Resume> ApplyFilter(ResumeSearchParameters filter)
        {
            var result = _db.Resume.AsQueryable();

            if (filter.Header != null)
            {
                result = result.Where(r => r.Title != null && r.Title.Contains(filter.Header));
            }

            if (filter.SalaryLower.HasValue && filter.SalaryLower > 0)
            {
                result = result.Where(r => r.Salary.HasValue && r.Salary >= filter.SalaryLower);
            }

            if (filter.SalaryUpper.HasValue)
            {
                result = result.Where(r => !r.Salary.HasValue || r.Salary <= filter.SalaryUpper);
            }

            return result;
        }


        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
