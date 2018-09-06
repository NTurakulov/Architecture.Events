using System.ComponentModel.DataAnnotations.Schema;

namespace Architecture.Events.Generics
{
    /// <summary>
    /// Описывает реакцию связанных сервисов на событие
    /// </summary>
    public class EventResponse<TEvent> : EventResponse
        where TEvent : Event
    {
        [ForeignKey(nameof(EventId))]
        public TEvent Event { get; set; }

    }
}