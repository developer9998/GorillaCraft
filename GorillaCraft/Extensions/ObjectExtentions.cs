﻿using UnityEngine;

namespace GorillaCraft.Extensions
{
    public static class ObjectExtentions
    {
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponent<T>();
            return component ? component : gameObject.AddComponent<T>();
        }
    }
}
