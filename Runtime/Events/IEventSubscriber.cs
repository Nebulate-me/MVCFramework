namespace WindowsSystem.Events
{
    public interface IEventSubscriber
    {
        void Unsubscribe();
        void OnDespawned();
    }
}