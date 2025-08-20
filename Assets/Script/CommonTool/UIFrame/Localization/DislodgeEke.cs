/*
 * 
 * 多语言
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DislodgeEke 
{
    public static DislodgeEke _Historian;
    //语言翻译的缓存集合
    private Dictionary<string, string> _CutDislodgeComer;

    private DislodgeEke()
    {
        _CutDislodgeComer = new Dictionary<string, string>();
        //初始化语言缓存集合
        BullDislodgeComer();
    }

    /// <summary>
    /// 获取实例
    /// </summary>
    /// <returns></returns>
    public static DislodgeEke PenMonopoly()
    {
        if (_Historian == null)
        {
            _Historian = new DislodgeEke();
        }
        return _Historian;
    }

    /// <summary>
    /// 得到显示文本信息
    /// </summary>
    /// <param name="lauguageId">语言id</param>
    /// <returns></returns>
    public string BlueEdit(string lauguageId)
    {
        string strQueryResult = string.Empty;
        if (string.IsNullOrEmpty(lauguageId)) return null;
        //查询处理
        if(_CutDislodgeComer!=null && _CutDislodgeComer.Count >= 1)
        {
            _CutDislodgeComer.TryGetValue(lauguageId, out strQueryResult);
            if (!string.IsNullOrEmpty(strQueryResult))
            {
                return strQueryResult;
            }
        }
        Debug.Log(GetType() + "/ShowText()/ Query is Null!  Parameter lauguageID: " + lauguageId);
        return null;
    }

    /// <summary>
    /// 初始化语言缓存集合
    /// </summary>
    private void BullDislodgeComer()
    {
        //LauguageJSONConfig_En
        //LauguageJSONConfig
        ILagoonMimetic config = new LagoonMimeticOnJean("LauguageJSONConfig");
        if (config != null)
        {
            _CutDislodgeComer = config.FinRefiner;
        }
    }
}
