using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Watermelon;

public class SlotBehavior : MonoBehaviour
{
    public static SlotBehavior instance;

    public int SortNumber;

    private bool IsValue;
    private string PrefabName;
    private TileBehavior tile;
    private int CurIndex;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InitData();
    }

    public void SettingOrder(int order)
    {
        CurIndex = order *5 + 10;
    }

    //游戏初始化数据
    //方块消除后更新数据
    public void InitData()
    {
        IsValue = false;
        PrefabName = "";
        tile = null;
    }

    //查看当前已赋值的tile名字
    public string ActionPrefabName()
    {
        return PrefabName;
    }

    public bool ActionValue()
    {
        return IsValue;
    }

    public TileBehavior ActionTileBehavior()
    {
        return tile;
    }
    public void CloseTile()
    {
        //tile.gameObject.SetActive(false);
    }

    public void SetPosition(string Prefab , TileBehavior Tile)
    {
        PrefabName = Prefab;
        IsValue = true;
        tile = Tile;
        tile.SetSortingOrder(CurIndex);
    }
}
