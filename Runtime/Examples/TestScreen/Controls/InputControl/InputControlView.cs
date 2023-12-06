using MVCFramework.Controls;
using UnityEngine;
using UnityEngine.UI;

namespace WindowsSystem.Runtime.Examples.TestScreen.Controls.InputControl
{
    public class InputControlView : ControlView<InputModel>
    {
        [SerializeField] private InputField input;

        public InputField.OnChangeEvent OnChanged => Input.onValueChanged;

        public InputField Input => input;
    }
}