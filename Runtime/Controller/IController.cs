using MVCFramework.View;

namespace MVCFramework.Controller
{
    public interface IController
    {
        string Type { get; }
        ControllerState State { get; }
        void AddView(IScreenView view);
        void AddOpenParams(IScreenParams openParams);
        void Activate();
        void Deactivate();
        void Hide();
        void Close();
    }
}