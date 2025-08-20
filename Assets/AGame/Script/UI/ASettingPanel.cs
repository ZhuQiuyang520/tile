using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>  </summary>
public class ASettingPanel : AUIWindow
{
    
    public GameObject MusicOn;
    public GameObject MusicOff;
    public GameObject SoundOn;
    public GameObject SoundOff;
    public Button MusicBtn;
    public Button SoundBtn;
    public Button BackGameBtn;
    public Button ReplayBtn;

    private Action onReplay;

    public override void OnCreate()
    {
        base.OnCreate();
        
        BackGameBtn.onClick.AddListener((() =>
        {
            A_AudioManager.Instance.PlaySound("ClickBtn");
            CloseUI();
        }));
        ReplayBtn.onClick.AddListener((() =>
        {
            A_AudioManager.Instance.PlaySound("ClickBtn");
            onReplay?.Invoke();
            CloseUI();
        }));
        MusicBtn.onClick.AddListener((() =>
        {
            A_AudioManager.Instance.PlaySound("ClickBtn");
            Music();
        }));
        SoundBtn.onClick.AddListener((() =>
        {
            A_AudioManager.Instance.PlaySound("ClickBtn");
            Sound();
        }));
    }
    
    public override void OnRefresh()
    {
        base.OnRefresh();
        onReplay = UserDatas[0] as Action;
        AGameModule.Base.PauseGame();
        MusicOn.SetActive(A_AudioManager.Instance.isMusicOn);
        MusicOff.SetActive(!A_AudioManager.Instance.isMusicOn);
        SoundOn.SetActive(A_AudioManager.Instance.isSoundOn);
        SoundOff.SetActive(!A_AudioManager.Instance.isSoundOn);
    }

    public override void OnClose()
    {
        base.OnClose();
        AGameModule.Base.ResumeGame();
    }

    public void Music()
    {
        A_AudioManager.Instance.ToggleMusic();
        var music = A_AudioManager.Instance.isMusicOn;
        MusicOn.SetActive(music);
        MusicOff.SetActive(!music);
    }
    public void Sound()
    {
        A_AudioManager.Instance.ToggleSound();
        var sound = A_AudioManager.Instance.isSoundOn;
        SoundOn.SetActive(sound);
        SoundOff.SetActive(!sound);
        
    }
}
