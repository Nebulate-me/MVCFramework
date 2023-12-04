using DITools;
using WindowsSystem.Events;

namespace WindowsSystem.Controls
{
    public class ControlBaseArgs: IContainerConstructable
    {
        protected ControlBaseArgs(IEventsStore eventsStore)
        {
            EventsStore = eventsStore;
        }

        public IEventsStore EventsStore { get; }
    }
}