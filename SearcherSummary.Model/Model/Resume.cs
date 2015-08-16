using System;

namespace SearcherSummary.Model.Model
{
    /// <summary>
    /// Резюме
    /// </summary>
    public class Resume : EntityBase<int>
    {
        /// <summary>
        /// HTML контент резюме
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Дата добавления
        /// </summary>
        public DateTime? AddDate { get; set; }

        /// <summary>
        /// Дата модификации
        /// </summary>
        public DateTime? ModDate { get; set; }

        /// <summary>
        /// Id на сайте
        /// </summary>
        public int? IdOnSite { get; set; }

        /// <summary>
        /// Относительная ссылка на резюме
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Человек
        /// </summary>
        public Person Person { get; set; }

        /// <summary>
        /// Информация об резюме (добавлено, обновлено, количество просмотров)
        /// </summary>
        public string ResumeInfo { get; set; }

        /// <summary>
        /// Название резюме
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// з/п
        /// </summary>
        public decimal? Salary { get; set; }

        /// <summary>
        /// Тип работы (Удаленная, полная и т.п.)
        /// </summary>
        public string WorkType { get; set; }

        /// <summary>
        /// Опыт работы
        /// </summary>
        public Experience Experience { get; set; }

        /// <summary>
        /// Ключевые навыки
        /// </summary>
        public string Skills { get; set; }

        /// <summary>
        /// Образование
        /// </summary>
        public Education Education { get; set; }

        /// <summary>
        /// Дополнительная информация
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Возможность переезда
        /// </summary>
        public bool? MayMove { get; set; }
    }
}
