using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

public class OdinWindowTest : OdinEditorWindow
{
    [MenuItem("Tools/OdinWindowTest")]
    public static void ShowWindow()
    {
        var window = GetWindow<OdinWindowTest>();
        window.Show();
    }
    
    [LabelText("学生信息")]
    public List<StudentInfo> StudentInfos = new List<StudentInfo>();

    [LabelText("脚本able数据")]
    public ScriptableData scriptableData;
    
    [Button("保存为Json")]
    public void SaveJson()
    {
        var Dic = new Dictionary<string, StudentInfo>();
        foreach (var item in StudentInfos)
        {
            Dic.Add(item.StudentName, item);
        }
        
        var json = JsonConvert.SerializeObject(Dic, Formatting.Indented);
        File.WriteAllText(Application.dataPath + "/StudentInfo.json", json);
        AssetDatabase.Refresh();
        ADebug.Log("保存成功");
    }
    
    [Button("读取Json")]
    public void LoadJson()
    {
        if (!File.Exists(Application.dataPath + "/StudentInfo.json"))
        {
            ADebug.Error("文件不存在");
            return;
        }
        var json = File.ReadAllText(Application.dataPath + "/StudentInfo.json");
        var Dic = JsonConvert.DeserializeObject<Dictionary<string, StudentInfo>>(json);
        StudentInfos.Clear();
        foreach (var item in Dic)
        {
            StudentInfos.Add(item.Value);
        }
        ADebug.Log("加载成功");
    }
}

[Serializable]
public class StudentInfo
{
    [LabelText("学生姓名")]
    public string StudentName;

    [LabelText("数学成绩")]
    public float MathScore;
}
