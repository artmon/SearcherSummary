using System.Collections.Generic;

namespace SearcherSummary.Model.Model
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
