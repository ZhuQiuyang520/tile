using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DramTenuous : MonoBehaviour
{
    public static DramTenuous instance;

    private bool Reign= false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void VoteBlue()
    {
        bool isNewPlayer = !PlayerPrefs.HasKey(CConfig.sv_IsNewPlayer + "Bool") || SaveDataManager.GetBool(CConfig.sv_IsNewPlayer);
        AdjustInitManager.Instance.InitAdjustData(isNewPlayer);
        if (isNewPlayer)
        {
            // 新用户
            SaveDataManager.SetBool(CConfig.sv_IsNewPlayer, false);
            PlayerPrefs.SetInt(CConfig.CoinNumber, NetInfoMgr.instance.GameData.win_coins);
            PlayerPrefs.SetInt(CConfig.RollBackNumber, NetInfoMgr.instance.GameData.Undo_nums);
            PlayerPrefs.SetInt(CConfig.RemingNumber, NetInfoMgr.instance.GameData.Wand_nums);
            PlayerPrefs.SetInt(CConfig.RefreshNumber, NetInfoMgr.instance.GameData.Shuffle_nums);
            PlayerPrefs.SetInt(CConfig.OnceChalleng, 1);
            PlayerPrefs.SetInt(CConfig.OnceEnterChallenge, 1);
            //默认音乐打开
            PlayerPrefs.SetInt(CConfig.SaveMusic, 1);
            MusicMgr.GetInstance().PlayBg(MusicType.SceneMusic.Sound_BGM);
            //默认音效打开
            PlayerPrefs.SetInt(CConfig.SaveSound, 1);
            RoadTenuous.GetInstance().OfCharm = true;
            //默认震动打开
            PlayerPrefs.SetInt(CConfig.SaveVibration, 1);
            RoadTenuous.GetInstance().OfStuff = true;
            //默认自动收牌打开
            PlayerPrefs.SetInt(CConfig.SaveVolun, 1);
            RoadTenuous.GetInstance().OfPearl = true;
            PlayerPrefs.SetInt(CConfig.sv_CurLevel, 0);
        }
        else
        {
            RoadTenuous.GetInstance().OfCharm = false;
            RoadTenuous.GetInstance().OfStuff = false;
            RoadTenuous.GetInstance().OfPearl = false;
            MusicMgr.GetInstance().PlayBg(MusicType.SceneMusic.Sound_BGM);
            if (PlayerPrefs.GetInt(CConfig.SaveMusic) != 1)
            {
                MusicMgr.GetInstance().setBgmCloseOneTime();
            }
            if (PlayerPrefs.GetInt(CConfig.SaveSound) == 1)
            {
                RoadTenuous.GetInstance().OfCharm = true;
            }
            if (PlayerPrefs.GetInt(CConfig.SaveVibration) == 1)
            {
                RoadTenuous.GetInstance().OfStuff = true;
            }
            if (PlayerPrefs.GetInt(CConfig.SaveVolun) == 1)
            {
                RoadTenuous.GetInstance().OfPearl = true;
            }
        }
        RoadTenuous.GetInstance().OfIdeal = PlayerPrefs.GetInt(CConfig.FinishGuideLevel) == 0;
        RoadTenuous.GetInstance().ReliefStilt = true; 
        RoadTenuous.GetInstance().OfRadishTelescope = PlayerPrefs.GetInt(CConfig.sv_CurLevel) > NetInfoMgr.instance.GameData.Daily_Challenge;
        if (!RoadTenuous.GetInstance().OfIdeal)
        {
            UIManager.GetInstance().ShowUIForms(nameof(TuskLoder));
        }
        else
        {
            RoadBrother.instance.AimIdeal();
            UIManager.GetInstance().ShowUIForms(nameof(RoadLoder));
        }
        RoadNeckTenuous.GetInstance().BlueRoadNeck();

        Reign = true;

        //ActivityAutoOpenManager.Instance.OpenPanel(1);
    }

}
