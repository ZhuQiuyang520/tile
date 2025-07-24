using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GirlNewlyLoder : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("bigWheelItem")]    //public List<GameObject> LightList;
    public GameObject BedQueenMine;
[UnityEngine.Serialization.FormerlySerializedAs("smallWheelItem")]    public GameObject MoodyQueenMine;
[UnityEngine.Serialization.FormerlySerializedAs("smallWheel")]    public GameObject MoodyQueen;
[UnityEngine.Serialization.FormerlySerializedAs("bigWheel")]    public GameObject BedQueen;
[UnityEngine.Serialization.FormerlySerializedAs("pointer")]    public GameObject Stencil;
[UnityEngine.Serialization.FormerlySerializedAs("spinButton")]    public Button BellCanopy;
[UnityEngine.Serialization.FormerlySerializedAs("wheelGroup")]    public GameObject PlaneLayer;
[UnityEngine.Serialization.FormerlySerializedAs("TurnEffect")]
    public GameObject RiftVenice;
    List<GameObject> BedMineFire;
    bool DyBlue= false;

    private RewardPanelData _SparseNeck;

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        RoadTenuous.GetInstance().ReliefStilt = false;
        RiftVenice.SetActive(false);
        BellCanopy.onClick.RemoveAllListeners();
        BellCanopy.onClick.AddListener(Bell);
        BellCanopy.gameObject.SetActive(true);
        OralQueen();
        _SparseNeck = new RewardPanelData();
    }

    void OralQueen()
    {
        if (!DyBlue)
        {
            DyBlue = true;
            BedMineFire = new List<GameObject>();
            for (int i = 0; i < 8; i++)
            {
                RewardData rewardItem = NetInfoMgr.instance.GameData.wheel_reward_weight_group[i];
                GameObject bigItem = Instantiate(BedQueenMine, BedQueen.transform);
                string type = rewardItem.type;
                //if (CommonUtil.IsApple() && (type == "cash"))
                //{
                //    type = "gold";
                //}
                bigItem.GetComponent<BigWheelItem>().initIcon(type);
                bigItem.GetComponent<BigWheelItem>().text.text = rewardItem.num.ToString();
                bigItem.transform.eulerAngles = new Vector3(0, 0, -i * (360 / 8f));
                BedMineFire.Add(bigItem);
            }
            for (int i = 0; i < 6; i++)
            {
                WheelMultiItem multiItem = NetInfoMgr.instance.GameData.wheel_reward_multi.cash[i];
                GameObject smallItem = Instantiate(MoodyQueenMine, MoodyQueen.transform);
                smallItem.GetComponent<SmallWheelItem>().text.text = "×" + multiItem.multi.ToString();
                smallItem.transform.eulerAngles = new Vector3(0, 0, i * (360 / 6f));
            }
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                RewardData rewardItem = NetInfoMgr.instance.GameData.wheel_reward_weight_group[i];
                GameObject bigItem = BedMineFire[i];
                bigItem.GetComponent<BigWheelItem>().initIcon(rewardItem.type);
                bigItem.GetComponent<BigWheelItem>().text.text = rewardItem.num.ToString();
            }
        }
        BellCanopy.transform.localScale = Vector3.zero;
        BellCanopy.transform.DOScale(new Vector3(0.7f, 0.7f, 1), 0.2f).SetDelay(0.2f);
        BedQueen.transform.eulerAngles = new Vector3(0, 0, 180);
        MoodyQueen.transform.eulerAngles = new Vector3(0, 0, 0);

    }
    public void Bell()
    {
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_BigWheel);
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        RiftVenice.SetActive(true);
        //StartCoroutine(pointerAnimation());
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

        BedQueen.transform.DORotate(new Vector3(0, 0, 360 * 10 + (360 / 8f) * bigIndex), 3f, RotateMode.FastBeyond360).SetDelay(0.2f).SetEase(Ease.InOutSine);
        MoodyQueen.transform.DORotate(new Vector3(0, 0, -360 * 10 - (360 / 6f) * smallIndex), 3f, RotateMode.FastBeyond360).SetDelay(0.2f).SetEase(Ease.InOutSine).OnComplete(() => {
            StartCoroutine(GrowRagWaterfall(() =>
            {
                Debug.Log(rewardData.type + ", " + rewardData.num + ", ×" + multi);
                RyeMobMarlinLoder(rewardData.type, multi * (float)rewardData.num);
            }));
        });
        BellCanopy.gameObject.SetActive(false);
    }
    IEnumerator StencilWaterfall()
    {
        yield return new WaitForSeconds(0.2f);
        Sequence seq = DOTween.Sequence();
        seq.Append(Stencil.transform.DOLocalRotate(new Vector3(0, 0, -20 + UnityEngine.Random.Range(-2f, 2f)), 2f / 36 * 0.3f)
            .SetEase(Ease.Linear));
        seq.Append(Stencil.transform.DOLocalRotate(new Vector3(0, 0, 0), 2f / 36 * 0.7f).SetEase(Ease.Linear));
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
    public IEnumerator GrowRagWaterfall(System.Action finish)
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
    public void RyeMobMarlinLoder(string type, float num)
    {
        RewardType rewardType = RewardType.gold;
        if (type == "cash")
        {
            rewardType = RewardType.cash;
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
        _SparseNeck.NoseHard = "LuckyWheel";
        if (CommonUtil.IsApple())
        {
            rewardType = RewardType.gold;
        }
        _SparseNeck.Rim_Marlin.Add(rewardType, num);
        CloseUIForm(GetType().Name);
        UIManager.GetInstance().ShowUIForms("CargoSkipLoder",_SparseNeck);
        
        ADManager.Instance.ResumeTimeInterstitial();
    }
}
