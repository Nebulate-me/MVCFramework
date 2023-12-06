using MVCFramework.Controls;

namespace WindowsSystem.Runtime.Examples.TestScreen.Controls.InputControl
{
    public class InputControl : ControlBase<InputControlView, InputModel>
    {
        public InputControl(ControlBaseArgs args) : base(args)
        {
        }

        protected override void SubscribeEvents()
        {
            SubscribeEvent(this, Model.Text.OnChanged, View.Input.SetTextWithoutNotify);
            SubscribeEvent(this, View.OnChanged, text => Model.Text.Value = text);
        }
    }
}