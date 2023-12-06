using MVCFramework.Controls;

namespace WindowsSystem.Runtime.Examples.TestScreen.Controls.ButtonControl
{
    public class ButtonControl : ControlBase<ButtonControlView, ButtonModel>
    {
        public ButtonControl(ControlBaseArgs args) : base(args)
        {
        }

        public override void Activate()
        {
            base.Activate();
            
        }
    }
}