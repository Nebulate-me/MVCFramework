using MVCFramework.Controller;
using WindowsSystem.Runtime.Examples.TestScreen.Controls.ButtonControl;
using WindowsSystem.Runtime.Examples.TestScreen.Controls.InputControl;
using WindowsSystem.Runtime.Examples.TestScreen.View;
using WindowsSystem.Runtime.Examples.TestScreen.ViewStore;

namespace WindowsSystem.Runtime.Examples.TestScreen.Controller
{
    public class TestScreenController : ControllerBase<TestScreenView, TestScreenViewStore>, ITestScreenController
    {
        private ButtonControl testButtonControl;
        private InputControl testInputControl;

        public TestScreenController(ControllerBaseArgs args, TestScreenViewStore viewStore) : base(args, viewStore)
        {
        }

        public override string Type => "TestScreen";

        protected override void CreateControls()
        {
            testButtonControl = CreateControl<ButtonControl>();
            testInputControl = CreateControl<InputControl>();
        }

        protected override void OnBindControls()
        {
            var model = ViewStore.Model;

            testButtonControl.Bind(View.ButtonView, model.TestButtonModel);
            testInputControl.Bind(View.InputView, model.TestInputModel);
        }

        protected override void SubscribeEvents()
        {
            var model = ViewStore.Model;

            SubscribeEvent(this, model.TestInputModel.Text.OnChanged, ViewStore.OnInputChanged);
            SubscribeEvent(this, View.ButtonView.OnClick, ViewStore.ClearInput);

            base.SubscribeEvents();
        }
    }
}