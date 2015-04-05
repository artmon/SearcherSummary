using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearcherSummary.Contracts;
using SearcherSummary.Model;

namespace SearcherSummary.DataAccess
{
    public class DataAccessService : IDataAccessService
    {
        public void SaveResumes(List<Resume> resumes)
        {
            var idsOnSite = resumes.Select(x => x.IdOnSite).ToList();

            using (var db = new SearcherSummaryContext())
            {
                var existsIdsOnSite = db.Resume.Where(r => idsOnSite.Contains(r.IdOnSite)).Select(r => r.IdOnSite);
                var addResumes = resumes.Where(r => !existsIdsOnSite.Contains(r.IdOnSite)).ToList();

                db.Resume.AddRange(addResumes);
                db.SaveChanges();
            }
        }

        public List<Resume> GetAllResumes()
        {
            using (var db = new SearcherSummaryContext())
            {
                return db.Resume.Include("Person").ToList();
            }
        }


        public void InsertOrUpdateResumes(List<Resume> resumes)
        {
            using (var db = new SearcherSummaryContext())
            {
                foreach (var resume in resumes)
                {
                    db.Entry(resume).State = resume.Id == 0 ?
                                  EntityState.Added :
                                  EntityState.Modified; 
                }

                db.SaveChanges();
            }
        }

        public List<Resume> GetAllResumeByFilter(string filter)
        {
            using (var db = new SearcherSummaryContext())
            {
                return
                    db.Resume.Where(
                        r =>
                            r.Title != null && r.Title.Contains(filter))
                        .Include("Person")
                        .ToList();
            }
        }

    }
}
