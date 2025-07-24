/**
 * 
 * 音乐类型管理的枚举列表
 * 
 * **/

//所有音乐名称的枚举列表

public class MusicType
{
    //ui使用的音乐音效
    public enum UIMusic
    {
        None,
        Sound_GoldCoin,
        Sound_OneArmBandit,
        Sound_PopShow,
        Sound_UIButton,
        Sound_Match,
        Sound_Click,
        Sound_Win,
        Sound_Fail,
        Sound_Wand,
        Sound_Shuffle,
        Sound_BigWheel,
        Sound_SmallWheel,
        Sound_Combo3,
        Sound_Combo4,
        Sound_Combo5

    }

    //场景中的音效，包括场景中所有音效，包括背景音效
    public enum SceneMusic
    {
        None,
        Sound_BGM
    }

}

