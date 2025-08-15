using DG.Tweening;
using Lofelt.NiceVibrations;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using static Spine.AnimationState;

public class RaftNonself : MonoSingleton<RaftNonself>
{
    public bool EmpireStilt{ get; set; }
    public bool OutriggerGlean{ get; set; }
    public bool MeOutrigger{ get; set; }
    public bool MeExtentOutrigger{ get; set; }
    public bool MeCloud{ get; set; }
    public bool MeArena{ get; set; }
    public bool MeCanal{ get; set; }

    public bool MeUntie{ get; set; }

    public bool MeOutriggerSaguaroYolk{ get; set; }

    public int CharacterBoldMandan{ get; set; }

    public void CharacterBold()
    {
        if (CharacterBoldMandan > 0)
        {
            CharacterBoldMandan--;
            Slowly++;
            if (CommonUtil.IsApple())
            {
                UIManager.GetInstance().ShowUIForms(nameof(BoldSixth));
            }
            else
            {
                UIManager.GetInstance().ShowUIForms(nameof(YolkNeedy));
            }
        }
        else
        {
            UIManager.GetInstance().ShowUIForms(nameof(OutriggerYolk));
        }
    }

    public List<int> OutriggerGrant= new List<int>() {
        {205},{206},{207},{209},{210},{211}
    };
    public void QuicklyArena(HapticPatterns.PresetType type)
    {

#if UNITY_EDITOR
        //Debug.Log("震动");
#else
        if (MeArena)
        {
            HapticPatterns.PlayPreset(type);
        }
#endif
    }
    public void QuicklyCanal(MusicType.UIMusic sfx)
    {
        if (MeCanal)
        {
            //AudioManager.Instance.PlaySFX(sfx);
            MusicMgr.GetInstance().PlayEffect(sfx);
        }
    }
    //暂定指定的音效
    public void QuicklyRockCanal(MusicType.UIMusic sfx)
    {
        if (MeCanal)
        {
            //AudioManager.Instance.StopSFX(sfx);
            MusicMgr.GetInstance().StopEffect(sfx);
        }
    }

    public void PlaguePomegranate(RectTransform ObjRect)
    {
        ObjRect.localScale = new Vector2((float)Screen.width / 1080, (float)Screen.width / 1080);
    }

    /// <summary>
    /// 将秒数转化为00:00:00格式
    /// </summary>
    /// <param name="time">秒数</param>
    /// <returns>00:00:00</returns>
    public string OxTernVenice(float time)
    {
        //秒数取整
        int seconds = (int)time;
        //一小时为3600秒 秒数对3600取整即为小时
        int hour = seconds / 3600;
        //一分钟为60秒 秒数对3600取余再对60取整即为分钟
        int minute = seconds % 3600 / 60;
        //对3600取余再对60取余即为秒数
        seconds = seconds % 3600 % 60;
        //返回00:00:00时间格式
        return string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, seconds);
    }

    private int TributaryBread= 0;
    private int SensitivelyBread= 0;
    public int ShyFortKill{ get; set; }
    public int ShyAscent{ get; set; }
    public int ShyIridium{ get; set; }
    public int Slowly{ get; set; }
    //加载挑战关卡
    public void OrganPreferable(StartChallengeState state)
    {
        CharacterBoldMandan = NetInfoMgr.instance.GameData.Challenge_Revive;
        ShyFortKill = 0;
        ShyAscent = 0;
        ShyIridium = 0;
        Slowly = 0;
        MeOutriggerSaguaroYolk = true;
        switch (PlayerPrefs.GetInt(CConfig.NowDayChallenAward))
        {
            case 0:
                TributaryBread = 208;
                SensitivelyBread = 0;
                RaftMeeting.instance.SkinGrant(208);
                break;
            case 1:
                TributaryBread = 212;
                RaftMeeting.instance.SkinGrant(212);
                break;
            case 2:
                if (SensitivelyBread == 0)
                {
                    SensitivelyBread = OutriggerGrant[UnityEngine.Random.Range(0, OutriggerGrant.Count)];
                }
                TributaryBread = SensitivelyBread;
                RaftMeeting.instance.SkinGrant(SensitivelyBread);
                break;
            default:
                UIManager.GetInstance().ShowUIForms(nameof(TuckNeedy));
                break;
        }

        switch (state)
        {
            case StartChallengeState.Challenge:
                PostEventScript.GetInstance().SendEvent("1013", TributaryBread.ToString());
                break;
            case StartChallengeState.Pop:
                PostEventScript.GetInstance().SendEvent("1014", TributaryBread.ToString());
                break;
            case StartChallengeState.SettingTryAgain:
                PostEventScript.GetInstance().SendEvent("1015", TributaryBread.ToString());
                break;
            case StartChallengeState.FailTryAgain:
                PostEventScript.GetInstance().SendEvent("1016", TributaryBread.ToString());
                break;
            case StartChallengeState.Win:
                PostEventScript.GetInstance().SendEvent("1017", TributaryBread.ToString());
                break;
            default:
                break;
        }
    }

    public int ActCharacterBread()
    {
        return TributaryBread;
    }

    /// <summary>
    /// DOTween.Sequence延时回调
    /// </summary>
    /// <param name="delayedTimer">延时的时间</param>
    /// <param name="loopTimes">循环次数，0:不循环；负数：无限循环；正数：循环多少次</param>
    public void DOForthDutchmanFlop(float delayedTimer, int loopTimes , System.Action action)
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
        {
            action();
        })
        .SetDelay(delayedTimer)
        .SetLoops(loopTimes);
    }

    private TrackEntryDelegate ID= null;
    /// <summary>
    /// 播放动画
    /// </summary>
    /// <param name="sg"></param>
    /// <param name="func"></param>
    /// <param name="index"></param>
    /// <param name="animName"></param>
    /// <param name="loop"></param>
    public void GlueMaya(SkeletonGraphic skeleton, Action func, int trackIndex, string animName, bool loop)
    {
        if (skeleton != null)
        {
            GlueMaya(skeleton, trackIndex, animName, loop);
            ID = delegate
            {
                if (func != null)
                {
                    func();
                }
                skeleton.AnimationState.Complete -= ID;
                ID = null;
            };
            skeleton.AnimationState.Complete += ID;
        }
    }
    /// <summary>
    /// 停止动画播放
    /// </summary>
    /// <param name="sg"></param>
    /// <param name="trackIndex"></param>
    public void RockMaya(SkeletonGraphic sg, int trackIndex, float mixDuration)
    {
        sg.AnimationState.SetEmptyAnimation(trackIndex, mixDuration);
    }

    /// <summary>
    /// 播放动画
    /// </summary>
    /// <param name="sg"></param>
    /// <param name="index"></param>
    /// <param name="animName"></param>
    /// <param name="loop"></param>
    public void GlueMaya(SkeletonGraphic skeleton, int trackIndex, string animName, bool loop)
    {
        if (skeleton != null)
        {
            skeleton.AnimationState.SetAnimation(trackIndex, animName, loop);
        }
    }
}

