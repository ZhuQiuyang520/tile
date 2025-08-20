using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

public class TextureInfos : ScriptableObject
{
    public List<Texture> textures;
    
    [Button(ButtonSizes.Gigantic), GUIColor(0, 1, 0)]
    public void SaveTextures()
    {
        for (int i = 0; i < textures.Count; i++)
        {
            ADebug.Log($"texture name: {textures[i].name}");
        }

        AssetDatabase.DeleteAsset("Assets/Resources/AGame/Configs/TextureInfos.asset");
        AssetDatabase.CreateAsset(this, "Assets/Resources/AGame/Configs/TextureInfos.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}