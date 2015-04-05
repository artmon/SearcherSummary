using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearcherSummary.Model
{
    /// <summary>
    /// Образование
    /// </summary>
    public class Education: EntityBase<int>
    {
        /// <summary>
        /// уровень образования
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// Места образования
        /// </summary>
        public List<EducationalInstitution> EducationItems { get; set; }
    }
}
