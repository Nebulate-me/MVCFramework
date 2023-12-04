namespace WindowsSystem.Controls
{
    public interface IControlFactory
    {
        T Create<T>()  where T: IControl;
        TControl Spawn<TControl>() where TControl : IPoolableControl;
        void Despawn<TControl>(TControl control) where TControl : IPoolableControl;
    }
}