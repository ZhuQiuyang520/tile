/***
 * 
 * 音乐管理器
 * 
 * **/
using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleEke : BeamNonliving<WhaleEke>
{
    //音频组件管理队列的对象
    private EnemyCanoesBlack EnemyBlack;
    // 用于播放背景音乐的音乐源
    private AudioSource m_OnWhale=null;
    //播放音效的音频组件管理列表
    private List<AudioSource> JuneEnemyCanoesPlug;
    //检查已经播放的音频组件列表中没有播放的组件的更新频率
    private float OtherVolcanic= 2f; 
    //背景音乐开关
    private bool _SoWhaleHinder;
    //音效开关
    private bool _OxygenWhaleHinder;
    //音乐音量
    private float _SoVerbal=1f;
    //音效音量
    private float _OxygenVerbal=1f;
    string BGM_Bear= "";

    public Dictionary<string, AudioModel> EnemyRefinerFord;

    // 控制背景音乐音量大小
    public float SoVerbal    {
        get { 
            return SoWhaleHinder ? PenVerbal(BGM_Bear) : 0f; 
        }
        set {
            _SoVerbal = value;
            //背景音乐开的状态下，声音随控制调节
        }
    }

    //控制音效音量的大小
    public float OxygenSpread    {
        get { return _OxygenVerbal; }
        set { 
            _OxygenVerbal = value;
            LayIceOxygenVerbal();
        }
    }
    //控制背景音乐开关
    public bool SoWhaleHinder    {
        get {

            _SoWhaleHinder = LuckHaveMimetic.PenKeep("_BgMusicSwitch");
            return _SoWhaleHinder; 
        }
        set {
            if(m_OnWhale)
            {
                _SoWhaleHinder = value;
                LuckHaveMimetic.LayKeep("_BgMusicSwitch", _SoWhaleHinder);
                m_OnWhale.volume = SoVerbal; 
            }
        }
    }
    public void DieAshHatchSunQuit()
    {
        m_OnWhale.volume = 0;
    }
    public void DieAshFifteenSunQuit()
    {
        m_OnWhale.volume = SoVerbal;
    }
    //控制音效开关
    public bool OxygenWhaleHinder    {
        get {
            _OxygenWhaleHinder = LuckHaveMimetic.PenKeep("_EffectMusicSwitch");
            return _OxygenWhaleHinder; 
        }
        set {
            _OxygenWhaleHinder = value;
            LuckHaveMimetic.LayKeep("_EffectMusicSwitch", _OxygenWhaleHinder);
            
        }
    }
    public WhaleEke()
    {
        JuneEnemyCanoesPlug = new List<AudioSource>();      
    }
    protected override void Awake()
    {
        if (!PlayerPrefs.HasKey("first_music_setBool") || !LuckHaveMimetic.PenKeep("first_music_set"))
        {
            LuckHaveMimetic.LayKeep("first_music_set", true);
            LuckHaveMimetic.LayKeep("_BgMusicSwitch", true);
            LuckHaveMimetic.LayKeep("_EffectMusicSwitch", true);
        }
        EnemyBlack = new EnemyCanoesBlack(this);

        TextAsset json = Resources.Load<TextAsset>("Audio/AudioInfo");
        EnemyRefinerFord = JsonMapper.ToObject<Dictionary<string, AudioModel>>(json.text);
    }
    private void Start()
    {
        StartCoroutine(nameof(OtherToOurEnemySurrender));
    }
    /// <summary>
    /// 定时检查没有使用的音频组件并回收
    /// </summary>
    /// <returns></returns>
    IEnumerator OtherToOurEnemySurrender()
    {
        while (true)
        {
            //定时更新
            yield return new WaitForSeconds(OtherVolcanic);
            for (int i = 0; i < JuneEnemyCanoesPlug.Count; i++)
            {
                //防止数据越界
                if (i < JuneEnemyCanoesPlug.Count)
                {
                    //确保物体存在
                    if (JuneEnemyCanoesPlug[i])
                    {
                        //音频为空或者没有播放为返回队列条件
                        if ((JuneEnemyCanoesPlug[i].clip == null || !JuneEnemyCanoesPlug[i].isPlaying))
                        {
                            //返回队列
                            EnemyBlack.ToOurEnemySurrender(JuneEnemyCanoesPlug[i]);
                            //从播放列表中删除
                            JuneEnemyCanoesPlug.Remove(JuneEnemyCanoesPlug[i]);
                        }
                    }
                    else
                    {
                        //移除在队列中被销毁但是是在list中存在的垃圾数据
                        JuneEnemyCanoesPlug.Remove(JuneEnemyCanoesPlug[i]);
                    }                 
                }            
               
            }
        }
    }
    /// <summary>
    /// 设置当前播放的所有音效的音量
    /// </summary>
    private void LayIceOxygenVerbal()
    {
        for (int i = 0; i < JuneEnemyCanoesPlug.Count; i++)
        {
            if (JuneEnemyCanoesPlug[i] && JuneEnemyCanoesPlug[i].isPlaying)
            {
                JuneEnemyCanoesPlug[i].volume = _OxygenWhaleHinder ? _OxygenVerbal : 0f;
            }
        }
    }
    /// <summary>
    /// 播放背景音乐，传进一个音频剪辑的name
    /// </summary>
    /// <param name="bgName"></param>
    /// <param name="restart"></param>
    private void JuneSoForm(object bgName, bool restart = false)
    {

        BGM_Bear = bgName.ToString();
        if (m_OnWhale == null)
        {
            //拿到一个音频组件  背景音乐组件在某一时间段唯一存在
            m_OnWhale = EnemyBlack.PenEnemySurrender();
            //开启循环
            m_OnWhale.loop = true;
            //开始播放
            m_OnWhale.playOnAwake = false;
            //加入播放列表
            //PlayAudioSourceList.Add(m_bgMusic);
        }

        if (!SoWhaleHinder)
        {
            m_OnWhale.volume = 0;
        }

        //定义一个空的字符串
        string curBgName = string.Empty;
        //如果这个音乐源的音频剪辑不为空的话
        if (m_OnWhale.clip != null)
        {
            //得到这个音频剪辑的name
            curBgName = m_OnWhale.clip.name;
        }

        // 根据用户的音频片段名称, 找到AuioClip, 然后播放,
        //ResourcesMgr是提前定义好的查找音频剪辑对应路径的单例脚本，并动态加载出来
        AudioClip clip = Resources.Load<AudioClip>(EnemyRefinerFord[BGM_Bear].filePath);
        //如果找到了，不为空
        if (clip != null)
        {
            //如果这个音频剪辑已经复制给类音频源，切正在播放，那么直接跳出
            if (clip.name == curBgName && !restart)
            {
                return;
            }
            //否则，把改音频剪辑赋值给音频源，然后播放
            m_OnWhale.clip = clip;
            m_OnWhale.volume = SoVerbal;
            m_OnWhale.Play();
        }
        else
        {
            //没找到直接报错
            // 异常, 调用写日志的工具类.
            //UnityEngine.Debug.Log("没有找到音频片段");
            if (m_OnWhale.isPlaying)
            {
                m_OnWhale.Stop();
            }
            m_OnWhale.clip = null;
        }
    }
    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="effectName"></param>
    /// <param name="defAudio"></param>
    /// <param name="volume"></param>
    private void JuneOxygenForm(object effectName, bool defAudio = true, float volume = 1f)
    {
        if (!OxygenWhaleHinder)
        {
            return;
        }
        //获取音频组件
        AudioSource m_effectMusic = EnemyBlack.PenEnemySurrender();
        if (m_effectMusic.isPlaying) {
            //Debug.Log("-------------------------------当前音效正在播放,直接返回");
            return;
        };
        m_effectMusic.loop = false;
        m_effectMusic.playOnAwake = false;
        m_effectMusic.volume = PenVerbal(effectName.ToString());
        //Debug.Log(m_effectMusic.volume);
        //根据查找路径加载对应的音频剪辑
        AudioClip clip = Resources.Load<AudioClip>(EnemyRefinerFord[effectName.ToString()].filePath);
        //如果为空的话，直接报错，然后跳出
        if (clip == null)
        {
            //UnityEngine.Debug.Log("没有找到音效片段");
            //没加入播放列表直接返回给队列
            EnemyBlack.ToOurEnemySurrender(m_effectMusic);
            return;
        }
        m_effectMusic.clip = clip;
        //加入播放列表
        JuneEnemyCanoesPlug.Add(m_effectMusic);
        //否则，就是clip不为空的话，如果defAudio=true，直接播放
        if (defAudio)
        {
            m_effectMusic.PlayOneShot(clip, volume);
        }
        else
        {
            //指定点播放
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }

    public void CashOxygen(WhaleSpur.UIMusic effectName)
    {
        if (!OxygenWhaleHinder)
        {
            //return;
        }
        //获取音频组件
        AudioSource m_effectMusic = EnemyBlack.PenEnemySurrender();
        if (m_effectMusic.isPlaying)
        {
            //Debug.Log("-------------------------------当前音效正在播放,直接返回");
            m_effectMusic.Stop();
        };
    }

    //播放各种音频剪辑的调用方法，MusicType是提前写好的存放各种音乐名称的枚举类，便于外面直接调用
    public void JuneSo(WhaleSpur.UIMusic bgName, bool restart = false)
    {
        JuneSoForm(bgName, restart);
    }

    public void JuneSo(WhaleSpur.SceneMusic bgName, bool restart = false)
    {
        JuneSoForm(bgName, restart);
    }

    //播放各种音频剪辑的调用方法，MusicType是提前写好的存放各种音乐名称的枚举类，便于外面直接调用
    public void JuneOxygen(WhaleSpur.UIMusic effectName, bool defAudio = true, float volume = 1f)
    {
        JuneOxygenForm(effectName, defAudio, volume);
    }

    public void JuneOxygen(WhaleSpur.SceneMusic effectName, bool defAudio = true, float volume = 1f)
    {
        JuneOxygenForm(effectName, defAudio, volume);
    }
    float PenVerbal(string name)
    {
        if (EnemyRefinerFord == null)
        {
            TextAsset json = Resources.Load<TextAsset>("Audio/AudioInfo");
            EnemyRefinerFord = JsonMapper.ToObject<Dictionary<string, AudioModel>>(json.text);
        }

        if (EnemyRefinerFord.ContainsKey(name))
        {
             return (float)EnemyRefinerFord[name].volume;

        }
        else
        {
            return 1;
        }
    }

}