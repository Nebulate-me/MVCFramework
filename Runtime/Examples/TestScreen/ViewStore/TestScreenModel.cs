using WindowsSystem.Runtime.Examples.TestScreen.Controls.ButtonControl;
using WindowsSystem.Runtime.Examples.TestScreen.Controls.InputControl;

namespace WindowsSystem.Runtime.Examples.TestScreen.ViewStore
{
    public class TestScreenModel
    {
        public ButtonModel TestButtonModel { get; set; } = new();
        public InputModel TestInputModel { get; set; } = new();
    }
}