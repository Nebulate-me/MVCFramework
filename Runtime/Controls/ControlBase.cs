using System;
using MVCFramework.Events;
using UnityEngine.Events;

namespace MVCFramework.Controls
{
    public abstract class ControlBase<TView, TViewModel, TModel> : IControl<TView, TModel>
        where TView : IControlView<TViewModel>
        where TModel : TViewModel
    {
        private readonly IEventsStore eventsStore;
        protected TModel Model;
        protected IControlProps Props;
        protected TView View;

        protected ControlBase(ControlBaseArgs args)
        {
            eventsStore = args.EventsStore;
        }

        public bool IsActivated { get; private set; }

        public virtual void Bind(TView view, TModel model)
        {
            View = view;
            Model = model;
        }

        public virtual void Activate()
        {
            if (View == null)
                return;
            View.Activate(Model);

            SubscribeEvents();
            IsActivated = true;
        }

        public void SetLifecycleMode(bool manual)
        {
            IsManualLifecycleMode = manual;
        }

        public virtual void SetProps(IControlProps controlProps = null)
        {
            Props = controlProps;
        }

        public bool IsManualLifecycleMode { get; private set; }

        public virtual void Deactivate()
        {
            UnsubscribeEvents();
            if (View == null)
                return;
            View.Deactivate();

            IsActivated = false;
        }

        public IControlView GetView()
        {
            if (View != null && View.IsAlive())
                return View;
            return default;
        }

        protected void SubscribeEvent(object subscriber, UnityEvent unityEvent, UnityAction handler)
        {
            eventsStore.SubscribeEvent(subscriber, unityEvent, handler);
        }

        protected void SubscribeEvent<T>(object subscriber, UnityEvent<T> unityEvent, UnityAction<T> handler)
        {
            eventsStore.SubscribeEvent(subscriber, unityEvent, handler);
        }
        
        protected void SubscribeEvent<T1, T2>(object subscriber, UnityEvent<T1, T2> unityEvent, UnityAction<T1, T2> handler)
        {
            eventsStore.SubscribeEvent(subscriber, unityEvent, handler);
        }
        
        protected void SubscribeSignal<T>(Action<T> handler)
        {
            eventsStore.SubscribeSignal(this, handler);
        }

        protected virtual void SubscribeEvents()
        {
        }

        protected void UnsubscribeEvents()
        {
            UnsubscribeEvents(this);
        }

        private void UnsubscribeEvents(object owner)
        {
            eventsStore.Unsubscribe(owner);
        }

        public virtual void Rebind(TModel model)
        {
            Model = model;
            Deactivate();
            Activate();
        }

        public void DetachView()
        {
            View = default;
        }
    }

    public abstract class ControlBase<TView, TModel> : ControlBase<TView, TModel, TModel>
        where TView : IControlView<TModel>
    {
        protected ControlBase(ControlBaseArgs args) : base(args)
        {
        }
    }
}