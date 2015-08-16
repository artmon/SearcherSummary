namespace SearcherSummary.Model.Model
{
    /// <summary>
    /// Место работы
    /// </summary>
    public class WorkPlace : EntityBase<int>
    {
        /// <summary>
        /// Период работы
        /// </summary>
        public string TimeWork { get; set; }

        /// <summary>
        /// Название организации
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Обязанности, достижения, дополнительная информация
        /// </summary>
        public string Info { get; set; }

    }
}
