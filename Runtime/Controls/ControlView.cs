using UnityEngine;

namespace WindowsSystem.Controls
{
    public abstract class ControlView<TModel> : MonoBehaviour, IControlView<TModel>
    {
        private bool isAlive = true;
        public Transform Transform => transform;

        public virtual void Activate(TModel model)
        {
        }

        public virtual void Deactivate()
        {
        }

        public bool IsAlive()
        {
            return isAlive;
        }

        private void OnDestroy()
        {
            isAlive = false;
        }
    }
}