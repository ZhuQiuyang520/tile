using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AGameManager : ASingletonBehaviour<AGameManager>
{

    #region 资源配置
    public GameObject GameRoot;
    public Sprite[] AircraftSprites;
    public Sprite[] BlockSprites;
    #endregion
    
    #region 游戏
    private int CurrGold;
    public int HighScore;
    public const int Row = 7;
    public const int Col = 5;
    
    public static int[,] InitBlockTmp1 =
    {
        {6, 7, 5, 6, 7},
        {5, 4, 1, 3, 6},
        {3, 0, 2, 1, 3},
        {1, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
    };
    public static int[,] InitBlockTmp2 =
    {
        {7, 5, 3, 6, 7},
        {4, 2, 1, 3, 4},
        {3, 5, 2, 1, 0},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
    };
    
    public static int[,] InitBlockTmp3 =
    {
        {6, 7, 2, 6, 5},
        {2, 5, 1, 3, 4},
        {3, 4, 2, 0, 3},
        {2, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
    };
    public static int[,] InitBlockTmp4 =
    {
        {5, 3, 5, 6, 3},
        {4, 2, 1, 3, 6},
        {2, 1, 4, 1, 3},
        {1, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
    };
    
    public List<int[,]> InitBlockTmps = new List<int[,]>()
    {
        InitBlockTmp1,
        InitBlockTmp2,
        InitBlockTmp3,
        InitBlockTmp4,
    };
    
    public int[,] GetRandomBlockTmp()
    {
        int index = Random.Range(0, InitBlockTmps.Count);
        return InitBlockTmps[index];
    }
    
    public AGameState GameState;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        ADebug.Log("游戏初始化");
        A_AudioManager.Instance.PlayMusic("BGM");
        GameRoot.SetActive(true);
        ReadArchive();

        if (AGameModule.Base.IsDebugMode && Application.platform == RuntimePlatform.WindowsEditor)
        {
            AUIModule.Instance.ShowUI<ADebuggerPanel>();
        }
        
        GameState = AGameState.None;
        //打开主界面
        AUIModule.Instance.ShowUI<AGamePanel>();
        A_AudioManager.Instance.PlayMusic("BGM");
    }

    public void ChangeGold(int gold)
    {
        CurrGold += gold;
        ADebug.Log($"ChangeGold: CurrGold:{CurrGold} {gold}");
        AEventModule.Send<int>(AEventType.ChangeGold, gold);
    }

    public int GetCurrGold()
    {
        return CurrGold;
    }
    
    void OnApplicationQuit()
    {
        SaveArchive();
    }
    
    public static Vector2Int GetBlockPos(int index)
    {
        return new Vector2Int(index / Col, index % Col);
    }
    
    public static int GetBlockIndex(int x, int y)
    {
        return x * Col + y;
    }
    
    #endregion


    #region 存档
    public void ReadArchive()
    {
        
        CurrGold = PlayerPrefs.GetInt(AConstant.ArchiveKey.CurrGold, 0);
        CurrGold = CurrGold < 0 ? 0 : CurrGold;
        HighScore = PlayerPrefs.GetInt(AConstant.ArchiveKey.HighScore, 0);
        HighScore = HighScore < 0 ? 0 : HighScore;
        
        ADebug.Log($"读存档: CurrGold:{CurrGold}，HighScore:{HighScore}，lastOutLineTime:，AS_Level:，Attack_Level:，" +
                   $"Magazine_Level:，Reloading_Level:，BestScore:，RankList");
    }
    
    public void SaveArchive()
    {
        PlayerPrefs.SetInt(AConstant.ArchiveKey.CurrGold, CurrGold);
        PlayerPrefs.SetInt(AConstant.ArchiveKey.HighScore, HighScore);

        ADebug.Log($"自动存档: CurrGold:{CurrGold}，HighScore:{HighScore}，AS_Level:，Attack_Level:，" +
                   $"Magazine_Level:，Reloading_Level:，BestScore:，RankList");
    }
    #endregion
    
}