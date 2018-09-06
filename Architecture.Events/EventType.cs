namespace Architecture.Events
{
    /// <summary>
    /// Описыват тип промежуточного события
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// Блокировка зависимых лукапов на время валидации
        /// </summary>
        Blocking = 0,

        /// <summary>
        /// Валидация действия в связанных сервисах
        /// </summary>
        Validating = 1,

        /// <summary>
        /// Выполняется действие, лукапы обновляются в связанных сервисах
        /// </summary>
        Acting = 2,

        /// <summary>
        /// Снятие блокировки с лукапов в связанных сервисах из-за ошибки в одном из них
        /// </summary>
        Releasing = 3
    }
}