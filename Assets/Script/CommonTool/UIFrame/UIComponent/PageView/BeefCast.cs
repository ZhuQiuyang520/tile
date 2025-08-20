/**
 * 
 * 左右滑动的页面视图
 * 
 * ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class BeefCast : MonoBehaviour,IBeginDragHandler,IEndDragHandler
{
[UnityEngine.Serialization.FormerlySerializedAs("rect")]    //scrollview
    public ScrollRect Dirt;
    //求出每页的临界角，页索引从0开始
    List<float> HatPlug= new List<float>();
[UnityEngine.Serialization.FormerlySerializedAs("isDrag")]    //是否拖拽结束
    public bool ByDrag= false;
    bool UponAsia= true;
    //滑动的起始坐标  
    float CobaltDisability= 0;
    float StealPeakDisability;
    float startTime = 0f;
[UnityEngine.Serialization.FormerlySerializedAs("smooting")]    //滑动速度  
    public float Eclectic= 1f;
[UnityEngine.Serialization.FormerlySerializedAs("sensitivity")]    public float Cultivation= 0.3f;
[UnityEngine.Serialization.FormerlySerializedAs("OnPageChange")]    //页面改变
    public Action<int> OnBeefDampen;
    //当前页面下标
    int PrudentBeefNaive= -1;
    void Start()
    {
        Dirt = this.GetComponent<ScrollRect>();
        float horizontalLength = Dirt.content.rect.width - this.GetComponent<RectTransform>().rect.width;
        HatPlug.Add(0);
        for(int i = 1; i < Dirt.content.childCount - 1; i++)
        {
            HatPlug.Add(GetComponent<RectTransform>().rect.width * i / horizontalLength);
        }
        HatPlug.Add(1);
    }

    
    void Update()
    {
        if(!ByDrag && !UponAsia)
        {
            startTime += Time.deltaTime;
            float t = startTime * Eclectic;
            Dirt.horizontalNormalizedPosition = Mathf.Lerp(Dirt.horizontalNormalizedPosition, CobaltDisability, t);
            if (t >= 1)
            {
                UponAsia = true;
            }
        }
        
    }
    /// <summary>
    /// 设置页面的index下标
    /// </summary>
    /// <param name="index"></param>
    void LayBeefNaive(int index)
    {
        if (PrudentBeefNaive != index)
        {
            PrudentBeefNaive = index;
            if (OnBeefDampen != null)
            {
                OnBeefDampen(index);
            }
        }
    }
    /// <summary>
    /// 开始拖拽
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        ByDrag = true;
        StealPeakDisability = Dirt.horizontalNormalizedPosition;
    }
    /// <summary>
    /// 拖拽结束
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        float posX = Dirt.horizontalNormalizedPosition;
        posX += ((posX - StealPeakDisability) * Cultivation);
        posX = posX < 1 ? posX : 1;
        posX = posX > 0 ? posX : 0;
        int index = 0;
        float offset = Mathf.Abs(HatPlug[index] - posX);
        for(int i = 0; i < HatPlug.Count; i++)
        {
            float temp = Mathf.Abs(HatPlug[i] - posX);
            if (temp < offset)
            {
                index = i;
                offset = temp;
            }
        }
        LayBeefNaive(index);
        CobaltDisability = HatPlug[index];
        ByDrag = false;
        startTime = 0f;
        UponAsia = false;
    }
}
