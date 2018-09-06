using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Architecture.Events
{
    /// <summary>
    /// Описывает ключевое событие в сервисе, которое вызывает каскад промежуточных событий <see cref="Event"/>, для обновления связанных сервисов.
    /// </summary>
    public abstract class EventRoot
    {
        /// <summary>
        /// Root event Id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Current status of root event
        /// </summary>
        public EventType Status { get; set; }

        /// <summary>
        /// Traget entity Id (foreign key)
        /// </summary>
        public Guid EntityId { get; set; }

        /// <summary>
        /// Prev state of target entity as JSON
        /// </summary>
        public string PrevState { get; set; }

        /// <summary>
        /// New state of target entity as JSON
        /// </summary>
        public string NewState { get; set; }

        /// <summary>
        /// Event started at
        /// </summary>
        public DateTimeOffset EmittedAt { get; set; }

        /// <summary>
        /// Event finished at (<see cref="EventType.Complete"/> or <see cref="EventType.Canceling"/>)
        /// </summary>
        public DateTimeOffset FinishedAt { get; set; }

        /// <summary>
        /// Event root emitting service name
        /// </summary>
        public string EmitterName { get; set; }

        /// <summary>
        /// Event root emitting service version
        /// </summary>
        public string EmitterVersion { get; set; }

        /// <summary>
        /// Типы микросервисов, от которых надо получить ответы. НЕ ПУТАТЬ С <see cref="Event.DependencyServiceTypes"/>
        /// </summary>
        public ServiceType DependencyServiceTypes { get; set; }

        /// <summary>
        /// Количество ответов, которое надо получить
        /// </summary>
        [NotMapped]
        public int DependnciesCount
        {
            get
            {
                // https://stackoverflow.com/questions/677204/counting-the-number-of-flags-set-on-an-enumeration
                var types = (long)DependencyServiceTypes;
                var iCount = 0;

                //Loop the value while there are still bits
                while (types != 0)
                {
                    //Remove the end bit
                    types = types & (types - 1);

                    //Increment the count
                    iCount++;
                }

                //Return the count
                return iCount;
            }
        }
    }
}
