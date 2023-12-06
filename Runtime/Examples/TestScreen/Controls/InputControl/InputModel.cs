using MVCFramework.Models;

namespace WindowsSystem.Runtime.Examples.TestScreen.Controls.InputControl
{
    public class InputModel
    {
        public ReactiveProperty<string> Text { get; set; } = new();
    }
}