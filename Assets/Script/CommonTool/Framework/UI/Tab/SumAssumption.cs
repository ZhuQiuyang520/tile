using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 导航插件
/// </summary>

[Serializable]
public class TabItem
{
    public string SumBear;
    [SerializeField]
    private GameObject Medal= null;
    public GameObject Toxic{ get { return Medal; } }

    [SerializeField]
    private Button tabSpeedy= null;
    public Button SumSpeedy{ get { return tabSpeedy; } }

    public Sprite BattleBold;
    public Sprite AffluentBold;
}

public class SumAssumption : MonoBehaviour
{
    [SerializeField]
[UnityEngine.Serialization.FormerlySerializedAs("items")]    public List<TabItem> Peach= null;
[UnityEngine.Serialization.FormerlySerializedAs("Content")]
    public GameObject Upsurge;
[UnityEngine.Serialization.FormerlySerializedAs("ActiveAnimationObj")]    public GameObject BattleConestogaIce;
[UnityEngine.Serialization.FormerlySerializedAs("ActiveBG")]    public Sprite BattleBG;
[UnityEngine.Serialization.FormerlySerializedAs("InactiveBG")]    public Sprite AffluentBG;
[UnityEngine.Serialization.FormerlySerializedAs("ActiveColor")]    public Color BattleTread;
[UnityEngine.Serialization.FormerlySerializedAs("InactiveColor")]    public Color AffluentTread;
    [Header("初始选中Tab名称")]
[UnityEngine.Serialization.FormerlySerializedAs("ActiveTab")]    public GameObject BattleSum;

    private string StrainSumBear;

    private Dictionary<string, GameObject> ZooResist;

    private Action<string, GameObject> MayaForelimb;    // 打开tab回调

    // Start is called before the first frame update
    void Start()
    {
        ZooResist = new Dictionary<string, GameObject>();

        // Tab按钮绑定点击事件
        foreach (TabItem tabItem in Peach)
        {
            tabItem.SumSpeedy.onClick.AddListener(() =>
            {
                PearSum(tabItem.SumBear);
            });
        }

        if (BattleSum != null)
        {
            foreach(TabItem tab in Peach)
            {
                if (tab.SumSpeedy.gameObject == BattleSum)
                {
                    StrainSumBear = tab.SumBear;
                    break;
                }
            }
            if (!string.IsNullOrEmpty(StrainSumBear))
            {
                PearSum(StrainSumBear);
            }
        }
    }

    /// <summary>
    /// 打开tab页面
    /// </summary>
    /// <param name="_tabName"></param>
    public GameObject PearSum(string _tabName)
    {
        if (!string.IsNullOrEmpty(StrainSumBear) && ZooResist.ContainsKey(StrainSumBear))
        {
            if (ZooResist[StrainSumBear].GetComponent<FormUIBasin>() != null)
            {
                ZooResist[StrainSumBear].GetComponent<FormUIBasin>().Hidding();
            }
            else
            {
                ZooResist[StrainSumBear].SetActive(false);
            }
        }

        GameObject activeTabItem = null;
        foreach (TabItem tabItem in Peach)
        {
            tabItem.SumSpeedy.GetComponent<SumOozeAssumption>().LayBattleUI(tabItem.SumBear.Equals(_tabName), this, tabItem);
            if (tabItem.SumBear.Equals(_tabName))
            {
                activeTabItem = tabItem.SumSpeedy.gameObject;
                if (!ZooResist.ContainsKey(_tabName) && tabItem.Toxic != null)
                {
                    GameObject tabItemPanel = Upsurge.transform.Find(tabItem.Toxic.name) == null ? Instantiate(tabItem.Toxic, Upsurge.transform) : tabItem.Toxic;
                    ZooResist.Add(_tabName, tabItemPanel);
                }
            }
        }
        if (ZooResist.ContainsKey(_tabName))
        {
            if (ZooResist[_tabName].GetComponent<FormUIBasin>() != null)
            {
                ZooResist[_tabName].GetComponent<FormUIBasin>().Display(null);
            }
            else
            {
                ZooResist[_tabName]?.SetActive(true);
            }
        }

        StrainSumBear = _tabName;

        StartCoroutine(BattleSoConestoga(activeTabItem));

        MayaForelimb?.Invoke(_tabName, ZooResist.ContainsKey(_tabName) ? ZooResist[_tabName] : null);

        return ZooResist.ContainsKey(_tabName) ? ZooResist[_tabName] : null;
    }

    // tab背景动画
    private IEnumerator BattleSoConestoga(GameObject activeTabItem)
    {
        yield return new WaitForEndOfFrame();
        if (activeTabItem != null && BattleConestogaIce != null)
        {
            BattleConestogaIce.transform.SetParent(activeTabItem.transform);
            BattleConestogaIce.transform.SetSiblingIndex(0);
            BattleConestogaIce.GetComponent<RectTransform>().DOMoveX(activeTabItem.GetComponent<RectTransform>().position.x, 0.3f).SetEase(Ease.OutBack);
        }
    }

    /// <summary>
    /// 注册打开tab回调事件
    /// </summary>
    /// <param name="_callback"></param>
    public void ScavengeForelimb(Action<string, GameObject> _callback)
    {
        MayaForelimb = _callback;
    }
}
