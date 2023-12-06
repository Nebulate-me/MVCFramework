namespace MVCFramework.Controls
{
    public interface IControl
    {
        bool IsManualLifecycleMode { get; }
        bool IsActivated { get; }
        void Deactivate();
        void Activate();
        void SetLifecycleMode(bool manual);
        void SetProps(IControlProps controlProps = null);
        IControlView GetView();
    }

    public interface IControl<in TView, in TModel> : IControl where TView : IControlView
    {
        void Bind(TView view, TModel model);
    }
}