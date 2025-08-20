using System;
using UnityEngine;
using UnityEngine.UI;

public class GuideTest :MonoBehaviour
{
    public GuideStep step1;
    public GuideStep step2;
    public Button btn1;

    private void Start()
    {
        btn1.onClick.AddListener(() =>
        {
            Debug.Log("btn1 ");
        });

        step1.AddListener(i =>
        {
            Debug.Log("step1 ");
        });

        step2.AddListener(i =>
        {
            Debug.Log("step2 ");
        });
    }
    
}