using MVCFramework.View;

namespace MVCFramework.ScreensController
{
    public interface IScreensRegister
    {
        IScreenView GetView(string screenType);
    }
}