using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShaftDime
{
    Success,
    GoldNotEnough,
    DiamondNotEnouth,
    OutOfStock,
    PurchaseFailed,
    ExpNotEnouth,
    HealthNotEnough
}

public static class ErrorCodeMessage
{
    private static readonly Dictionary<ShaftDime, string> Girl= new Dictionary<ShaftDime, string>
    {
        { ShaftDime.Success, "操作成功" },
        { ShaftDime.GoldNotEnough, "金币不足" },
        { ShaftDime.DiamondNotEnouth, "钻石不足" },
        { ShaftDime.OutOfStock, "库存不足" },
        { ShaftDime.PurchaseFailed, "支付失败" },
        { ShaftDime.ExpNotEnouth, "经验不足" },
        { ShaftDime.HealthNotEnough, "体力不足" }
    };

    public static string PenDeviate(ShaftDime errorCode)
    {
        if (Girl.TryGetValue(errorCode, out string msg))
        {
            return msg;
        }
        return errorCode.ToString(); // 如果没有找到对应的描述，返回枚举值的字符串表示
    }
}
