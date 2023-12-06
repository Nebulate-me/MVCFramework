using MVCFramework.Controller;

namespace MVCFramework.Models
{
    public interface IViewStore
    {
        void Activate(IScreenParams openParams = null);
        void OnShow();
        void Deactivate();
    }

    public interface IViewStore<out T>: IViewStore
    {
        T Model { get; }
    }
}