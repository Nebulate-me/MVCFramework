using WindowsSystem.ScreensController;

namespace WindowsSystem
{
    public interface IController
    {
        ScreenType Type { get; }
        ControllerState State { get; }
        void AddView(IScreenView view);
        void AddOpenParams(IScreenParams openParams);
        void Activate();
        void Deactivate();
        void Hide();
        void Close();
    }
}