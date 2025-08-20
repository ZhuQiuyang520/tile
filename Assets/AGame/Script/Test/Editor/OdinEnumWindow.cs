using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

public class OdinEnumWindow : OdinMenuEditorWindow
{
    [MenuItem("MyEditor/EnumWindow")]
    private static void OpenWindow()
    {
        GetWindow<OdinEnumWindow>().Show();
    }
    
    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();
        tree.Add("GameState", AGameState.Playing);
        tree.Add("StudentInfo", new StudentInfo());
        tree.Add("TextureInfos", ScriptableObject.CreateInstance<TextureInfos>());
        return tree;
    }
}