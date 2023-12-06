using System;
using System.Collections.Generic;
using System.Linq;
using MVCFramework.View;
using UnityEngine;

namespace MVCFramework.ScreensController
{
    [Serializable]
    public class ScreenTypeToView
    {
        public string Type;
        public GameObject View;
    }

    public class ScreensRegister : MonoBehaviour, IScreensRegister
    {
        [SerializeField] private List<ScreenTypeToView> views;

        private Dictionary<string, IScreenView> screenTypesToViews;

        private void Awake()
        {
            screenTypesToViews = views.ToDictionary(
                it => it.Type,
                it => it.View.GetComponent<IScreenView>()
            );
        }

        public IScreenView GetView(string screenType)
        {
            return screenTypesToViews[screenType];
        }
    }
}