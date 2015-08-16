namespace SearcherSummary.Model.Model
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
