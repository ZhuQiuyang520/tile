using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftWeedNonself : MonoSingleton<RaftWeedNonself>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FreeRaftWeed()
    {
#if SOHOShop
        // 提现商店初始化
        // 提现商店中的金币、现金和amazon卡均为double类型，参数请根据具体项目自行处理
        SOHOShopManager.instance.InitSOHOShopAction(
            getToken,
            getGold, 
            getAmazon,    // amazon
            (subToken) => { addToken(-subToken); }, 
            (subGold) => { addGold(-subGold); }, 
            (subAmazon) => { addAmazon(-subAmazon); });
#endif
    }

    // 金币
    public double RoeVase()
    {
        return SaveDataManager.GetDouble(CConfig.sv_GoldCoin);
    }

    public void MudVase(double gold)
    {
        MudVase(gold, GramNonself.instance.transform);
    }

    public void MudVase(double gold, Transform startTransform)
    {
        double oldGold = SaveDataManager.GetDouble(CConfig.sv_GoldCoin);
        SaveDataManager.SetDouble(CConfig.sv_GoldCoin, oldGold + gold);
        if (gold > 0)
        {
            SaveDataManager.SetDouble(CConfig.sv_CumulativeGoldCoin, SaveDataManager.GetDouble(CConfig.sv_CumulativeGoldCoin) + gold);
        }
        MessageData md = new MessageData(oldGold);
        md.valueTransform = startTransform;
        MessageCenterLogic.GetInstance().Send(CConfig.mg_ui_addgold, md);
    }
    
    // 现金
    public double SadLeafy()
    {
        return SaveDataManager.GetDouble(CConfig.sv_Token);
    }

    public void ArtLeafy(double token)
    {
        ArtLeafy(token, GramNonself.instance.transform);
    }
    public void ArtLeafy(double token, Transform startTransform)
    {
        double oldToken = PlayerPrefs.HasKey(CConfig.sv_Token) ? double.Parse(SaveDataManager.GetString(CConfig.sv_Token)) : 0;
        double newToken = oldToken + token;
        SaveDataManager.SetDouble(CConfig.sv_Token, newToken);
        if (token > 0)
        {
            double allToken = SaveDataManager.GetDouble(CConfig.sv_CumulativeCash);
            SaveDataManager.SetDouble(CConfig.sv_CumulativeCash, allToken + token);
        }
#if SOHOShop
        SOHOShopManager.instance.UpdateCash();
#endif
        MessageData md = new MessageData(oldToken);
        md.valueTransform = startTransform;
        MessageCenterLogic.GetInstance().Send(CConfig.mg_ui_addtoken, md);
    }

    public double YouKiln()
    {
        return CashOutManager.GetInstance().Money;
    }
    public void SodKiln(double cash)
    {
        CashOutManager.GetInstance().AddMoney((float)cash);
    }

    //Amazon卡
    public double SadVision()
    {
        return SaveDataManager.GetDouble(CConfig.sv_Amazon);
    }

    public void ArtVision(double amazon)
    {
        ArtVision(amazon, GramNonself.instance.transform);
    }
    public void ArtVision(double amazon, Transform startTransform)
    {
        double oldAmazon = PlayerPrefs.HasKey(CConfig.sv_Amazon) ? double.Parse(SaveDataManager.GetString(CConfig.sv_Amazon)) : 0;
        double newAmazon = oldAmazon + amazon;
        SaveDataManager.SetDouble(CConfig.sv_Amazon, newAmazon);
        if (amazon > 0)
        {
            double allAmazon = SaveDataManager.GetDouble(CConfig.sv_CumulativeAmazon);
            SaveDataManager.SetDouble(CConfig.sv_CumulativeAmazon, allAmazon + amazon);
        }
        MessageData md = new MessageData(oldAmazon);
        md.valueTransform = startTransform;
        MessageCenterLogic.GetInstance().Send(CConfig.mg_ui_addamazon, md);
    }
}
