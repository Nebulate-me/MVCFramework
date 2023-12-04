using System.Collections.Generic;
using Zenject;

namespace WindowsSystem.Models
{
    [NoReflectionBaking]
    public class ReactiveProperty<T>
    {
        private static readonly IEqualityComparer<T> DefaultEqualityComparer = EqualityComparer<T>.Default;
        private readonly bool changeOnSameValue;
        public readonly ReactivePropertyEvent<T> OnChanged;
        public readonly ExtendedReactivePropertyEvent<T, T> OnBeforeValueChanged;

        private T value;

        public ReactiveProperty(T defaultValue, bool changeOnSameValue = false)
        {
            value = defaultValue;
            OnChanged = new ReactivePropertyEvent<T>();
            OnBeforeValueChanged = new ExtendedReactivePropertyEvent<T, T>();
            this.changeOnSameValue = changeOnSameValue;
        }

        public ReactiveProperty(bool changeOnSameValue = false) : this(default, changeOnSameValue)
        {
        }

        public T Value
        {
            get => value;
            set
            {
                if (!changeOnSameValue && DefaultEqualityComparer.Equals(this.value, value))
                    return;

                OnBeforeValueChanged.Invoke(this.value, value);
                this.value = value;
                OnChanged.Invoke(this.value);
            }
        }

        public void SetSilently(T val)
        {
            value = val;
        }

        public void Reset()
        {
            SetSilently(default);
            OnChanged.RemoveAllListeners();
            OnBeforeValueChanged.RemoveAllListeners();
        }

        public void Touch()
        {
            OnChanged.Invoke(value);
        }
    }
}