using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScrptableTest : MonoBehaviour
{
    private void Start()
    {
#if UNITY_EDITOR
        ScriptableData data = ScriptableData.CreateInstance<ScriptableData>();
        data.A = 1;
        data.B = "123";
        data.C = 1.0f;
        data.D = new List<int>();
        data.D.Add(1);
        data.D.Add(2);
        data.D.Add(3);
        data.Sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/AGame/Art/UI/icon/ICON(512).jpg");
        AssetDatabase.CreateAsset(data, "Assets/Resources/AGame/Configs/ScriptableData.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
#endif
    }
}