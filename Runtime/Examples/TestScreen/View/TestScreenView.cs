using MVCFramework.View;
using UnityEngine;
using WindowsSystem.Runtime.Examples.TestScreen.Controls.ButtonControl;
using WindowsSystem.Runtime.Examples.TestScreen.Controls.InputControl;

namespace WindowsSystem.Runtime.Examples.TestScreen.View
{
    public class TestScreenView : ScreenView
    {
        [SerializeField] private InputControlView inputView;
        [SerializeField] private ButtonControlView buttonView;

        public InputControlView InputView => inputView;
        public ButtonControlView ButtonView => buttonView;
    }
}