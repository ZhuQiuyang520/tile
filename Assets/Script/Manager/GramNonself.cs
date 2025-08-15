using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GramNonself : MonoBehaviour
{
    public static GramNonself instance;

    private bool Blast= false;

    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    //切前后台也需要检测屏蔽 防止游戏中途更改手机状态
    private void OnApplicationFocus(bool focusStatus)
    {
        if (focusStatus)
            CommonUtil.AndroidBlockCheck();
    }

    public void PeruFree()
    {
        bool isNewPlayer = !PlayerPrefs.HasKey(CConfig.sv_IsNewPlayer + "Bool") || SaveDataManager.GetBool(CConfig.sv_IsNewPlayer);
        AdjustInitManager.Instance.InitAdjustData(isNewPlayer);
        if (isNewPlayer)
        {
            // 新用户
            SaveDataManager.SetBool(CConfig.sv_IsNewPlayer, false);
            PlayerPrefs.SetInt(CConfig.CoinNumber, NetInfoMgr.instance.GameData.win_coins);
            SaveDataManager.SetFloat(CConfig.CoinNumber_All, NetInfoMgr.instance.GameData.win_coins);
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
            RaftNonself.GetInstance().MeCanal = true;
            //默认震动打开
            PlayerPrefs.SetInt(CConfig.SaveVibration, 1);
            RaftNonself.GetInstance().MeArena = true;
            //默认自动收牌打开
            PlayerPrefs.SetInt(CConfig.SaveVolun, 1);
            RaftNonself.GetInstance().MeCloud = true;
            PlayerPrefs.SetInt(CConfig.sv_CurLevel, 0);
            if (CommonUtil.IsApple())
            {
                PlayerPrefs.SetInt(CConfig.FinishWangzhuanGuide, 1);
            }
        }
        else
        {
            RaftNonself.GetInstance().MeCanal = false;
            RaftNonself.GetInstance().MeArena = false;
            RaftNonself.GetInstance().MeCloud = false;
            MusicMgr.GetInstance().PlayBg(MusicType.SceneMusic.Sound_BGM);
            if (PlayerPrefs.GetInt(CConfig.SaveMusic) != 1)
            {
                MusicMgr.GetInstance().setBgmCloseOneTime();
            }
            if (PlayerPrefs.GetInt(CConfig.SaveSound) == 1)
            {
                RaftNonself.GetInstance().MeCanal = true;
            }
            if (PlayerPrefs.GetInt(CConfig.SaveVibration) == 1)
            {
                RaftNonself.GetInstance().MeArena = true;
            }
            if (PlayerPrefs.GetInt(CConfig.SaveVolun) == 1)
            {
                RaftNonself.GetInstance().MeCloud = true;
            }
        }

        RaftNonself.GetInstance().MeUntie = PlayerPrefs.GetInt(CConfig.FinishGuideLevel) == 0;
        
        RaftNonself.GetInstance().EmpireStilt = true; 
        RaftNonself.GetInstance().MeExtentOutrigger = PlayerPrefs.GetInt(CConfig.sv_CurLevel) > NetInfoMgr.instance.GameData.Daily_Challenge;
        if (CommonUtil.IsApple())
        {
            RaftNonself.GetInstance().MeUntie = false;
            UIManager.GetInstance().ShowUIForms(nameof(CoinSixth));
        }
        else
        {
            if (!RaftNonself.GetInstance().MeUntie)
            {
                UIManager.GetInstance().ShowUIForms(nameof(TuckNeedy));
            }
            else
            {
                RaftMeeting.instance.GapUntie();
                UIManager.GetInstance().ShowUIForms(nameof(RaftNeedy));
            }
        }

        RaftWeedNonself.GetInstance().FreeRaftWeed();

        Blast = true;

        //ActivityAutoOpenManager.Instance.OpenPanel(1);
    }

}
