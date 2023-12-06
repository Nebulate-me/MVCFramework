using System.Collections.Generic;

namespace MVCFramework.Controls
{
    public abstract class CompositeControl<TView, TViewModel, TModel> : ControlBase<TView, TViewModel, TModel>
        where TView : IControlView<TViewModel>
        where TModel: TViewModel
    {
        private readonly LinkedList<IControl> controls = new LinkedList<IControl>();
        private readonly IControlFactory controlFactory;

        protected CompositeControl(CompositeControlArgs args) : base(args)
        {
            controlFactory = args.ControlFactory;
        }
        
        protected T CreateControl<T>(IControlProps controlProps = null) where T : IControl
        {
            var control = controlFactory.Create<T>();
            control.SetProps(controlProps ?? Props);
            controls.AddLast(control);
            return control;
        }     
        
        protected T SpawnControl<T>(IControlProps controlProps = null) where T : IPoolableControl
        {
            var control = controlFactory.Spawn<T>();
            control.SetProps(controlProps ?? Props);
            controls.AddLast(control);
            return control;
        }        

        protected virtual void CreateControls()
        {
        }
        
        protected virtual void OnDeactivated()
        {
        }

        public override void Activate()
        {
            CreateControls();
            foreach (var control in controls)
                control.Activate();

            base.Activate();
        }

        public override void Deactivate()
        {
            base.Deactivate();

            foreach (var control in controls) 
                DeactivateChildControl(control);

            controls.Clear();
            OnDeactivated();
        }

        private void DeactivateChildControl(IControl control)
        {
            OnBeforeChildControlDeactivated(control);
            control.Deactivate();

            if (control is IPoolableControl poolableControl) 
                controlFactory.Despawn(poolableControl);
        }

        protected void RemoveChildControl(IControl control)
        {
            if (controls.Remove(control))
                DeactivateChildControl(control);
        }
        
        protected virtual void OnBeforeChildControlDeactivated(IControl control) { }
    }

    public abstract class CompositeControl<TView, TModel> : CompositeControl<TView, TModel, TModel>
        where TView : IControlView<TModel>
    {
        protected CompositeControl(CompositeControlArgs args) : base(args)
        {
        }
    }
}