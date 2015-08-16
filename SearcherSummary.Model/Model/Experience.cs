using System.Collections.Generic;

namespace SearcherSummary.Model.Model
{
    /// <summary>
    /// Опыт работы
    /// </summary>
    public class Experience: EntityBase<int>
    {
        /// <summary>
        /// Опыт работы
        /// </summary>
        public string TimeWork { get; set; }

        /// <summary>
        /// Стаж работы 
        /// </summary>
        public string ExperienceLength { get; set; }

        /// <summary>
        /// Где работал
        /// </summary>
        public List<WorkPlace> WorkPlaces { get; set; }
    }
}
