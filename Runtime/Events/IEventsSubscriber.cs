using System;
using UnityEngine.Events;
using Zenject;

namespace WindowsSystem.Events
{
    public interface IEventsSubscriber: IPoolable
    {
        void Subscribe(UnityEvent unityEvent, UnityAction handler);
        void Subscribe<T>(UnityEvent<T> unityEvent, UnityAction<T> handler);
        void SubscribeSignal<T>(Action<T> handler);
        void Unsubscribe();
    }
}