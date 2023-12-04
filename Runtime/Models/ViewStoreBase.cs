namespace WindowsSystem.Models
{
    public abstract class ViewStoreBase<TModel> : IViewStore<TModel>
    {
        private bool isModelUpdated;
        protected IScreenParams OpenParams;

        public virtual TModel Model { get; protected set; }

        protected abstract void InitModel();

        protected abstract TModel CreateModel();

        public void Activate(IScreenParams openParams)
        {
            OpenParams = openParams;
            Model ??= CreateModel();
            InitModel();
        }

        public void OnShow()
        {
            
        }

        public virtual void Deactivate()
        {
        }
    }
}