using DG.Tweening;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Spine.AnimationState;

public class RoadTenuous : MonoSingleton<RoadTenuous>
{
    public bool ReliefStilt{ get; set; }
    public bool TelescopeStilt{ get; set; }
    public bool OfTelescope{ get; set; }
    public bool OfRadishTelescope{ get; set; }
    public bool OfPearl{ get; set; }
    public bool OfStuff{ get; set; }
    public bool OfCharm{ get; set; }

    public bool OfIdeal{ get; set; }

    public bool OfTelescopeBookletTerm{ get; set; }

    public int ChallengeFailNumber { get; set; }

    public void ChallengeFail()
    {
        if (ChallengeFailNumber > 0)
        {
            ChallengeFailNumber--;
            UIManager.GetInstance().ShowUIForms(nameof(TermLoder));
        }
        else
        {
            UIManager.GetInstance().ShowUIForms(nameof(TelescopeTerm));
        }
    }

    public List<int> TelescopeBleak= new List<int>() {
        {200},{201},{203},{204},{205}
    };
    public void UsuallyStuff()
    {
#if UNITY_EDITOR
        //Debug.Log("震动");
#else
        if (OfStuff)
        {
            Handheld.Vibrate();
        }
#endif
    }
    public void UsuallyCharm(MusicType.UIMusic sfx)
    {
        if (OfCharm)
        {
            //AudioManager.Instance.PlaySFX(sfx);
            MusicMgr.GetInstance().PlayEffect(sfx);
        }
    }
    //暂定指定的音效
    public void UsuallySectCharm(MusicType.UIMusic sfx)
    {
        if (OfCharm)
        {
            //AudioManager.Instance.StopSFX(sfx);
            MusicMgr.GetInstance().StopEffect(sfx);
        }
    }

    public void ThrustUnpublished(RectTransform ObjRect)
    {
        ObjRect.localScale = new Vector2((float)Screen.width / 1080, (float)Screen.width / 1080);
    }

    /// <summary>
    /// 将秒数转化为00:00:00格式
    /// </summary>
    /// <param name="time">秒数</param>
    /// <returns>00:00:00</returns>
    public string OxPassWindow(float time)
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

    //加载挑战关卡
    public void StoveCrossbones()
    {
        ChallengeFailNumber = NetInfoMgr.instance.GameData.Challenge_Revive;
        OfTelescopeBookletTerm = true;
        switch (PlayerPrefs.GetInt(CConfig.NowDayChallenAward))
        {
            case 0:
                RoadBrother.instance.BeamBleak(202);
                break;
            case 1:
                RoadBrother.instance.BeamBleak(206);
                break;
            case 2:
                RoadBrother.instance.BeamBleak(TelescopeBleak[UnityEngine.Random.Range(0, TelescopeBleak.Count)]);
                break;
                UIManager.GetInstance().ShowUIForms(nameof(TuskLoder));
            default:
                break;
        }
    }

    /// <summary>
    /// DOTween.Sequence延时回调
    /// </summary>
    /// <param name="delayedTimer">延时的时间</param>
    /// <param name="loopTimes">循环次数，0:不循环；负数：无限循环；正数：循环多少次</param>
    public void DODailyHumilityIbex(float delayedTimer, int loopTimes , System.Action action)
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
    public void LikeLace(SkeletonGraphic skeleton, Action func, int trackIndex, string animName, bool loop)
    {
        if (skeleton != null)
        {
            LikeLace(skeleton, trackIndex, animName, loop);
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
    public void SectLace(SkeletonGraphic sg, int trackIndex, float mixDuration)
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
    public void LikeLace(SkeletonGraphic skeleton, int trackIndex, string animName, bool loop)
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
    public string NoseHard;
    public Dictionary<RewardType, double> Rim_Marlin;

    public RewardPanelData()
    {
        Rim_Marlin = new();
    }
}

public static class MessageCode
{
    public static string BookletBoth= "10001";
    public static string RoadElliot= "10003";
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
    private double _Trader;
    public double Trader    {
        get
        {
            if (type == "cash")
            {
                return _Trader * GameUtil.GetCashWeightMulti();
            }
            return _Trader;
        }
        set
        {
            _Trader = value;
        }
    }
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
    private double _Trader;
    public double Trader    {
        get
        {
            if (type == "cash")
            {
                return _Trader * GameUtil.GetCashWeightMulti();
            }

            return _Trader;
        }
        set
        {
            _Trader = value;
        }
    }
    private double _Fad;
    public double Fad    {
        get
        {
            if (type == "cash")
            {
                return Math.Round(_Fad * GameUtil.GetCashMultiWithOutRandom(), 2);
            }
            if (type == "gold")
            {
                return Math.Round(_Fad * GameUtil.GetGoldMulti(), 0);
            }
            return _Fad;
        }
        set
        {
            _Fad = value;
        }
    }
}
