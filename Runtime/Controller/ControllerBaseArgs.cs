using DITools;
using MVCFramework.Controls;
using MVCFramework.Events;

namespace MVCFramework.Controller
{
    public class ControllerBaseArgs: IContainerConstructable
    {
        public IControlFactory ControlFactory { get; }
        public IEventsStore EventsStore { get; }

        public ControllerBaseArgs(IControlFactory controlFactory, IEventsStore eventsStore)
        {
            ControlFactory = controlFactory;
            EventsStore = eventsStore;
        }
    }
}