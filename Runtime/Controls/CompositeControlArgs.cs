using WindowsSystem.Events;

namespace WindowsSystem.Controls
{
    public class CompositeControlArgs : ControlBaseArgs
    {
        public IControlFactory ControlFactory { get; }

        protected CompositeControlArgs(IControlFactory controlFactory, 
            IEventsStore eventsStore) : base(eventsStore)
        {
            ControlFactory = controlFactory;
        }
    }
}