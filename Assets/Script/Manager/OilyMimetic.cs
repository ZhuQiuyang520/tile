using DG.Tweening;
using Lofelt.NiceVibrations;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Watermelon;
using static Spine.AnimationState;

public class OilyMimetic : BeamNonliving<OilyMimetic>
{
    public bool EngineGuess{ get; set; }
    public bool AdmissionGuess{ get; set; }
    public bool WeAdmission{ get; set; }
    public bool WeVirginAdmission{ get; set; }
    public bool WeFancy{ get; set; }
    public bool WeCoral{ get; set; }
    public bool WeHumid{ get; set; }

    public bool WePenal{ get; set; }

    public bool WeAdmissionStudentHone{ get; set; }

    public int AdmissionHoneFloral{ get; set; }

    public void ModestlyHone()
    {
        if (AdmissionHoneFloral > 0)
        {
            AdmissionHoneFloral--;
            Clothe++;
            UIMimetic.PenMonopoly().BlueUIBasin(nameof(HoneToxic));
        }
        else
        {
            UIMimetic.PenMonopoly().BlueUIBasin(nameof(AdmissionHone));
        }
    }

    public List<int> AdmissionClump= new List<int>() {
        {205},{206},{207},{209},{210},{211}
    };
    public void RefinerCoral(HapticPatterns.PresetType type)
    {
        if (WeCoral)
        {
            HapticPatterns.PlayPreset(type);
        }
    }
    public void RefinerHumid(WhaleSpur.UIMusic sfx)
    {
        if (WeHumid)
        {
            //AudioManager.Instance.PlaySFX(sfx);
            WhaleEke.PenMonopoly().JuneOxygen(sfx);
        }
    }
    //暂定指定的音效
    public void RefinerCashHumid(WhaleSpur.UIMusic sfx)
    {
        if (WeHumid)
        {
            //AudioManager.Instance.StopSFX(sfx);
            WhaleEke.PenMonopoly().CashOxygen(sfx);
        }
    }

    public void PepperFashionable(RectTransform ObjRect)
    {
        ObjRect.localScale = new Vector2((float)Screen.width / 1080, (float)Screen.width / 1080);
    }

    /// <summary>
    /// 将秒数转化为00:00:00格式
    /// </summary>
    /// <param name="time">秒数</param>
    /// <returns>00:00:00</returns>
    public string MyQuitStrive(float time)
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

    private int ProcessorClump= 0;
    private int CommonsenseClump= 0;
    public int OurPeltWarm{ get; set; }
    public int OurFamily{ get; set; }
    public int OurStudent{ get; set; }
    public int Clothe{ get; set; }
    //加载挑战关卡
    public void CrampPerceptual(StartChallengeState state)
    {
        AdmissionHoneFloral = SawSelfEke.instance.OilyHave.Challenge_Revive;
        OurPeltWarm = 0;
        OurFamily = 0;
        OurStudent = 0;
        Clothe = 0;
        WeAdmissionStudentHone = true;
        switch (PlayerPrefs.GetInt(CLagoon.PerHimSeveralSweet))
        {
            case 0:
                ProcessorClump = 208;
                CommonsenseClump = 0;
                OilyVillage.instance.ThenClump(208);
                break;
            case 1:
                ProcessorClump = 212;
                OilyVillage.instance.ThenClump(212);
                break;
            case 2:
                if (CommonsenseClump == 0)
                {
                    CommonsenseClump = AdmissionClump[UnityEngine.Random.Range(0, AdmissionClump.Count)];
                }
                ProcessorClump = AdmissionClump[UnityEngine.Random.Range(0, AdmissionClump.Count)];
                OilyVillage.instance.ThenClump(AdmissionClump[UnityEngine.Random.Range(0, AdmissionClump.Count)]);
                break;
            default:
                UIMimetic.PenMonopoly().BlueUIBasin(nameof(OvenToxic));
                break;
        }

        switch (state)
        {
            case StartChallengeState.Challenge:
                SlayNeverSpiral.PenMonopoly().JumpNever("1013", ProcessorClump.ToString());
                break;
            case StartChallengeState.Pop:
                SlayNeverSpiral.PenMonopoly().JumpNever("1014", ProcessorClump.ToString());
                break;
            case StartChallengeState.SettingTryAgain:
                SlayNeverSpiral.PenMonopoly().JumpNever("1015", ProcessorClump.ToString());
                break;
            case StartChallengeState.FailTryAgain:
                SlayNeverSpiral.PenMonopoly().JumpNever("1016", ProcessorClump.ToString());
                break;
            case StartChallengeState.Win:
                SlayNeverSpiral.PenMonopoly().JumpNever("1017", ProcessorClump.ToString());
                break;
            default:
                break;
        }
    }

