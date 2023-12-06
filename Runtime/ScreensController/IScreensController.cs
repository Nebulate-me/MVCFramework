using MVCFramework.Controller;

namespace MVCFramework.ScreensController
{
    public interface IScreensController
    {
        void Open(string screenType, IScreenParams openParams = null);
    }
}