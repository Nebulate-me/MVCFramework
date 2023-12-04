using Zenject;

namespace WindowsSystem.Controls
{
    public interface IPoolableControl : IControl, IPoolable
    {
    }

    public interface IPoolableControl<in TView, in TModel>: IPoolableControl where TView : IControlView
    {
        void Init(TView view, TModel model);
    }
}