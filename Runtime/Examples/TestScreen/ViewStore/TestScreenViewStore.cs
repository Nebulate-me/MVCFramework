using MVCFramework.Models;

namespace WindowsSystem.Runtime.Examples.TestScreen.ViewStore
{
    public class TestScreenViewStore : ViewStoreBase<TestScreenModel>
    {
        // This method is called every time screen activated. Use it to fill initial data in model.
        protected override void InitModel()
        {
            
        }

        protected override TestScreenModel CreateModel()
        {
            return new TestScreenModel();
        }

        public void OnInputChanged(string text)
        {
            Model.TestButtonModel.IsActive.Value = text.Length > 0;
        }

        public void ClearInput()
        {
            Model.TestInputModel.Text.Value = "";
        }
    }
}