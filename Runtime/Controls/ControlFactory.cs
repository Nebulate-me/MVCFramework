using System;
using System.Collections.Generic;
using DITools;
using Zenject;

namespace MVCFramework.Controls
{
    public class ControlFactory : IControlFactory, IContainerConstructable
    {
        private readonly IDictionary<Type, Stack<IControl>> pools = new Dictionary<Type, Stack<IControl>>();
        private readonly DiContainer diContainer;

        public ControlFactory(DiContainer diContainer)
        {
            this.diContainer = diContainer;
        }

        public T Create<T>() where T : IControl
        {
            return diContainer.Resolve<T>();
        }
        
        public TControl Spawn<TControl>() where TControl : IPoolableControl
        {
            var type = typeof(TControl);

            var pool = GetPool(type);

            var control = pool.Count > 0
                ? (TControl) pool.Pop()
                : Create<TControl>();
                
            control.OnSpawned();
            
            return control;
        }
        
        public void Despawn<TControl>(TControl control) where TControl : IPoolableControl
        {
            var pool = GetPool(control.GetType());
            control.OnDespawned();
            pool.Push(control);
        }

        private Stack<IControl> GetPool(Type type)
        {
            if (pools.TryGetValue(type, out var pool)) return pool;
            
            pool = new Stack<IControl>();
            pools.Add(type, pool);
            return pool;
        }
    }
}