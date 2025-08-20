/**
 * 
 * 支持上下滑动的scroll view
 * 
 * **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ThreshCast : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("itemCell")]    //预支单体
    public ScrollViewItem NestHere;
[UnityEngine.Serialization.FormerlySerializedAs("scrollRect")]    //scrollview
    public ScrollRect InventGrab;
[UnityEngine.Serialization.FormerlySerializedAs("content")]
    //content
    public RectTransform Portend;
[UnityEngine.Serialization.FormerlySerializedAs("spacing")]    //间隔
    public float Ascribe= 10;
[UnityEngine.Serialization.FormerlySerializedAs("totalWidth")]    //总的宽
    public float AdultDecay;
[UnityEngine.Serialization.FormerlySerializedAs("totalHeight")]    //总的高
    public float AdultEleven;
[UnityEngine.Serialization.FormerlySerializedAs("visibleCount")]    //可见的数量
    public int OverallIdeal;
[UnityEngine.Serialization.FormerlySerializedAs("isClac")]    //初始数据完成是否检测计算
    public bool ByFend= false;
[UnityEngine.Serialization.FormerlySerializedAs("startIndex")]    //开始的索引
    public int StealNaive;
[UnityEngine.Serialization.FormerlySerializedAs("lastIndex")]    //结尾的索引
    public int RelyNaive;
[UnityEngine.Serialization.FormerlySerializedAs("itemHeight")]    //item的高
    public float NestEleven= 50;
[UnityEngine.Serialization.FormerlySerializedAs("itemList")]
    //缓存的itemlist
    public List<ScrollViewItem> NestPlug;
[UnityEngine.Serialization.FormerlySerializedAs("visibleList")]    //可见的itemList
    public List<ScrollViewItem> OverallPlug;
[UnityEngine.Serialization.FormerlySerializedAs("allList")]    //总共的dataList
    public List<int> allPlug;

    void Start()
    {
        AdultEleven = this.GetComponent<RectTransform>().sizeDelta.y;
        AdultDecay = this.GetComponent<RectTransform>().sizeDelta.x;
        Portend = InventGrab.content;
        BullHave();

    }
    //初始化
    public void BullHave()
    {
        OverallIdeal = Mathf.CeilToInt(AdultEleven / NineEleven) + 1;
        for (int i = 0; i < OverallIdeal; i++)
        {
            this.BurOoze();
        }
        StealNaive = 0;
        RelyNaive = 0;
        List<int> numberList = new List<int>();
        //数据长度
        int dataLength = 20;
        for (int i = 0; i < dataLength; i++)
        {
            numberList.Add(i);
        }
        LayHave(numberList);
    }
    //设置数据
    void LayHave(List<int> list)
    {
        allPlug = list;
        StealNaive = 0;
        if (HaveIdeal <= OverallIdeal)
        {
            RelyNaive = HaveIdeal;
        }
        else
        {
            RelyNaive = OverallIdeal - 1;
        }
        //Debug.Log("ooooooooo"+lastIndex);
        for (int i = StealNaive; i < RelyNaive; i++)
        {
            ScrollViewItem obj = YewOoze();
            if (obj == null)
            {
                Debug.Log("获取item为空");
            }
            else
            {
                obj.gameObject.name = i.ToString();

                obj.gameObject.SetActive(true);
                obj.transform.localPosition = new Vector3(0, -i * NineEleven, 0);
                OverallPlug.Add(obj);
                HazardOoze(i, obj);
            }

        }
        Portend.sizeDelta = new Vector2(AdultDecay, HaveIdeal * NineEleven - Ascribe);
        ByFend = true;
    }
    //更新item
    public void HazardOoze(int index, ScrollViewItem obj)
    {
        int d = allPlug[index];
        string str = d.ToString();
        obj.name = str;
        //更新数据 todo
    }
    //从itemlist中取出item
    public ScrollViewItem YewOoze()
    {
        ScrollViewItem obj = null;
        if (NestPlug.Count > 0)
        {
            obj = NestPlug[0];
            obj.gameObject.SetActive(true);
            NestPlug.RemoveAt(0);
        }
        else
        {
            Debug.Log("从缓存中取出的是空");
        }
        return obj;
    }
    //item进入itemlist
    public void LureOoze(ScrollViewItem obj)
    {
        NestPlug.Add(obj);
        obj.gameObject.SetActive(false);
    }
    public int HaveIdeal    {
        get
        {
            return allPlug.Count;
        }
    }
    //每一行的高
    public float NineEleven    {
        get
        {
            return NestEleven + Ascribe;
        }
    }
    //添加item到缓存列表中
    public void BurOoze()
    {
        GameObject obj = Instantiate(NestHere.gameObject);
        obj.transform.SetParent(Portend);
        RectTransform Dirt= obj.GetComponent<RectTransform>();
        Dirt.anchorMin = new Vector2(0.5f, 1);
        Dirt.anchorMax = new Vector2(0.5f, 1);
        Dirt.pivot = new Vector2(0.5f, 1);
        obj.SetActive(false);
        obj.transform.localScale = Vector3.one;
        ScrollViewItem o = obj.GetComponent<ScrollViewItem>();
        NestPlug.Add(o);
    }



    void Update()
    {
        if (ByFend)
        {
            Thresh();
        }
    }
    /// <summary>
    /// 计算滑动支持上下滑动
    /// </summary>
    void Thresh()
    {
        float vy = Portend.anchoredPosition.y;
        float rollUpTop = (StealNaive + 1) * NineEleven;
        float rollUnderTop = StealNaive * NineEleven;

        if (vy > rollUpTop && RelyNaive < HaveIdeal)
        {
            //上边界移除
            if (OverallPlug.Count > 0)
            {
                ScrollViewItem obj = OverallPlug[0];
                OverallPlug.RemoveAt(0);
                LureOoze(obj);
            }
            StealNaive++;
        }
        float rollUpBottom = (RelyNaive - 1) * NineEleven - Ascribe;
        if (vy < rollUpBottom - AdultEleven && StealNaive > 0)
        {
            //下边界减少
            RelyNaive--;
            if (OverallPlug.Count > 0)
            {
                ScrollViewItem obj = OverallPlug[OverallPlug.Count - 1];
                OverallPlug.RemoveAt(OverallPlug.Count - 1);
                LureOoze(obj);
            }

        }
        float rollUnderBottom = RelyNaive * NineEleven - Ascribe;
        if (vy > rollUnderBottom - AdultEleven && RelyNaive < HaveIdeal)
        {
            //Debug.Log("下边界增加"+vy);
            //下边界增加
            ScrollViewItem go = YewOoze();
            OverallPlug.Add(go);
            go.transform.localPosition = new Vector3(0, -RelyNaive * NineEleven);
            HazardOoze(RelyNaive, go);
            RelyNaive++;
        }


        if (vy < rollUnderTop && StealNaive > 0)
        {
            //Debug.Log("上边界增加"+vy);
            //上边界增加
            StealNaive--;
            ScrollViewItem go = YewOoze();
            OverallPlug.Insert(0, go);
            HazardOoze(StealNaive, go);
            go.transform.localPosition = new Vector3(0, -StealNaive * NineEleven);
        }

    }
}
