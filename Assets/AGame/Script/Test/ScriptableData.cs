using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class ScriptableData : ScriptableObject
{
    [ReadOnly]
    public int A;
    [ReadOnly]
    public string B;
    [ReadOnly]
    public float C;
    
    public List<int> D = new List<int>();
    
    public Sprite Sprite;
}