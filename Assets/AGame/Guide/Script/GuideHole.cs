using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GuideHole : MonoBehaviour, IPointerClickHandler 
{
    private readonly List<RaycastResult> _rawRaycastResults = new List<RaycastResult>();
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Raycast(eventData);
    } 
    
    private void Raycast(PointerEventData eventData) 
    {
        _rawRaycastResults.Clear(); 
        EventSystem.current.RaycastAll(eventData, _rawRaycastResults);
        foreach (var rlt in _rawRaycastResults) 
        { 
            //遮罩层自身需要添加该脚本，否则会导致ExecuteEvents.Execute再次触发遮罩层自身的IPointerClickHandler导致死循环
            if (rlt.gameObject.GetComponent<IgnoreGuideRaycast>()) continue; 

            if (!rlt.gameObject.TryGetComponent(out GuideStep guideStep)) continue;
            Debug.Log(rlt.gameObject); 
            guideStep.Step();
            break;
            // ExecuteEvents.Execute(rlt.gameObject, eventData, ExecuteEvents.pointerClickHandler);
            // ExecuteEvents.ExecuteHierarchy(rlt.gameObject, eventData, ExecuteEvents.pointerClickHandler);
        } 
    } 
}