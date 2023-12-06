using MVCFramework.Controls;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace WindowsSystem.Runtime.Examples.TestScreen.Controls.ButtonControl
{
    public class ButtonControlView : ControlView<ButtonModel>
    {
        [SerializeField] private Button button;

        public UnityEvent OnClick => button.onClick;

        public override void Activate(ButtonModel model)
        {
            base.Activate(model);
            
            SetEnabled(model.IsActive.Value);
        }

        private void SetEnabled(bool isActive)
        {
            button.interactable = isActive;
        }
    }
}