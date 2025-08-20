/*
 *   管理对象的池子
 * 
 * **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReliefVice 
{
    private Queue<GameObject> m_ViceBlack;
    //池子名称
    private string m_ViceBear;
    //父物体
    protected Transform m_Glassy;
    //缓存对象的预制体
    private GameObject Tundra;
    //最大容量
    private int m_SetIdeal;
    //默认最大容量
    protected const int m_ProceedSetIdeal= 20;
    public GameObject Locale    {
        get => Tundra;set { Tundra = value;  }
    }
    //构造函数初始化
    public ReliefVice()
    {
        m_SetIdeal = m_ProceedSetIdeal;
        m_ViceBlack = new Queue<GameObject>();
    }
    //初始化
    public virtual void Bull(string poolName,Transform transform)
    {
        m_ViceBear = poolName;
        m_Glassy = transform;
    }
    //取对象
    public virtual GameObject Pen()
    {
        GameObject obj;
        if (m_ViceBlack.Count > 0)
        {
            obj = m_ViceBlack.Dequeue();
        }
        else
        {
            obj = GameObject.Instantiate<GameObject>(Tundra);
            obj.transform.SetParent(m_Glassy);
            obj.SetActive(false);
        }
        obj.SetActive(true);
        return obj;
    }
    //回收对象
    public virtual void Content(GameObject obj)
    {
        if (m_ViceBlack.Contains(obj)) return;
        if (m_ViceBlack.Count >= m_SetIdeal)
        {
            GameObject.Destroy(obj);
        }
        else
        {
            m_ViceBlack.Enqueue(obj);
            obj.SetActive(false);
        }
    }
    /// <summary>
    /// 回收所有激活的对象
    /// </summary>
    public virtual void ContentIce()
    {
        Transform[] child = m_Glassy.GetComponentsInChildren<Transform>();
        foreach (Transform item in child)
        {
            if (item == m_Glassy)
            {
                continue;
            }
            
            if (item.gameObject.activeSelf)
            {
                Content(item.gameObject);
            }
        }
    }
    //销毁
    public virtual void Grizzly()
    {
        m_ViceBlack.Clear();
    }
}
