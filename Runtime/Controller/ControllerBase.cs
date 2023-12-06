using System;
using System.Collections.Generic;
using DITools;
using MVCFramework.Controls;
using MVCFramework.Events;
using MVCFramework.Models;
using MVCFramework.View;
using UnityEngine.Events;
using Zenject;

namespace MVCFramework.Controller
{
    public abstract class ControllerBase<TView, TStore> : IController, IContainerConstructable where TView : IScreenView where TStore : IViewStore
    {
        protected readonly IControlFactory controlFactory;
        private readonly IEventsStore eventsStore;
        
        private readonly LinkedList<IControl> controls = new LinkedList<IControl>();
        protected readonly TStore ViewStore;
        protected TView View;

        protected IScreenParams OpenParams = null;

        protected ControllerBase(ControllerBaseArgs args, TStore viewStore)
        {
            controlFactory = args.ControlFactory;
            eventsStore = args.EventsStore;
            ViewStore = viewStore;
        }

        public abstract string Type { get; }

        public ControllerState State { get; private set; } = ControllerState.NotInitialized;

        public void AddView(IScreenView view)
        {
            View = (TView) view;
        }

        public void AddOpenParams(IScreenParams openParams)
        {
            OpenParams = openParams;
        }

        public virtual void Activate()
        {
            if (State is ControllerState.NotInitialized || State is ControllerState.Inactive)
                ViewStore.Activate(OpenParams);

            if (State == ControllerState.NotInitialized)
            {
                CreateControls();
                State = ControllerState.Inactive;
            }

            if (State == ControllerState.Inactive)
            {
                OnActivate();
                OnBindControls();
                ActivateControls();
                OnControlsActivated();
            }

            if (State == ControllerState.Hidden)
            {
                ViewStore.OnShow();
                OnShow();
            }

            State = ControllerState.Active;

            View.Show();
        }

        protected virtual void OnControlsActivated()
        {
            
        }

        public virtual void Deactivate()
        {
            if (State is ControllerState.NotInitialized || State is ControllerState.Inactive) return;
            
            ViewStore.Deactivate();
            OnDeactivate();
            DeactivateControls();
            State = ControllerState.Inactive;
            // OpenParamsEntity = default;

            View.Hide();
        }

        public void Hide()
        {
            if (State != ControllerState.Active) return;
            
            OnHide();
            State = ControllerState.Hidden;
        }

        public void Close()
        {
            Deactivate();
        }

        protected virtual void CreateControls()
        {
        }

        protected T CreateControl<T>(IControlProps controlProps = null, bool manualControl = false) where T : IControl
        {
            var control = controlFactory.Create<T>();
            control.SetLifecycleMode(manualControl);
            control.SetProps(controlProps);
            controls.AddLast(control);
            return control;
        }

        protected T SpawnControl<T>(IControlProps controlProps = null) where T : IPoolableControl
        {
            var control = controlFactory.Spawn<T>();
            control.SetProps(controlProps);
            controls.AddLast(control);
            return control;
        }

        private void ActivateControls()
        {
            foreach (var control in controls)
                if (!control.IsManualLifecycleMode)
                    control.Activate();
        }

        private void DeactivateControls()
        {
            List<IControl> poolableControls = null;
            foreach (var control in controls)
            {
                OnBeforeChildControlDeactivated(control);
                if (!control.IsManualLifecycleMode) 
                    control.Deactivate();

                if (!(control is IPoolableControl poolableControl)) continue;
                
                controlFactory.Despawn(poolableControl);
                poolableControls ??= ListPool<IControl>.Instance.Spawn();
                poolableControls.Add(control);
            }

            if (poolableControls == null) return;
            
            foreach (var poolableControl in poolableControls) 
                controls.Remove(poolableControl);
            ListPool<IControl>.Instance.Despawn(poolableControls);
        }

        protected void RemoveControl(IControl control)
        {
            if (controls.Remove(control))
                DeactivateControl(control);
        }

        private void DeactivateControl(IControl control)
        {
            OnBeforeChildControlDeactivated(control);
            if (!control.IsManualLifecycleMode) 
                control.Deactivate();

            if (!(control is IPoolableControl poolableControl)) 
                return;

            controlFactory.Despawn(poolableControl);
        }

        protected virtual void OnShow()
        {
        }

        protected virtual void OnActivate()
        {
            SubscribeEvents();
        }

        protected virtual void OnBindControls()
        {
        }

        protected virtual void OnDeactivate()
        {
            UnsubscribeEvents();
        }

        protected virtual void OnHide()
        {
        }

        protected virtual void OnBeforeChildControlDeactivated(IControl control)
        {
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

        protected virtual void UnsubscribeEvents()
        {
            eventsStore.Unsubscribe(this);
        }
    }
}