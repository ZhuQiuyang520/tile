using DG.Tweening;
using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlowBrantToxic : FormUIBasin
{
[UnityEngine.Serialization.FormerlySerializedAs("bigWheelItem")]    //public List<GameObject> LightList;
    public GameObject HowWouldOoze;
[UnityEngine.Serialization.FormerlySerializedAs("smallWheelItem")]    public GameObject GroupWouldOoze;
[UnityEngine.Serialization.FormerlySerializedAs("smallWheel")]    public GameObject GroupWould;
[UnityEngine.Serialization.FormerlySerializedAs("bigWheel")]    public GameObject HowWould;
[UnityEngine.Serialization.FormerlySerializedAs("pointer")]    public GameObject Gradual;
[UnityEngine.Serialization.FormerlySerializedAs("spinButton")]    public Button WellSpeedy;
[UnityEngine.Serialization.FormerlySerializedAs("wheelGroup")]    public GameObject CharmWeary;
[UnityEngine.Serialization.FormerlySerializedAs("TurnEffect")]
    public GameObject BustOxygen;
    List<GameObject> HowOozePlug;
    bool ByBull= false;

    private RewardPanelData _TundraHave;

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.Success);
        OilyMimetic.PenMonopoly().EngineGuess = false;
        BustOxygen.SetActive(false);
        WellSpeedy.gameObject.SetActive(true);
        CostWould();
        _TundraHave = new RewardPanelData();
    }

    private void Start()
    {
        WellSpeedy.onClick.AddListener(Well);
    }

    void CostWould()
    {
        if (!ByBull)
        {
            ByBull = true;
            HowOozePlug = new List<GameObject>();
            for (int i = 0; i < 8; i++)
            {
                RewardData rewardItem = SawSelfEke.instance.OilyHave.wheel_reward_weight_group[i];
                GameObject bigItem = Instantiate(HowWouldOoze, HowWould.transform);
                string type = rewardItem.type;
                //if (TemperFile.IsApple() && (type == "cash"))
                //{
                //    type = "gold";
                //}
                bigItem.GetComponent<BigWheelItem>().initIcon(type);
                bigItem.GetComponent<BigWheelItem>().text.text = rewardItem.num.ToString();
                bigItem.transform.eulerAngles = new Vector3(0, 0, -i * (360 / 8f));
                HowOozePlug.Add(bigItem);
            }
            for (int i = 0; i < 6; i++)
            {
                WheelMultiItem multiItem = SawSelfEke.instance.OilyHave.wheel_reward_multi.cash[i];
                GameObject smallItem = Instantiate(GroupWouldOoze, GroupWould.transform);
                smallItem.GetComponent<SmallWheelItem>().text.text = "×" + multiItem.multi.ToString();
                smallItem.transform.eulerAngles = new Vector3(0, 0, i * (360 / 6f));
            }
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                RewardData rewardItem = SawSelfEke.instance.OilyHave.wheel_reward_weight_group[i];
                GameObject bigItem = HowOozePlug[i];
                bigItem.GetComponent<BigWheelItem>().initIcon(rewardItem.type);
                bigItem.GetComponent<BigWheelItem>().text.text = rewardItem.num.ToString();
            }
        }
        WellSpeedy.transform.localScale = Vector3.zero;
        WellSpeedy.transform.DOScale(new Vector3(0.7f, 0.7f, 1), 0.2f).SetDelay(0.2f);
        HowWould.transform.eulerAngles = new Vector3(0, 0, 180);
        GroupWould.transform.eulerAngles = new Vector3(0, 0, 0);

    }
    public void Well()
    {
        CashOutManager.PenMonopoly().AddTaskValue("Wheel", 1);
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_BigWheel);
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        BustOxygen.SetActive(true);
        //StartCoroutine(pointerAnimation());
        int bigIndex = GameUtil.GetRewardIndexWithWeight(SawSelfEke.instance.OilyHave.wheel_reward_weight_group);
        RewardData rewardData = SawSelfEke.instance.OilyHave.wheel_reward_weight_group[bigIndex];
        int smallIndex = GameUtil.GetWheelMultiIndex(rewardData.type);
        //if (!LuckHaveMimetic.GetBool("notFirstWheel"))
        //{
        //    LuckHaveMimetic.SetBool("notFirstWheel", true);
        //    bigIndex = 2;
        //    smallIndex = 4;
        //    rewardData = SawSelfEke.instance.GameData.wheel_reward_weight_group[bigIndex];
        //}
        float multi = (float)SawSelfEke.instance.OilyHave.wheel_reward_multi.cash[smallIndex].multi;

        HowWould.transform.DORotate(new Vector3(0, 0, 360 * 10 + (360 / 8f) * bigIndex), 3f, RotateMode.FastBeyond360).SetDelay(0.2f).SetEase(Ease.InOutSine);
        GroupWould.transform.DORotate(new Vector3(0, 0, -360 * 10 - (360 / 6f) * smallIndex), 3f, RotateMode.FastBeyond360).SetDelay(0.2f).SetEase(Ease.InOutSine).OnComplete(() => {
            StartCoroutine(LullFatConestoga(() =>
            {
                Debug.Log(rewardData.type + ", " + rewardData.num + ", ×" + multi);
                ThePenGreedyToxic(rewardData.type, multi * (float)rewardData.num);
            }));
        });
        WellSpeedy.gameObject.SetActive(false);
    }
    IEnumerator GradualConestoga()
    {
        yield return new WaitForSeconds(0.2f);
        Sequence seq = DOTween.Sequence();
        seq.Append(Gradual.transform.DOLocalRotate(new Vector3(0, 0, -20 + UnityEngine.Random.Range(-2f, 2f)), 2f / 36 * 0.3f)
            .SetEase(Ease.Linear));
        seq.Append(Gradual.transform.DOLocalRotate(new Vector3(0, 0, 0), 2f / 36 * 0.7f).SetEase(Ease.Linear));
        seq.AppendCallback(() => {
            //HapticPatterns.PlayPreset(HapticPatterns.PresetType.Selection);
        });
        seq.SetLoops(36);
        seq.SetEase(Ease.InOutSine);
        seq.Play();
    }
    /// <summary>
    /// 中奖动画
    /// </summary>
    /// <param name="finish"></param>
    public IEnumerator LullFatConestoga(System.Action finish)
    {
        //var light = DOTween.Sequence();
        //fx_wheel.SetActive(true);
        //light.Append(LightList[0].GetComponent<Image>().DOFade(1, 0.15f));
        //light.Append(LightList[0].GetComponent<Image>().DOFade(0, 0.15f));
        //light.SetLoops(5, LoopType.Restart);
        //var light_1 = DOTween.Sequence();
        //light_1.Append(LightList[1].GetComponent<Image>().DOFade(1, 0.15f));
        //light_1.Append(LightList[1].GetComponent<Image>().DOFade(0, 0.15f));
        //light_1.SetLoops(5, LoopType.Restart);
        yield return new WaitForSeconds(1.5f);
        //LightList[1].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        //LightList[0].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        finish();
    }
    /// <summary>
    /// 弹出奖励弹窗
    /// </summary>
    /// <param name="type">奖励类型</param>
    /// <param name="num">奖励金额</param>
    public void ThePenGreedyToxic(string type, float num)
    {
        RewardType rewardType = RewardType.gold;
        if (type == "cash")
        {
            rewardType = RewardType.cash;
            if (TemperFile.WeSound())
            {
                rewardType = RewardType.gold;
            }
        }
        if (type == "gold")
        {
            rewardType = RewardType.gold;
        }
        if (type == "shuffle")
        {
            rewardType = RewardType.shuffle;
        }
        if (type == "undo")
        {
            rewardType = RewardType.undo;
        }
        if (type == "wand")
        {
            rewardType = RewardType.wand;
        }
        _TundraHave.FameSpur = "LuckyWheel";
        
        _TundraHave.Cut_Greedy.Add(rewardType, num);
        HatchUIWork(GetType().Name);
        UIMimetic.PenMonopoly().BlueUIBasin(nameof(SpikyEasyToxic),_TundraHave);
        
        ADMimetic.Monopoly.MonkeyQuitPreservation();
    }
}
