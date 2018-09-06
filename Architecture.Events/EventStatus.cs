namespace Architecture.Events
{
    /// <summary>
    /// Current Event processing status
    /// </summary>
    public enum EventStatus
    {
        /// <summary>
        /// Event is not copmleted - some dependent sevices haven't responded yet
        /// </summary>
        InProgress = 0,

        /// <summary>
        /// Event is succeeded - all dependent services responded with <see cref="EventResponse.Success"/> equal true
        /// </summary>
        Succeeded = 1,

        /// <summary>
        /// Event is succeeded - some dependent services responded with <see cref="EventResponse.Success"/> equal false
        /// </summary>
        Warning = 2,

        /// <summary>
        /// Event is failed - some dependent services responded with <see cref="EventResponse.Success"/> equal null
        /// </summary>
        Failed = 3,
    }
}