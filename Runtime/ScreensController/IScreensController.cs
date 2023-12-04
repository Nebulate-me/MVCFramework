namespace WindowsSystem.ScreensController
{
    public interface IScreensController
    {
        void Open(ScreenType screenType, IScreenParams openParams = null);
    }
}