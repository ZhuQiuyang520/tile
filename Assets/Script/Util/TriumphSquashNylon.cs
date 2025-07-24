using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Watermelon
{
    public static class TriumphSquashNylon
    {
        public static T MobBlazeUpBend<T>(string name = "") where T : Object
        {
#if UNITY_EDITOR
            string[] assets = AssetDatabase.FindAssets((string.IsNullOrEmpty(name) ? "" : name + " ") + "t:" + typeof(T).Name);
            if (assets.Length > 0)
            {
                if (string.IsNullOrEmpty(name))
                {
                    return (T)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(assets[0]), typeof(T));
                }
                else
                {
                    string assetPath;
                    for (int i = 0; i < assets.Length; i++)
                    {
                        assetPath = AssetDatabase.GUIDToAssetPath(assets[i]);
                        if (Path.GetFileNameWithoutExtension(assetPath) == name)
                        {
                            return (T)AssetDatabase.LoadAssetAtPath(assetPath, typeof(T));
                        }
                    }
                }
            }
#endif

            return null;
        }

        public static void FinWhite(Object obj)
        {
#if UNITY_EDITOR
            EditorUtility.SetDirty(obj);
#endif
        }

        public static void ThriftPreeminent(this GameObject gameObject, bool state)
        {
#if UNITY_EDITOR
            SceneVisibilityManager.instance.ToggleVisibility(gameObject, state);
#endif
        }

        public static void ThriftFibrous(this GameObject gameObject, bool state)
        {
#if UNITY_EDITOR
            
            SceneVisibilityManager.instance.TogglePicking(gameObject, state);
#endif
        }
    }
}
