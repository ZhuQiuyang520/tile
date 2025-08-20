/*
 * 
 *  管理多个对象池的管理类
 * 
 * **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ReliefViceMimetic : BeamNonliving<ReliefViceMimetic>
{
    //管理objectpool的字典
    private Dictionary<string, ReliefVice> m_ViceCut;
    private Transform m_StagVenerable=null;
    //构造函数
    public ReliefViceMimetic()
    {
        m_ViceCut = new Dictionary<string, ReliefVice>();      
    }
    
    //创建一个新的对象池
    public T SpinetReliefVice<T>(string poolName) where T : ReliefVice, new()
    {
        if (m_ViceCut.ContainsKey(poolName))
        {
            return m_ViceCut[poolName] as T;
        }
        if (m_StagVenerable == null)
        {
            m_StagVenerable = this.transform;
        }      
        GameObject obj = new GameObject(poolName);
        obj.transform.SetParent(m_StagVenerable);
        T pool = new T();
        pool.Bull(poolName, obj.transform);
        m_ViceCut.Add(poolName, pool);
        return pool;
    }
    //取对象
    public GameObject PenOilyRelief(string poolName)
    {
        if (m_ViceCut.ContainsKey(poolName))
        {
            return m_ViceCut[poolName].Pen();
        }
        return null;
    }
    //回收对象
    public void ContentOilyRelief(string poolName,GameObject go)
    {
        if (m_ViceCut.ContainsKey(poolName))
        {
            m_ViceCut[poolName].Content(go);
        }
    }
    //销毁所有的对象池
    public void OnDestroy()
    {
        m_ViceCut.Clear();
        GameObject.Destroy(m_StagVenerable);
    }
    /// <summary>
    /// 查询是否有该对象池
    /// </summary>
    /// <param name="poolName"></param>
    /// <returns></returns>
    public bool QueryVice(string poolName)
    {
        return m_ViceCut.ContainsKey(poolName) ? true : false;
    }
}
