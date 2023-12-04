﻿using UnityEngine;

namespace WindowsSystem
{
    public interface IView
    {
        Transform Transform { get; }
        void SetActive(bool active);
        void SetTransform(Vector3 position, Quaternion rotation);
        // void Init(IEntity entity);
        void Destroy();
    }
}