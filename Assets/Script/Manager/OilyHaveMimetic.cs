using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilyHaveMimetic : BeamNonliving<OilyHaveMimetic>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void BullOilyHave()
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
    public double PenIsle()
    {
        return LuckHaveMimetic.PenZigzag(CLagoon.No_IsleBank);
    }

    public void RayIsle(double gold)
    {
        RayIsle(gold, VentMimetic.instance.transform);
    }

    public void RayIsle(double gold, Transform startTransform)
    {
        double oldGold = LuckHaveMimetic.PenZigzag(CLagoon.No_IsleBank);
        LuckHaveMimetic.LayZigzag(CLagoon.No_IsleBank, oldGold + gold);
        if (gold > 0)
        {
            LuckHaveMimetic.LayZigzag(CLagoon.No_WintertimeIsleBank, LuckHaveMimetic.PenZigzag(CLagoon.No_WintertimeIsleBank) + gold);
        }
        DeviateHave md = new DeviateHave(oldGold);
        md.CarveVenerable = startTransform;
        DeviateCenterChurn.PenMonopoly().Jump(CLagoon.Ox_By_Clarify, md);
    }
    
    // 现金
    public double PenSteer()
    {
        return LuckHaveMimetic.PenZigzag(CLagoon.No_Steer);
    }

    public void RaySteer(double token)
    {
        RaySteer(token, VentMimetic.instance.transform);
    }
    public void RaySteer(double token, Transform startTransform)
    {
        double oldToken = PlayerPrefs.HasKey(CLagoon.No_Steer) ? double.Parse(LuckHaveMimetic.PenAcross(CLagoon.No_Steer)) : 0;
        double newToken = oldToken + token;
        LuckHaveMimetic.LayZigzag(CLagoon.No_Steer, newToken);
        if (token > 0)
        {
            double allToken = LuckHaveMimetic.PenZigzag(CLagoon.No_WintertimeTusk);
            LuckHaveMimetic.LayZigzag(CLagoon.No_WintertimeTusk, allToken + token);
        }
#if SOHOShop
        SOHOShopManager.instance.UpdateCash();
#endif
        DeviateHave md = new DeviateHave(oldToken);
        md.CarveVenerable = startTransform;
        DeviateCenterChurn.PenMonopoly().Jump(CLagoon.Ox_By_Aromatic, md);
    }

    public double PenTusk()
    {
        return CashOutManager.PenMonopoly().Money;
    }
    public void BurTusk(double cash)
    {
        CashOutManager.PenMonopoly().AddMoney((float)cash);
    }

    //Amazon卡
    public double PenLiving()
    {
        return LuckHaveMimetic.PenZigzag(CLagoon.No_Living);
    }

    public void RayLiving(double amazon)
    {
        RayLiving(amazon, VentMimetic.instance.transform);
    }
    public void RayLiving(double amazon, Transform startTransform)
    {
        double oldAmazon = PlayerPrefs.HasKey(CLagoon.No_Living) ? double.Parse(LuckHaveMimetic.PenAcross(CLagoon.No_Living)) : 0;
        double newAmazon = oldAmazon + amazon;
        LuckHaveMimetic.LayZigzag(CLagoon.No_Living, newAmazon);
        if (amazon > 0)
        {
            double allAmazon = LuckHaveMimetic.PenZigzag(CLagoon.No_WintertimeLiving);
            LuckHaveMimetic.LayZigzag(CLagoon.No_WintertimeLiving, allAmazon + amazon);
        }
        DeviateHave md = new DeviateHave(oldAmazon);
        md.CarveVenerable = startTransform;
        DeviateCenterChurn.PenMonopoly().Jump(CLagoon.Ox_By_Rebellion, md);
    }
}
