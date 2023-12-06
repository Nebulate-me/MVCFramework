using MVCFramework.Models;

namespace WindowsSystem.Runtime.Examples.TestScreen.Controls.ButtonControl
{
    public class ButtonModel
    {
        public ReactiveProperty<bool> IsActive { get; set; } = new();
    }
}