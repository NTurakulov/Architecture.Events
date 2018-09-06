using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Architecture.Events.Generics
{
    /// <summary>
    /// Описывает ключевое событие в сервисе, которое вызывает каскад промежуточных событий <see cref="Event"/>, для обновления связанных сервисов.
    /// </summary>
    /// <typeparam name="T">Target Entity Type</typeparam>
    /// <typeparam name="TEvent"></typeparam>
    public abstract class EventRoot<T, TEvent> : EventRoot
    where TEvent : Event
    {
        /// <summary>
        /// Target entity caused the event
        /// </summary>
        [ForeignKey(nameof(EntityId))]
        public T Entity { get; set; }

        [InverseProperty("Root")]
        public ICollection<TEvent> Events { get; set; }

    }
}
