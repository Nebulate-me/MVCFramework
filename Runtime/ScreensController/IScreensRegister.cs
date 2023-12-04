namespace WindowsSystem.ScreensController
{
    public interface IScreensRegister
    {
        IScreenView GetView(ScreenType screenType);
    }
}