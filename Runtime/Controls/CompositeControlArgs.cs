using MVCFramework.Events;

namespace MVCFramework.Controls
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