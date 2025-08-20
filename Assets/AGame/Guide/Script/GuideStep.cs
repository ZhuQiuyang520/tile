using System;
using UnityEngine;

public class GuideStep : MonoBehaviour
{
    public int StepId;

    private event Action<int> OnStep;

    public void Step()
    {
        OnStep?.Invoke(StepId);
    }

    public void AddListener(Action<int> listener)
    {
        OnStep += listener;
    }
    
    public void RemoveListener(Action<int> listener)
    {
        OnStep -= listener;
    }

    private void OnDestroy()
    {
        OnStep = null;
    }
}