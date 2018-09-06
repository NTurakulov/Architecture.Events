using Architecture.Events.Generics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Architecture.Events
{
    public static class Extensions
    {
        /// <summary>
        /// Updates state of Event Root
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TRoot"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="root"></param>
        /// <returns></returns>
        public static void UpdateState<TEvent, T, TRoot, TResponse>(this TRoot root)
            where TEvent : Event<T, TRoot, TResponse>, new()
            where TRoot : EventRoot<T, TEvent>
            where TResponse : EventResponse
        {
            if (root.Events == null || root.Events.Count == 0)
                throw new InvalidOperationException("Event steps collection cannot be empty");

            var events = root.Events.OrderBy(e => e.Type).ToArray();
            var @event = events.LastOrDefault();

            if (@event == null)
                throw new Exception("Imposible exception");

            // собрали все ответы?
            if (@event.Responseses.Count < root.DependnciesCount) // еще нет
            {
                // ничего не делаем, ждем дальше пока не придут все ответы
                @event.IsCompleted = false; // текущий шаг незавершен
                @event.Status = EventStatus.InProgress; // действие в процессе
                return;
            }

            @event.IsCompleted = true;

            if (@event.Responseses.All(r => r.Success == true))
                @event.Status = EventStatus.Succeeded;

            if (@event.Responseses.Any(r => r.Success == false))
                @event.Status = EventStatus.Warning;

            if (@event.Responseses.Any(r => r.Success == null))
                @event.Status = EventStatus.Failed;
        }

        public static TEvent GetNextEvent<TEvent, T, TRoot, TResponse>(this TRoot root)
            where TEvent : Event<T, TRoot, TResponse>, new() where TRoot : EventRoot<T, TEvent> where TResponse : EventResponse
        {
            var @event = root.Events.OrderBy(e => e.Type).Last();

            switch (@event.Type)
            {
                case EventType.Blocking:
                    if (@event.Status == EventStatus.Succeeded)
                        return BuildNextEvent<TEvent, T, TRoot, TResponse>(root, EventType.Validating);

                    return BuildNextEvent<TEvent, T, TRoot, TResponse>(root, EventType.Releasing);
                case EventType.Validating:
                    if (@event.Status == EventStatus.Succeeded)
                        return BuildNextEvent<TEvent, T, TRoot, TResponse>(root, EventType.Acting);

                    return BuildNextEvent<TEvent, T, TRoot, TResponse>(root, EventType.Releasing);
                default: // дальнейшая обработка состояния - дело микросервиса-подписчика
                    return null;
            }
        }

        private static TEvent BuildNextEvent<TEvent, T, TRoot, TResponse>(TRoot root, EventType type)
            where TEvent : Event<T, TRoot, TResponse>, new() where TRoot : EventRoot<T, TEvent> where TResponse : EventResponse
        {
            var next = new TEvent
            {
                Type = type,
                EmittedAt = DateTime.UtcNow,
                Root = root,
                Entity = root.Entity,
                Id = new Guid(),
                Responseses = new List<TResponse>(),
            };

            root.Status = next.Type; // обновляем статус главного события

            return next;
        }
    }
}