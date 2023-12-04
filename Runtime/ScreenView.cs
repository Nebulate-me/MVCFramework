using UnityEngine;
using UnityEngine.UI;

namespace WindowsSystem
{
    public class ScreenView : View, IScreenView
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private GraphicRaycaster raycaster;

        public virtual void Hide()
        {
            SetActive(false);
        }

        public virtual void Show()
        {
            SetActive(true);
        }
    }
}