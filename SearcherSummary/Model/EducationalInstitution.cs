﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearcherSummary.Model
{
    /// <summary>
    /// Место образования
    /// </summary>
    public class EducationalInstitution : EntityBase<int>
    {
        /// <summary>
        /// Начало 
        /// </summary>
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// Окончание 
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Наименование учебного заведения
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Форма обученяи
        /// </summary>
        public string Form { get; set; }
    }
}
