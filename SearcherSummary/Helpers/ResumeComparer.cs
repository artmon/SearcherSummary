using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearcherSummary.Model;

namespace SearcherSummary.Helpers
{
    public class ResumeComparer : IEqualityComparer<Resume>
    {
        public bool Equals(Resume x, Resume y)
        {
            if (x.IdOnSite == y.IdOnSite)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(Resume obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
