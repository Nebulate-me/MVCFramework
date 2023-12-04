using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WindowsSystem.ScreensController
{
    [Serializable]
    public class ScreenTypeToView
    {
        public ScreenType Type;
        public GameObject View;
    }

    public class ScreensRegister : MonoBehaviour, IScreensRegister
    {
        [SerializeField] private List<ScreenTypeToView> views;

        private Dictionary<ScreenType, IScreenView> screenTypesToViews;

        private void Awake()
        {
            screenTypesToViews = views.ToDictionary(
                it => it.Type,
                it => it.View.GetComponent<IScreenView>()
            );
        }

        public IScreenView GetView(ScreenType screenType)
        {
            return screenTypesToViews[screenType];
        }
    }
}