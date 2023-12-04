using System.Collections.Generic;
using System.Linq;
using DITools;

namespace WindowsSystem.ScreensController
{
    public class ScreensController : IScreensController, IContainerConstructable
    {
        private readonly Dictionary<ScreenType, IController> controllers;
        private readonly IScreensRegister screensRegister;

        public ScreensController(List<IController> controllers, IScreensRegister screensRegister)
        {
            this.controllers = controllers.ToDictionary(it => it.Type);
            this.screensRegister = screensRegister;
        }

        public void Close(ScreenType screenType)
        {
            var controller = controllers[screenType];
            var view = screensRegister.GetView(screenType);
            
            controller.Close();
            view.Hide(); // Do we need that?
        }

        public void Open(ScreenType screenType, IScreenParams openParams = null)
        {
            var controller = controllers[screenType];
            var view = screensRegister.GetView(screenType);

            controller.AddView(view);
            controller.AddOpenParams(openParams);
            controller.Activate();
        }
    }
}