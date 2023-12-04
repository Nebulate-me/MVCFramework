using DITools;
using WindowsSystem.Controls;
using WindowsSystem.Events;

namespace WindowsSystem
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