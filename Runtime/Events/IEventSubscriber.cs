namespace MVCFramework.Events
{
    public interface IEventSubscriber
    {
        void Unsubscribe();
        void OnDespawned();
    }
}