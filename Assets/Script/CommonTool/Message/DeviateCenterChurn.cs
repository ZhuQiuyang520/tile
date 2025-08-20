using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 消息管理器
/// </summary>
public class DeviateCenterChurn:BeamNonliving<DeviateCenterChurn>
{
    //保存所有消息事件的字典
    //key使用字符串保存消息的名称
    //value使用一个带自定义参数的事件，用来调用所有注册的消息
    private Dictionary<string, Action<DeviateHave>> ProfessionDeviate;

    /// <summary>
    /// 私有构造函数
    /// </summary>
    private DeviateCenterChurn()
    {
        BullHave();
    }

    private void BullHave()
    {
        //初始化消息字典
        ProfessionDeviate = new Dictionary<string, Action<DeviateHave>>();
    }

    /// <summary>

    /// 注册消息事件
    /// </summary>
    /// <param name="key">消息名</param>
    /// <param name="action">消息事件</param>
    public void Scavenge(string key, Action<DeviateHave> action)
    {
        if (!ProfessionDeviate.ContainsKey(key))
        {
            ProfessionDeviate.Add(key, null);
        }
        ProfessionDeviate[key] += action;
    }



    /// <summary>
    /// 注销消息事件
    /// </summary>
    /// <param name="key">消息名</param>
    /// <param name="action">消息事件</param>
    public void Hyksos(string key, Action<DeviateHave> action)
    {
        if (ProfessionDeviate.ContainsKey(key) && ProfessionDeviate[key] != null)
        {
            ProfessionDeviate[key] -= action;
        }
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="key">消息名</param>
    /// <param name="data">消息传递数据，可以不传</param>
    public void Jump(string key, DeviateHave data = null)
    {
        if (ProfessionDeviate.ContainsKey(key) && ProfessionDeviate[key] != null)
        {
            ProfessionDeviate[key](data);
        }
    }

    /// <summary>
    /// 清空所有消息
    /// </summary>
    public void Flake()
    {
        ProfessionDeviate.Clear();
    }
}
