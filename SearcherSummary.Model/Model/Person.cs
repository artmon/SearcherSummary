using System;

namespace SearcherSummary.Model.Model
{
    /// <summary>
    /// Человек
    /// </summary>
    public class Person : EntityBase<int>
    {
        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// Персональная информация
        /// </summary>
        public string PersonalInfo { get; set; }

        /// <summary>
        /// Место положения
        /// </summary>
        public string  Locations { get; set; }

        /// <summary>
        /// Контакты
        /// </summary>
        public string Contacts { get; set; }

        /// <summary>
        /// День Рождения
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public GenderTypes GenderType { get; set; }
    }
}
