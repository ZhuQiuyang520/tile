using DG.Tweening;
using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkOceanNeedy : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("bigWheelItem")]    //public List<GameObject> LightList;
[UnityEngine.Serialization.FormerlySerializedAs("BedQueenMine")]    public GameObject JarPivotVine;
[UnityEngine.Serialization.FormerlySerializedAs("smallWheelItem")]    [UnityEngine.Serialization.FormerlySerializedAs("MoodyQueenMine")]public GameObject PinonPivotVine;
[UnityEngine.Serialization.FormerlySerializedAs("smallWheel")]    [UnityEngine.Serialization.FormerlySerializedAs("MoodyQueen")]public GameObject PinonPivot;
[UnityEngine.Serialization.FormerlySerializedAs("bigWheel")]    [UnityEngine.Serialization.FormerlySerializedAs("BedQueen")]public GameObject JarPivot;
[UnityEngine.Serialization.FormerlySerializedAs("pointer")]    [UnityEngine.Serialization.FormerlySerializedAs("Stencil")]public GameObject Provide;
[UnityEngine.Serialization.FormerlySerializedAs("spinButton")]    [UnityEngine.Serialization.FormerlySerializedAs("BellCanopy")]public Button PlaySister;
[UnityEngine.Serialization.FormerlySerializedAs("wheelGroup")]    [UnityEngine.Serialization.FormerlySerializedAs("PlaneLayer")]public GameObject StashPlace;
[UnityEngine.Serialization.FormerlySerializedAs("TurnEffect")]
[UnityEngine.Serialization.FormerlySerializedAs("RiftVenice")]    public GameObject ShoeLovely;
    List<GameObject> JarVineLife;
    bool ByFree= false;

    private RewardPanelData _UsableWeed;

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.Success);
        RaftNonself.GetInstance().EmpireStilt = false;
        ShoeLovely.SetActive(false);
        PlaySister.gameObject.SetActive(true);
        PinePivot();
        _UsableWeed = new RewardPanelData();
    }
    private void Start()
    {
        PlaySister.onClick.AddListener(Play);
    }

    void PinePivot()
    {
        if (!ByFree)
        {
            ByFree = true;
            JarVineLife = new List<GameObject>();
            for (int i = 0; i < 8; i++)
            {
                RewardData rewardItem = NetInfoMgr.instance.GameData.wheel_reward_weight_group[i];
                GameObject bigItem = Instantiate(JarPivotVine, JarPivot.transform);
                string type = rewardItem.type;
                //if (CommonUtil.IsApple() && (type == "cash"))
                //{
                //    type = "gold";
                //}
                bigItem.GetComponent<BigWheelItem>().FlawPost(type);
                bigItem.GetComponent<BigWheelItem>().Fail.text = rewardItem.num.ToString();
                bigItem.transform.eulerAngles = new Vector3(0, 0, -i * (360 / 8f));
                JarVineLife.Add(bigItem);
            }
            for (int i = 0; i < 6; i++)
            {
                WheelMultiItem multiItem = NetInfoMgr.instance.GameData.wheel_reward_multi.cash[i];
                GameObject smallItem = Instantiate(PinonPivotVine, PinonPivot.transform);
                smallItem.GetComponent<SmallWheelItem>().Fail.text = "×" + multiItem.multi.ToString();
                smallItem.transform.eulerAngles = new Vector3(0, 0, i * (360 / 6f));
            }
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                RewardData rewardItem = NetInfoMgr.instance.GameData.wheel_reward_weight_group[i];
                GameObject bigItem = JarVineLife[i];
                bigItem.GetComponent<BigWheelItem>().FlawPost(rewardItem.type);
                bigItem.GetComponent<BigWheelItem>().Fail.text = rewardItem.num.ToString();
            }
        }
        PlaySister.transform.localScale = Vector3.zero;
        PlaySister.transform.DOScale(new Vector3(0.7f, 0.7f, 1), 0.2f).SetDelay(0.2f);
        JarPivot.transform.eulerAngles = new Vector3(0, 0, 180);
        PinonPivot.transform.eulerAngles = new Vector3(0, 0, 0);

    }
    public void Play()
    {
        CashOutManager.GetInstance().AddTaskValue("Wheel", 1);
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_BigWheel);
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        ShoeLovely.SetActive(true);
        int bigIndex = GameUtil.GetRewardIndexWithWeight(NetInfoMgr.instance.GameData.wheel_reward_weight_group);
        RewardData rewardData = NetInfoMgr.instance.GameData.wheel_reward_weight_group[bigIndex];
        int smallIndex = GameUtil.GetWheelMultiIndex(rewardData.type);
        //if (!SaveDataManager.GetBool("notFirstWheel"))
        //{
        //    SaveDataManager.SetBool("notFirstWheel", true);
        //    bigIndex = 2;
        //    smallIndex = 4;
        //    rewardData = NetInfoMgr.instance.GameData.wheel_reward_weight_group[bigIndex];
        //}
        float multi = (float)NetInfoMgr.instance.GameData.wheel_reward_multi.cash[smallIndex].multi;

        JarPivot.transform.DORotate(new Vector3(0, 0, 360 * 10 + (360 / 8f) * bigIndex), 3f, RotateMode.FastBeyond360).SetDelay(0.2f).SetEase(Ease.InOutSine);
        PinonPivot.transform.DORotate(new Vector3(0, 0, -360 * 10 - (360 / 6f) * smallIndex), 3f, RotateMode.FastBeyond360).SetDelay(0.2f).SetEase(Ease.InOutSine).OnComplete(() => {
            StartCoroutine(PlayToeIngenuity(() =>
            {
                Debug.Log(rewardData.type + ", " + rewardData.num + ", ×" + multi);
                AddYouThirtyNeedy(rewardData.type, multi * (float)rewardData.num);
            }));
        });
        PlaySister.gameObject.SetActive(false);
        
    }
    IEnumerator ProvideIngenuity()
    {
        yield return new WaitForSeconds(0.2f);
        Sequence seq = DOTween.Sequence();
        seq.Append(Provide.transform.DOLocalRotate(new Vector3(0, 0, -20 + UnityEngine.Random.Range(-2f, 2f)), 2f / 36 * 0.3f)
            .SetEase(Ease.Linear));
        seq.Append(Provide.transform.DOLocalRotate(new Vector3(0, 0, 0), 2f / 36 * 0.7f).SetEase(Ease.Linear));
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
    public IEnumerator PlayToeIngenuity(System.Action finish)
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
    public void AddYouThirtyNeedy(string type, float num)
    {
        RewardType rewardType = RewardType.gold;
        if (type == "cash")
        {
            rewardType = RewardType.cash;
            if (CommonUtil.IsApple())
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
        _UsableWeed.ForkNext = "LuckyWheel";
       
        _UsableWeed.Lug_Thirty.Add(rewardType, num);
        CloseUIForm(GetType().Name);
        UIManager.GetInstance().ShowUIForms(nameof(FavorBlurNeedy),_UsableWeed);
        
        ADManager.Instance.ResumeTimeInterstitial();
    }
}
