using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearcherSummary.Model
{
    /// <summary>
    /// Базовый класс модели
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityBase<T>
    {
        public T Id { get; set; }
    }
}
