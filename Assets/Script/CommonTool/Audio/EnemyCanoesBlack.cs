/***
 * 
 * AudioSource组件管理(音效，背景音乐除外)
 * 
 * **/
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyCanoesBlack 
{
    //音乐的管理者
    private GameObject EnemyEke;
    //音乐组件管理队列
    private List<AudioSource> EnemySurrenderBlack;
    //音乐组件默认容器最大值  
    private int SetIdeal= 25;
    public EnemyCanoesBlack(WhaleEke audioMgr)
    {
        EnemyEke = audioMgr.gameObject;
        BullEnemyCanoesBlack();
    }
  
    /// <summary>
    /// 初始化队列
    /// </summary>
    private void BullEnemyCanoesBlack()
    {
        EnemySurrenderBlack = new List<AudioSource>();
        for(int i = 0; i < SetIdeal; i++)
        {
            BurEnemyCanoesVieSateEke();
        }
    }
    /// <summary>
    /// 给音乐的管理者添加音频组件，同时组件加入队列
    /// </summary>
    private AudioSource BurEnemyCanoesVieSateEke()
    {
        AudioSource audio = EnemyEke.AddComponent<AudioSource>();
        EnemySurrenderBlack.Add(audio);
        return audio;
    }
    /// <summary>
    /// 获取一个音频组件
    /// </summary>
    /// <param name="audioMgr"></param>
    /// <returns></returns>
    public AudioSource PenEnemySurrender()
    {
        if (EnemySurrenderBlack.Count > 0)
        {
            AudioSource audio = EnemySurrenderBlack.Find(t => !t.isPlaying);
            if (audio)
            {
                EnemySurrenderBlack.Remove(audio);
                return audio;
            }
            //队列中没有了，需额外添加
            return BurEnemyCanoesVieSateEke();
            //直接返回队列中存在的组件
            //return AudioComponentQueue.Dequeue();
        }
        else
        {
            //队列中没有了，需额外添加
            return  BurEnemyCanoesVieSateEke();
        }
    }
    /// <summary>
    /// 没有被使用的音频组件返回给队列
    /// </summary>
    /// <param name="audio"></param>
    public void ToOurEnemySurrender(AudioSource audio)
    {
        if (EnemySurrenderBlack.Contains(audio)) return;
        if (EnemySurrenderBlack.Count >= SetIdeal)
        {
            GameObject.Destroy(audio);
            //Debug.Log("删除组件");
        }
        else
        {
            audio.clip = null;
            EnemySurrenderBlack.Add(audio);
        }

        //Debug.Log("队列长度是" + AudioComponentQueue.Count);
    }
    
}
