using System;
using UnityEngine;
using UnityEngine.UI;

public class GuidePauperTest : MonoBehaviour
{
    public Button btn1;
    public Button btn2;

    private void Start()
    {
        btn1.onClick.AddListener(() =>
        {
            Debug.Log("btn1");
        });
        
        btn2.onClick.AddListener(() =>
        {
            Debug.Log("btn2");
        });
    }
}