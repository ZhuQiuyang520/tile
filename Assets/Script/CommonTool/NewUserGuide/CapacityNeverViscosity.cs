using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 事件渗透
/// </summary>
public class CapacityNeverViscosity : MonoBehaviour, ICanvasRaycastFilter
{
    private Image CobaltLabor;
    public void LayIndoorLabor(Image target)
    {
        CobaltLabor = target;
    }
    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        if (CobaltLabor == null)
        {
            return true;
        }
        return !RectTransformUtility.RectangleContainsScreenPoint(CobaltLabor.rectTransform, sp, eventCamera);
    }
}