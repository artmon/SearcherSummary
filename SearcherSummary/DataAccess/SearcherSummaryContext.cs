using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearcherSummary.Model;

namespace SearcherSummary.DataAccess
{
    public class SearcherSummaryContext: DbContext
    {
        public DbSet<Education> Educations { get; set; }

        public DbSet<EducationalInstitution> EducationalInstitutions { get; set; }

        public DbSet<Experience> Experience { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<WorkPlace> WorkPlaces { get; set; }

        public DbSet<Resume> Resume { get; set; }

    }
}
