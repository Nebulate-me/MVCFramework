using DITools;
using MVCFramework.Events;

namespace MVCFramework.Controls
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