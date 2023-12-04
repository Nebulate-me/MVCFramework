using UnityEngine;

namespace WindowsSystem.Controls
{
    public interface IControlView<in TModel>: IControlView
    {
        void Activate(TModel model);
    }

    public interface IControlView
    {
        Transform Transform { get; }
        void Deactivate();
        bool IsAlive();
    }
}