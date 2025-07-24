using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUtil
{

    /// <summary>
    /// 获取现金系数 不随机
    /// </summary>
    /// <param name="cumulative"></param>
    /// <param name="multiGroup"></param>
    /// <returns></returns>
    private static double GetMultiWithOutRandom(double cumulative, MultiGroup[] multiGroup)
    {
        foreach (MultiGroup item in multiGroup)
        {
            if (item.max > cumulative)
            {
                return item.multi;
            }
        }

        return 1;

    }
    /// <summary>
    /// 获取multi系数
    /// </summary>
    /// <returns></returns>
    private static double GetMulti(RewardType type, double cumulative, MultiGroup[] multiGroup)
    {
        foreach (MultiGroup item in multiGroup)
        {
            if (item.max > cumulative)
            {
                if (type == RewardType.cash)
                {
                    float random = Random.Range((float)NetInfoMgr.instance.InitData.cash_random[0], (float)NetInfoMgr.instance.InitData.cash_random[1]);
                    return item.multi * (1 + random);
                }
                else
                {
                    return item.multi;
                }
            }
        }
        return 1;
    }
    /// <summary>
    /// 现金金额系数(不含随机cashrandom)
    /// </summary>
    /// <returns></returns>
    public static double GetCashMultiWithOutRandom()
    {
        return GetMultiWithOutRandom(SaveDataManager.GetDouble(CConfig.sv_CumulativeCash),
            NetInfoMgr.instance.InitData.cash_group);
    }
    public static double GetGoldMulti()
    {
        return GetMulti(RewardType.gold, SaveDataManager.GetDouble(CConfig.sv_CumulativeGoldCoin), NetInfoMgr.instance.InitData.gold_group);
    }

    public static double GetCashMulti()
    {
        return GetMulti(RewardType.cash, SaveDataManager.GetDouble(CConfig.sv_CumulativeCash), NetInfoMgr.instance.InitData.cash_group);
    }
    /// <summary>
    /// 获取权重系数
    /// </summary>
    /// <param name="cumulative"></param>
    /// <param name="multiGroup"></param>
    /// <returns></returns>
    private static double GetWeightMulti(double cumulative, MultiGroup[] multiGroup)
    {
        foreach (MultiGroup item in multiGroup)
        {
            if (item.max > cumulative)
            {
                return item.weight_multi;
            }
        }

        return 1;
    }
    /// <summary>
    /// 获取现金权重系数
    /// </summary>
    /// <returns></returns>
    public static double GetCashWeightMulti()
    {
        return GetWeightMulti(SaveDataManager.GetDouble(CConfig.sv_CumulativeCash),
            NetInfoMgr.instance.InitData.cash_group);
    }

    /// <summary>
    /// 根据权重获取奖励index
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public static int GetRewardIndexWithWeight(List<RewardData> list)
    {
        double allweight = 0;
        foreach (RewardData data in list)
        {
            allweight += data.Trader;
        }
        float r = Random.Range(0, (float)allweight);
        int index = 0;
        float nowWeight = 0;
        for (int i = 0; i < list.Count; i++)
        {
            nowWeight += (float)list[i].Trader;
            if (r < nowWeight)
            {
                index = i;
                //Debug.Log(i + "," + list[i].num);
                break;
            }
        }
        return index;
    }

    public static int GetWheelMultiIndex(string type)
    {
        List<WheelMultiItem> list = new List<WheelMultiItem>();
        if (type == "cash")
        {
            list = new List<WheelMultiItem>(NetInfoMgr.instance.GameData.wheel_reward_multi.cash);
        }
        else if (type == "gold")
        {
            list = new List<WheelMultiItem>(NetInfoMgr.instance.GameData.wheel_reward_multi.gold);
        }
        else if(type == "shuffle")
        {
            list = new List<WheelMultiItem>(NetInfoMgr.instance.GameData.wheel_reward_multi.shuffle);
        }
        else if (type == "undo")
        {
            list = new List<WheelMultiItem>(NetInfoMgr.instance.GameData.wheel_reward_multi.undo);
        }
        else if (type == "wand")
        {
            list = new List<WheelMultiItem>(NetInfoMgr.instance.GameData.wheel_reward_multi.wand);
        }
        double allweight = 0;
        foreach (WheelMultiItem data in list)
        {
            allweight += data.weight;
        }
        float r = Random.Range(0, (float)allweight);
        int index = 0;
        float nowWeight = 0;
        for (int i = 0; i < list.Count; i++)
        {
            nowWeight += (float)list[i].weight;
            if (r < nowWeight)
            {
                index = i;
                break;
            }
        }
        return index;
    }
}


/// <summary>
/// 奖励类型
/// </summary>
//public enum RewardType { Gold, Cash, Amazon }