    public int PenAdmissionClump()
    {
        return ProcessorClump;
    }

    /// <summary>
    /// DOTween.Sequence延时回调
    /// </summary>
    /// <param name="delayedTimer">延时的时间</param>
    /// <param name="loopTimes">循环次数，0:不循环；负数：无限循环；正数：循环多少次</param>
    public void DODousePlethoraBush(float delayedTimer, int loopTimes , System.Action action)
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
    public void JuneAcre(SkeletonGraphic skeleton, Action func, int trackIndex, string animName, bool loop)
    {
        if (skeleton != null)
        {
            JuneAcre(skeleton, trackIndex, animName, loop);
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
    public void CashAcre(SkeletonGraphic sg, int trackIndex, float mixDuration)
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
    public void JuneAcre(SkeletonGraphic skeleton, int trackIndex, string animName, bool loop)
    {
        if (skeleton != null)
        {
            skeleton.AnimationState.SetAnimation(trackIndex, animName, loop);
        }
    }

    public TileData[] ChildhoodVieClump(List<LevelData1> levelList, TileData[] tiles, LevelData1 level)
    {
        int levelIndex = levelList.FindIndex(x => x == level);
        Debug.Log(levelIndex);
        if (levelIndex != -1)
        {
            return ChildhoodVieClump(levelList, tiles,levelIndex);
        }

        return ChildhoodVieClump(levelList, tiles,0);
    }

    public TileData[] ChildhoodVieClump(List<LevelData1> levelList , TileData[] tiles, int levelId)
    {
        LevelData1 levelData = levelList[levelId];

        List<TileData> result = new List<TileData>();
        List<TileData> ResultReserve = new List<TileData>();

        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i].AvailableFromLevel <= levelId)
            {
                ResultReserve.Add(tiles[i]);
                //result.Add(tiles[i]);
            }
        }
        int PopulateUteClump= Mathf.Clamp(levelData.elementsPerLevel, 1, ResultReserve.Count);
        if (ResultReserve.Count > PopulateUteClump)
        {
            for (int i = 0; i < PopulateUteClump; i++)
            {
                int index = UnityEngine.Random.Range(0, ResultReserve.Count);
                result.Add(ResultReserve[index]);
                ResultReserve.RemoveAt(index);
            }
            return result.ToArray();
        }
        //if (result.Count > elementsPerLevel)
        //{
        //    result.RemoveRange(elementsPerLevel, result.Count - elementsPerLevel);
        //}
        return ResultReserve.ToArray();
    }

}

public class RewardPanelData
{
    /// <summary>
    /// 小游戏类型
    /// </summary>
    public string FameSpur;
    public Dictionary<RewardType, double> Cut_Greedy;

    public RewardPanelData()
    {
        Cut_Greedy = new();
    }
}

public static class MessageCode
{
    public static string StudentRead= "10001";
    public static string OilyRedbud= "10003";
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
    public double num;
}


public class LevelData1
{
    public List<LayersData> layers;
    public LayersData PenThank(int i)
    {
        if (i < layers.Count && i >= 0) return layers[i];

        return null;
    }

    public int PenPierceOfPollenGreat()
    {
        int counter = 0;

        for (int i = 0; i < layers.Count; i++)
        {
            counter += layers[i].PenPierceOfPollenGreat();
        }

        return counter;
    }

    public int bottomLayerWidth;

    public int bottomLayerHeight;

    public bool useInRandomizer;

    public int elementsPerLevel;

    public int coinsReward;

    public string editorNote; // used only in level editor
}

public class LayersData
{
    public List<LayerRow1> rows;

    public LayerRow1 PenOwn(int i)
    {
        if (i < rows.Count && i >= 0) return rows[i];

        return null;
    }

    public int PenPierceOfPollenGreat()
    {
        int counter = 0;

        for (int i = 0; i < rows.Count; i++)
        {
            counter += rows[i].PenPierceOfPollenGreat();
        }
        return counter;
    }
}

public class LayerRow1
{
    public List<CellData> cells;
    public int PenPierceOfPollenGreat()
    {
        int counter = 0;

        for (int i = 0; i < cells.Count; i++)
        {
            if (cells[i].IsFilled) counter++;
        }

        return counter;
    }
}

