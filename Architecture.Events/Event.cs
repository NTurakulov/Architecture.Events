using System;
using System.ComponentModel.DataAnnotations;

namespace Architecture.Events
{
    /// <summary>
    /// Промежуточное событие - один из этапов 
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Id события
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Дата и время, когда это событие было опубликовано
        /// </summary>
        public DateTimeOffset EmittedAt { get; set; }

        /// <summary>
        /// Тип события
        /// </summary>
        public EventType Type { get; set; }

        /// <summary>
        /// Root event Id
        /// </summary>
        public Guid RootId { get; set; }

        /// <summary>
        /// Типы микросервисов, которые ответили. НЕ ПУТАТЬ С <see cref="EventRoot.DependencyServiceTypes"/>
        /// </summary>
        public ServiceType DependencyServiceTypes { get; set; }
    }
}