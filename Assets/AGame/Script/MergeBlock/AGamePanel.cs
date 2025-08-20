using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AGamePanel : AUIWindow
{
    public override bool FullScreen => true;
    
    public GameObject BlockPrefab;
    public Transform BlockParent;
    public Button SettingBtn;
    public Text ScoreText;
    public Text HighScoreText;
    public Text GoldText;
    public Transform[] BlockColIndex;
    
    private BlockItem[,] blockItemMatrix = new BlockItem[AGameManager.Row, AGameManager.Col];
    private BlockItem dragBlockItem;
    private int score;
    private bool mergeBlock;
    
    public override void OnCreate()
    {
        base.OnCreate();
        SettingBtn.onClick.AddListener((() =>
        {
            ShowUI<ASettingPanel>(new Action(Init));
        }));
        
        AddUIEvent<BlockItem, PointerEventData>(AEventType.BlockBeginDrag, OnBlockBeginDrag);
        AddUIEvent<BlockItem, PointerEventData>(AEventType.BlockEndDrag, OnBlockEndDrag);
        AddUIEvent<BlockItem, PointerEventData>(AEventType.BlockDrag, OnBlockDrag);
    }

    public override void OnClose()
    {
        base.OnClose();
    }

    public override void OnRefresh()
    {
        base.OnRefresh();
        Init();
    }

    private void Init()
    {
        AGameManager.Instance.GameState = AGameState.Playing;
        InitBlocks();
        HighScoreText.text = AGameManager.Instance.HighScore.ToString();
        GoldText.text = AGameManager.Instance.GetCurrGold().ToString();
        score = 0;
        ScoreText.text = score.ToString();
        mergeBlock = false;
    }
    
    public void ClearBlocks()
    {
        for (int i = 0; i < AGameManager.Row; i++)
        {
            for (int j = 0; j < AGameManager.Col; j++)
            {
                if (blockItemMatrix[i, j] != null)
                {
                    Destroy(blockItemMatrix[i, j].gameObject);
                    blockItemMatrix[i, j] = null;
                }
            }
        }

        if (dragBlockItem !)
        {
            Destroy(dragBlockItem.gameObject);
            dragBlockItem = null;
        }
    }
    
    private BlockItem CreateBlock(int index, int num)
    {
        var go = Instantiate(BlockPrefab, BlockParent);
        go.transform.localPosition = BlockColIndex[index].transform.localPosition;
        go.transform.localScale = new Vector3(1, 1, 1);
        go.transform.localRotation = Quaternion.identity;
        var blockItem = go.GetComponent<BlockItem>();
        blockItem.Init(index, num);
        var pos = AGameManager.GetBlockPos(index);
        blockItemMatrix[pos.x, pos.y] = blockItem;
        return blockItem;
    }
    
    private void InitBlocks()
    {
        ClearBlocks();
        var blockTmp = AGameManager.Instance.GetRandomBlockTmp();
        for (int i = 0; i < AGameManager.Row; i++)
        {
            for (int j = 0; j < AGameManager.Col; j++)
            {
                if (blockTmp[i, j] != 0)
                {
                    CreateBlock(AGameManager.GetBlockIndex(i, j), blockTmp[i, j]);
                }
            }
        }
    }
    
    private int GetDropInCol()
    {
        if (dragBlockItem == null)
        {
            return -1;
        }
        for (int i = 0; i < AGameManager.Col; i++)
        {
            var x = Mathf.Abs(dragBlockItem.transform.localPosition.x - BlockColIndex[i].transform.localPosition.x);
            if (x < 100)
            {
                return i;
            }
        }

        // if (dragBlockItem.transform.localPosition.x <= BlockColIndex[0].transform.localPosition.x)
        // {
        //     return 0;
        // }
        // if (dragBlockItem.transform.localPosition.x >= BlockColIndex[AGameManager.Col - 1].transform.localPosition.x)
        // {
        //     return AGameManager.Col - 1;
        // }
        return -1;
    }
    
    private int GetLastColNullBlock(int col)
    {
        for (int i = 0; i < AGameManager.Row; i++)
        {
            if (blockItemMatrix[i, col] == null || blockItemMatrix[i, col].Num == 0)
            {
                return i;
            }
        }
        return -1;
    }

    /// <summary>
    /// 整理方块
    /// </summary>
    private async UniTask SortBlocks(bool isMoveDown = false)
    {
        var moveTime = 0.2f;
        var sort = false;
        for (int j = 0; j < AGameManager.Col; j++)
        {
            var null_i = -1;
            for (int i = 0; i < AGameManager.Row - 1; i++)
            {
                if (blockItemMatrix[i, j] == null)
                {
                    null_i = i;
                    break;
                }
            }
            if (null_i == -1)
            {
                continue;
            }
            for (int i = null_i + 1; i < AGameManager.Row; i++)
            {
                if (blockItemMatrix[i, j] != null)
                {
                    sort = true;
                    var nullTmp = null_i++;
                    ADebug.Log($"排序 {blockItemMatrix[i, j].GetInfo()} ({i},{j}) to ({nullTmp},{j})");
                    blockItemMatrix[nullTmp, j] = blockItemMatrix[i, j];
                    blockItemMatrix[nullTmp, j].Pos = new Vector2Int(nullTmp, j);
                    blockItemMatrix[i, j] = null;
                    var pos = BlockColIndex[AGameManager.GetBlockIndex(nullTmp, j)].localPosition;
                    var tmpBlock = blockItemMatrix[nullTmp, j];
                    tmpBlock.transform.DOLocalMove(pos, moveTime).OnComplete(() =>
                    {
                        tmpBlock.transform.localPosition = pos;
                    });
                }
            }
        }

        if (sort)
        {
            isMoveDown = false;
            await UniTask.Delay(TimeSpan.FromSeconds(moveTime + 0.1f));
        }
        if (CheckMergeBlock())
        {
            await MergeBlocks();
        }

        if (isMoveDown && !mergeBlock)
        {
            
            //如果最后一行有方块则游戏失败
            for (int j = 0; j < AGameManager.Col; j++)
            {
                if (blockItemMatrix[AGameManager.Row - 1, j] != null)
                {
                    AGameManager.Instance.GameState = AGameState.Lose;
                    ShowUI<ASettlementPanel>(50, score, new Action(Init));
                    return;
                }
            }
            await MoveDownLine();
        }
    }

    private async UniTask MoveDownLine()
    {
        // mergeBlock = false;
        //todo 在顶部生成一行并整体下移
        ADebug.Log("在顶部生成一行并整体下移");
        var moveTime = 0.2f;
        for (int j = 0; j < AGameManager.Col; j++)
        {
            //todo 整体下移
            for (int i = AGameManager.Row - 1; i > 0; i--)
            {
                if (blockItemMatrix[i-1, j] != null)
                {
                    blockItemMatrix[i, j] = blockItemMatrix[i-1, j];
                    blockItemMatrix[i, j].Pos = new Vector2Int(i, j);
                    blockItemMatrix[i-1, j] = null;
                    var tmpBlock = blockItemMatrix[i, j];
                    var tmpPos = BlockColIndex[tmpBlock.Index].localPosition;
                    tmpBlock.transform.DOLocalMove(tmpPos, moveTime).OnComplete(() =>
                    {
                        tmpBlock.transform.localPosition = tmpPos;
                    });
                }
            }

            var excludes = new List<int>();
            if (blockItemMatrix[1, j] != null)
            {
                excludes.Add(blockItemMatrix[1, j].Num);
            }

            if (j > 0)
            {
                excludes.Add(blockItemMatrix[0, j-1].Num);
            }
            var num = RandomNext(excludes);
            var block = CreateBlock(AGameManager.GetBlockIndex(0, j), num);
            var pos = block.transform.localPosition;
            block.transform.localPosition = pos + new Vector3(0, 150, 0);
            var destPos = BlockColIndex[block.Index].localPosition;
            block.transform.DOLocalMove(destPos, moveTime).OnComplete(() =>
            {
                block.transform.localPosition = destPos;
            });
            
        }
        
        await UniTask.Delay(TimeSpan.FromSeconds(moveTime + 0.1f));
    }

    private int RandomNext(List<int> excludes)
    {
        var max = 0;
        var min = 20;
        for (int i = 0; i < AGameManager.Row; i++)
        {
            for (int j = 0; j < AGameManager.Col; j++)
            {
                if (blockItemMatrix[i, j] != null)
                {
                    max = Mathf.Max(max, blockItemMatrix[i, j].Num);
                    min = Mathf.Min(min, blockItemMatrix[i, j].Num);
                }
            }
        }
        max = Mathf.Clamp(max, 1, 20);
        min = Mathf.Clamp(min - 5, 1, 20);
        var index = Random.Range(min, max);
        while (excludes.Contains(index))
        {
            index = Random.Range(1, max);
        }
        return index;
    }

    private bool CheckSortBlock()
    {
        for (int j = 0; j < AGameManager.Col; j++)
        {
            var null_i = -1;
            for (int i = 0; i < AGameManager.Row - 1; i++)
            {
                if (blockItemMatrix[i, j] == null)
                {
                    null_i = i;
                    break;
                }
            }

            if (null_i == -1)
            {
                return false;
            }
            
            for (int i = null_i + 1; i < AGameManager.Row - 1; i++)
            {
                if (blockItemMatrix[i, j] != null)
                {
                    return true;
                }
            }
        }
        return false;
    }
    
    private bool CheckMergeBlock()
    {
        for (int i = 0; i < AGameManager.Row; i++)
        {
            for (int j = 0; j < AGameManager.Col; j++)
            {
                var block = blockItemMatrix[i, j];
                if (block == null)
                {
                    continue;
                }

                if (i - 1 >= 0 && blockItemMatrix[i-1, j] != null && blockItemMatrix[i-1, j].Num == block.Num)
                {
                    return true;
                }
                if (i + 1 < AGameManager.Row && blockItemMatrix[i+1, j] != null && blockItemMatrix[i+1, j].Num == block.Num)
                {
                    return true;
                }
                if (j - 1 >= 0 && blockItemMatrix[i, j-1] != null && blockItemMatrix[i, j-1].Num == block.Num)
                {
                    return true;
                }
                if (j + 1 < AGameManager.Col && blockItemMatrix[i, j+1] != null && blockItemMatrix[i, j+1].Num == block.Num)
                {
                    return true;
                }
            }
        }
        return false;
    }
    
    /// <summary>
    /// 合并方块 检查上下左右是否相同，相同的合并
    /// </summary>
    private async UniTask MergeBlocks()
    {
        var mergeTime = 0.2f;
        var merge = false;
        for (int i = 0; i < AGameManager.Row; i++)
        {
            for (int j = 0; j < AGameManager.Col; j++)
            {
                var targetBlock = blockItemMatrix[i, j];
                if (targetBlock == null)
                {
                    continue;
                }
                var targetNum = targetBlock.Num + 1;
                var destPos = BlockColIndex[AGameManager.GetBlockIndex(i, j)].localPosition;
                if (i - 1 >= 0 && blockItemMatrix[i-1, j] != null && blockItemMatrix[i-1, j].Num == targetBlock.Num)
                {
                    //todo 合并 
                    merge = true;
                    MergeBlockMove(blockItemMatrix[i - 1, j], targetBlock, destPos, mergeTime, targetNum);
                    blockItemMatrix[i - 1, j] = null;
                }
                if (i + 1 < AGameManager.Row && blockItemMatrix[i+1, j] != null && blockItemMatrix[i+1, j].Num == targetBlock.Num)
                {
                    merge = true;
                    MergeBlockMove(blockItemMatrix[i + 1, j], targetBlock, destPos, mergeTime, targetNum);
                    blockItemMatrix[i + 1, j] = null;
                }
                if (j - 1 >= 0 && blockItemMatrix[i, j-1] != null && blockItemMatrix[i, j-1].Num == targetBlock.Num)
                {
                    merge = true;
                    MergeBlockMove(blockItemMatrix[i, j-1], targetBlock, destPos, mergeTime, targetNum);
                    blockItemMatrix[i, j-1] = null;
                }
                if (j + 1 < AGameManager.Col && blockItemMatrix[i, j+1] != null && blockItemMatrix[i, j+1].Num == targetBlock.Num)
                {
                    merge = true;
                    MergeBlockMove(blockItemMatrix[i, j+1], targetBlock, destPos, mergeTime, targetNum);
                    blockItemMatrix[i, j+1] = null;
                }

                // if (merge)
                // {
                //     ChangeScore(targetBlock.Num);
                // }
            }
        }
        if (merge)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(mergeTime + 0.1f));
        }
        
        // if (CheckSortBlock())
        {
            await SortBlocks();
        }
    }

    
    private void MergeBlockMove(BlockItem source, BlockItem target, Vector3 destPos, float duration, int targetNum)
    {
        mergeBlock = true;
        A_AudioManager.Instance.PlaySound("Clear");
        source.transform.DOLocalMove(destPos, duration).OnComplete(() =>
        {
            ADebug.Log($"合并 {source.GetInfo()} 到 {target.GetInfo()}");
            ChangeScore(source.Num);
            target.Num = targetNum;
            Destroy(source.gameObject);
        });
    }

    private bool CheckCanDrag(BlockItem block)
    {
        if (block == null)
        {
            return false;
        }
        var i = block.Pos.x;
        var j = block.Pos.y;
        if (i - 1 >= 0 && blockItemMatrix[i-1, j] == null)
        {
            return true;
        }
        if (i + 1 < AGameManager.Row && blockItemMatrix[i+1, j] == null)
        {
            return true;
        }
        if (j - 1 >= 0 && blockItemMatrix[i, j-1] == null)
        {
            return true;
        }
        if (j + 1 < AGameManager.Col && blockItemMatrix[i, j+1] == null)
        {
            return true;
        }
        return false;
    }

    private void ChangeScore(int score)
    {
        ADebug.Log($"改变分数 {score}");
        this.score += score;
        ScoreText.text = this.score.ToString();
        if (this.score > AGameManager.Instance.HighScore)
        {
            AGameManager.Instance.HighScore = this.score;
            HighScoreText.text = this.score.ToString();
        }
    }

    private void OnBlockDrag(BlockItem blockItem, PointerEventData eventData)
    {
        if (dragBlockItem == null)
        {
            return;
        }
        // ADebug.Log($"拖拽中 {blockItem.gameObject.name}");
        //todo 将屏幕坐标转为本地坐标
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(BlockParent.GetComponent<RectTransform>(), eventData.position,
                AGameModule.UI.UICamera, out Vector2 point))
        {
            dragBlockItem.transform.localPosition = point;
        }
        
    }

    private void OnBlockEndDrag(BlockItem blockItem, PointerEventData eventData)
    {
        if (dragBlockItem == null)
        {
            return;
        }
        ADebug.Log($"结束拖拽 {blockItem.GetInfo()}");
        dragBlockItem.IsDragging = false;
        var dropInCol = GetDropInCol();
        if (dropInCol == -1)
        {
            ADebug.Log($"未找到目标列");
            var x = GetLastColNullBlock(dragBlockItem.Pos.y);
            dragBlockItem.Pos = new Vector2Int(x, dragBlockItem.Pos.y);
            blockItemMatrix[dragBlockItem.Pos.x, dragBlockItem.Pos.y] = dragBlockItem;
            dragBlockItem.transform.localPosition = BlockColIndex[dragBlockItem.Index].localPosition;
            dragBlockItem = null;
            SortBlocks().Forget();
            return;
        }
        //todo 放到该列最后一个
        var lastNullBlock = GetLastColNullBlock(dropInCol);
        if (lastNullBlock == -1)
        {
            //todo 满了
            ADebug.Log($"列{dropInCol}满了");
            var x = GetLastColNullBlock(dragBlockItem.Pos.y);
            dragBlockItem.Pos = new Vector2Int(x, dragBlockItem.Pos.y);
            blockItemMatrix[dragBlockItem.Pos.x, dragBlockItem.Pos.y] = dragBlockItem;
            dragBlockItem.transform.localPosition = BlockColIndex[dragBlockItem.Index].localPosition;
            dragBlockItem = null;
            SortBlocks().Forget();
            return;
        }
        
        var index = AGameManager.GetBlockIndex(lastNullBlock, dropInCol);
        if (dragBlockItem.Index == index)
        {
            ADebug.Log("放回原位");
            var x = GetLastColNullBlock(dragBlockItem.Pos.y);
            dragBlockItem.Pos = new Vector2Int(x, dragBlockItem.Pos.y);
            blockItemMatrix[dragBlockItem.Pos.x, dragBlockItem.Pos.y] = dragBlockItem;
            dragBlockItem.transform.localPosition = BlockColIndex[dragBlockItem.Index].localPosition;
            dragBlockItem = null;
            SortBlocks().Forget();
            return;
        }
        
        var tmp = dragBlockItem;
        dragBlockItem = null;
        tmp.transform.DOLocalMove(BlockColIndex[index].localPosition, 0.2f).OnComplete(() =>
        {
            tmp.Pos = new Vector2Int(lastNullBlock, dropInCol);
            blockItemMatrix[lastNullBlock, dropInCol] = tmp;
            ADebug.Log($"放置位置 {tmp.GetInfo()}");
            tmp.transform.localPosition = BlockColIndex[index].localPosition;
            SortBlocks(true).Forget();
        });
    }

    private void OnBlockBeginDrag(BlockItem blockItem, PointerEventData eventData)
    {
        //todo 判定能否拖拽
        if (!CheckCanDrag(blockItem))
        {
            ADebug.Log($"不能拖拽 {blockItem.GetInfo()}");
            return;
        }
        ADebug.Log($"开始拖拽 {blockItem.GetInfo()}");
        dragBlockItem = blockItem;
        blockItem.IsDragging = true;
        blockItemMatrix[blockItem.Pos.x, blockItem.Pos.y] = null;
        mergeBlock = false;
        //todo 整理方块
        SortBlocks().Forget();
    }
}