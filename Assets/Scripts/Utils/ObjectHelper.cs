using UnityEditor;
using UnityEngine;

namespace Utils
{
    public class ObjectHelper
    {
        public static T InstantiateOrPrefab<T>(T original, Transform parent) where T : Object
        {
            if (Application.isPlaying)
            {
                return Object.Instantiate(original, parent);
            }

#if UNITY_EDITOR        
            return PrefabUtility.InstantiatePrefab(original, parent) as T;
#else
            return Object.Instantiate(original, parent);
#endif
        }
    }
}