public class RewardPanelData
{
    /// <summary>
    /// 小游戏类型
    /// </summary>
    public string ForkNext;
    public Dictionary<RewardType, double> Lug_Thirty;

    public RewardPanelData()
    {
        Lug_Thirty = new();
    }
}

public static class MessageCode
{
    public static string SaguaroNose= "10001";
    public static string RaftCattle= "10003";
}

public enum StartChallengeState
{
    Challenge,
    Pop,
    SettingTryAgain,
    FailTryAgain,
    Win,
}

public enum PropType
{
    Roll,
    Remind,
    Refresh,
}

public enum RewardType
{
    shuffle, //刷新
    cash,    //现金
    gold,    //金币
    undo,    //撤回
    wand,    //魔法棒
}

public class RewardData
{
    public string type;
    public double weight;
    //public double weight
    //{
    //    get
    //    {
    //        if (type == "cash")
    //        {
    //            return weight * GameUtil.GetCashWeightMulti();
    //        }
    //        return weight;
    //    }
    //    set
    //    {
    //        weight = value;
    //    }
    //}
    public double num;
    //public double num
    //{
    //    get
    //    {
    //        if (CommonUtil.IsApple())
    //        {
    //            return _num;
    //        }
    //        if (type == "cash")
    //        {
    //            return Math.Round(_num * GameUtil.GetCashMultiWithOutRandom(), 2);
    //        }
    //        if (type == "gold")
    //        {
    //            return Math.Round(_num * GameUtil.GetGoldMulti(), 0);
    //        }
    //        return _num;
    //    }
    //    set
    //    {
    //        _num = value;
    //    }
    //}

}

public class TileTurnData
{
    public string type;
    private double Resale;
    public double Effect{
        get
        {
            if (type == "cash")
            {
                return Resale * GameUtil.GetCashWeightMulti();
            }

            return Resale;
        }
        set
        {
            Resale = value;
        }
    }
    private double _Sad;
    public double Sad{
        get
        {
            if (type == "cash")
            {
                return Math.Round(_Sad * GameUtil.GetCashMultiWithOutRandom(), 2);
            }
            if (type == "gold")
            {
                return Math.Round(_Sad * GameUtil.GetGoldMulti(), 0);
            }
            return _Sad;
        }
        set
        {
            _Sad = value;
        }
    }
}
