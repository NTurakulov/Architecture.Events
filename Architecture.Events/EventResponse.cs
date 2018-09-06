using Architecture.Events.Exceptions;
using System;

namespace Architecture.Events
{
    /// <summary>
    /// Описывает реакцию связанных сервисов на событие
    /// </summary>
    public class EventResponse
    {
        /// <summary>
        /// Id ответ
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Parent Event Id
        /// </summary>
        public Guid EventId { get; set; }

        /// <summary>
        /// True if operation succeeded and result is positive (validation passed).
        /// False if operation succeeded and result is negative (validation not passed).
        /// Null is operation failed and there is no result (validation failed because of exception).
        /// </summary>
        public bool? Success { get; set; }

        /// <summary>
        /// Exception that caused fail
        /// </summary>
        public ResponseException Exception { get; set; }

        /// <summary>
        /// Responding service name
        /// </summary>
        public ServiceType ResponderName { get; set; }

        /// <summary>
        /// Responding service version
        /// </summary>
        public string ResponderVersion { get; set; }

    }
}