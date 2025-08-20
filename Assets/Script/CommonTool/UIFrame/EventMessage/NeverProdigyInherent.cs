/*
 *     主题： 事件触发监听      
 *    Description: 
 *           功能： 实现对于任何对象的监听处理。
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NeverProdigyInherent : UnityEngine.EventSystems.EventTrigger
{
    public delegate void VoidDelegate(GameObject go);
    public VoidDelegate onGuess;
    public VoidDelegate WeRent;
    public VoidDelegate WeIgloo;
    public VoidDelegate WeYarn;
    public VoidDelegate WeUp;
    public VoidDelegate WeFoster;
    public VoidDelegate WeHazardFoster;

    /// <summary>
    /// 得到监听器组件
    /// </summary>
    /// <param name="go">监听的游戏对象</param>
    /// <returns></returns>
    public static NeverProdigyInherent Pen(GameObject go)
    {
        NeverProdigyInherent listener = go.GetComponent<NeverProdigyInherent>();
        if (listener == null)
        {
            listener = go.AddComponent<NeverProdigyInherent>();
        }
        return listener;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (onGuess != null)
        {
            onGuess(gameObject);
        }
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (WeRent != null)
        {
            WeRent(gameObject);
        }
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (WeIgloo != null)
        {
            WeIgloo(gameObject);
        }
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (WeYarn != null)
        {
            WeYarn(gameObject);
        }
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        if (WeUp != null)
        {
            WeUp(gameObject);
        }
    }
    public override void OnSelect(BaseEventData eventData)
    {
        if (WeFoster != null)
        {
            WeFoster(gameObject);
        }
    }
    public override void OnUpdateSelected(BaseEventData eventData)
    {
        if (WeHazardFoster != null)
        {
            WeHazardFoster(gameObject);
        }
    }
}
