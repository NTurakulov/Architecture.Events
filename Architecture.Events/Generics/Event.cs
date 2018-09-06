using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Architecture.Events.Generics
{
    /// <summary>
    /// Промежуточное событие - один из этапов 
    /// </summary>
    public class Event<T, TRoot, TResponse> : Event
        where TRoot : EventRoot
        where TResponse : EventResponse
    {
        [NotMapped]
        public T Entity { get; set; }

        [ForeignKey(nameof(RootId))]
        public TRoot Root { get; set; }

        /// <summary>
        /// Ответы других сервисов на это событие
        /// </summary>
        [InverseProperty("Event")]
        public ICollection<TResponse> Responseses { get; set; }

        /// <summary>
        /// Is event lifecycle finished
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Current event status
        /// </summary>
        public EventStatus Status { get; set; }
    }
}