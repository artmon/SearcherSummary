using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearcherSummary.Contracts;
using SearcherSummary.Helpers;
using SearcherSummary.Model;

namespace SearcherSummary.BusinessLogic
{
    public class ResumeService : IResumeService
    {
        #region Consts

        private static readonly string MALE = "male";

        private static readonly string FEMALE = "female";

        #endregion Consts 

        #region Fields


        #endregion Fields

        #region Properties

        public dynamic CurrentResume { get; set; }

        public int? Id 
        {
            get { return CurrentResume.id; }
        }

        public decimal? SalaryRub
        {
            get { return CurrentResume.wanted_salary_rub; }
        }

        public string Fio
        {
            get
            {
                if (CurrentResume.contact != null)
                {
                    return CurrentResume.contact.name;
                }

                return null;
            }
        }

        public string Locations
        {
            get
            {
                if (CurrentResume.contact != null && CurrentResume.contact.city != null)
                {
                    return CurrentResume.contact.city.title;
                }

                return null;
            }
        }

        public int? Age
        {
            get { return CurrentResume.age; }
        }

        public string Title
        {
            get { return CurrentResume.header; }
        }

        public string Url
        {
            get { return CurrentResume.url; }
        }

        public string PersonalInfo
        {
            get { return CurrentResume.personal_qualities; }
        }

        public string Skills
        {
            get { return CurrentResume.skills; }
        }

        public DateTime? Birthday
        {
            get { return ResumeHelper.ParseDateTime(CurrentResume.birthday); }
        }

        public DateTime? AddDate
        {
            get { return ResumeHelper.ParseDateTime(CurrentResume.add_date); }
        }

        public DateTime? ModDate
        {
            get { return ResumeHelper.ParseDateTime(CurrentResume.mod_date); }
        }

        public GenderTypes GenderType
        {
            get
            {
                var genderType = CurrentResume.sex as string;
                
                switch (genderType)
                {
                    case  "male": 
                        return  GenderTypes.Male;
                    case "female":
                        return GenderTypes.Female;
                    default:
                        return GenderTypes.Unknown;
                }
            }
        }


        #endregion Properties


        public List<Resume> ParseResume(dynamic resumesJson)
        {
            List<Resume> result = new List<Resume>();
            Resume resume;
            Person person;

            foreach (var resumeJson in resumesJson.resumes)
            {
                resume = new Resume();
                CurrentResume = resumeJson;

                resume.IdOnSite = Id;
                resume.Salary = SalaryRub;
                resume.Title = Title;
                resume.Url = Url;
                resume.Skills = Skills;
                resume.AddDate = AddDate;
                resume.ModDate = ModDate;

                person = new Person();
                person.Fio = Fio;
                person.Age = Age;
                person.PersonalInfo = PersonalInfo;
                person.Birthday = Birthday;
                person.GenderType = GenderType;
                person.Locations = Locations;
                resume.Person = person;

                result.Add(resume);
            }

            return result;
        }


    }
}
