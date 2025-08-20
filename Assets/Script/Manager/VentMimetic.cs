using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentMimetic : MonoBehaviour
{
    public static VentMimetic instance;

    private bool Visit= false;

    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
    }

    //切前后台也需要检测屏蔽 防止游戏中途更改手机状态
    private void OnApplicationFocus(bool focusStatus)
    {
        if (focusStatus)
            TemperFile.ReleaseEnterOther();
    }

    public void MailBull()
    {
        SawSelfEke.instance.AtMimetic.SetActive(true);
        bool isNewPlayer = !PlayerPrefs.HasKey(CLagoon.No_WeCopSparse + "Bool") || LuckHaveMimetic.PenKeep(CLagoon.No_WeCopSparse);
        ShrimpBullMimetic.Instance.BullShrimpHave(isNewPlayer);
        if (isNewPlayer)
        {
            // 新用户
            LuckHaveMimetic.LayKeep(CLagoon.No_WeCopSparse, false);
            PlayerPrefs.SetInt(CLagoon.PeltWarmFloral, SawSelfEke.instance.OilyHave.Undo_nums);
            PlayerPrefs.SetInt(CLagoon.PerishFloral, SawSelfEke.instance.OilyHave.Wand_nums);
            PlayerPrefs.SetInt(CLagoon.StudentFloral, SawSelfEke.instance.OilyHave.Shuffle_nums);
            PlayerPrefs.SetInt(CLagoon.PumpModestly, 1);
            PlayerPrefs.SetInt(CLagoon.PumpIglooAdmission, 1);
            //默认音乐打开
            PlayerPrefs.SetInt(CLagoon.LuckWhale, 1);
            WhaleEke.PenMonopoly().JuneSo(WhaleSpur.SceneMusic.Sound_BGM);
            //默认音效打开
            PlayerPrefs.SetInt(CLagoon.LuckHumid, 1);
            OilyMimetic.PenMonopoly().WeHumid = true;
            //默认震动打开
            PlayerPrefs.SetInt(CLagoon.LuckIntegrity, 1);
            OilyMimetic.PenMonopoly().WeCoral = true;
            //默认自动收牌打开
            PlayerPrefs.SetInt(CLagoon.LuckFancy, 1);
            OilyMimetic.PenMonopoly().WeFancy = true;
            PlayerPrefs.SetInt(CLagoon.No_RyeClump, 0);
            if (TemperFile.WeSound())
            {
                PlayerPrefs.SetInt(CLagoon.RedbudEnclosurePenal, 1);
            }
        }
        else
        {
            OilyMimetic.PenMonopoly().WeHumid = false;
            OilyMimetic.PenMonopoly().WeCoral = false;
            OilyMimetic.PenMonopoly().WeFancy = false;
            WhaleEke.PenMonopoly().JuneSo(WhaleSpur.SceneMusic.Sound_BGM);
            if (PlayerPrefs.GetInt(CLagoon.LuckWhale) != 1)
            {
                WhaleEke.PenMonopoly().DieAshHatchSunQuit();
            }
            if (PlayerPrefs.GetInt(CLagoon.LuckHumid) == 1)
            {
                OilyMimetic.PenMonopoly().WeHumid = true;
            }
            if (PlayerPrefs.GetInt(CLagoon.LuckIntegrity) == 1)
            {
                OilyMimetic.PenMonopoly().WeCoral = true;
            }
            if (PlayerPrefs.GetInt(CLagoon.LuckFancy) == 1)
            {
                OilyMimetic.PenMonopoly().WeFancy = true;
            }
        }
        OilyMimetic.PenMonopoly().WePenal = PlayerPrefs.GetInt(CLagoon.RedbudPenalClump) == 0;
        OilyMimetic.PenMonopoly().EngineGuess = true; 
        OilyMimetic.PenMonopoly().WeVirginAdmission = PlayerPrefs.GetInt(CLagoon.No_RyeClump) > SawSelfEke.instance.OilyHave.Daily_Challenge;
        if (TemperFile.WeSound())
        {
            OilyMimetic.PenMonopoly().WePenal = false;
            UIMimetic.PenMonopoly().BlueUIBasin(nameof(OvenToxicIOS));
        }
        else
        {
            if (!OilyMimetic.PenMonopoly().WePenal)
            {
                UIMimetic.PenMonopoly().BlueUIBasin(nameof(OvenToxic));
            }
            else
            {
                OilyVillage.instance.CopPenal();
                UIMimetic.PenMonopoly().BlueUIBasin(nameof(OilyToxic));
            }
        }
        
        OilyHaveMimetic.PenMonopoly().BullOilyHave();

        Visit = true;

        //ActivityAutoOpenManager.Instance.OpenPanel(1);
    }

}
