using DG.Tweening;
using LitJson;
using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using Watermelon;

public class OilyVillage : MonoBehaviour
{
    public static OilyVillage instance;

    [SerializeField] LevelDatabase PianoNarrowly;
    public static LevelDatabase Narrowly=> instance.PianoNarrowly;
    private LevelData1 PenalClumpHave;
    [SerializeField] PreloadedLevelData PenalAfloatClumpHave;
    [SerializeField] LevelScaler PianoRejoin;
    [SerializeField] GameData Hike;
    public static GameData Have=> instance.Hike;
    [SerializeField] Color TextMustardTread;
[UnityEngine.Serialization.FormerlySerializedAs("RemindEffect")]
    public GameObject FamilyOxygen;
[UnityEngine.Serialization.FormerlySerializedAs("VolunEffect")]    public GameObject FancyOxygen;
[UnityEngine.Serialization.FormerlySerializedAs("SlotAni")]
    public Animator LowaZoo;
[UnityEngine.Serialization.FormerlySerializedAs("mb")]    public GameObject Dy;
    private bool CrampLowaZoo;
    private bool RibLowaZoo;
    private float LowaZooQuit;
[UnityEngine.Serialization.FormerlySerializedAs("LevelObj")]
    public GameObject ClumpIce;
[UnityEngine.Serialization.FormerlySerializedAs("LevelParentObj")]    public GameObject ClumpGlassyIce;
[UnityEngine.Serialization.FormerlySerializedAs("AddSlotObj")]
    public GameObject BurLowaIce;
[UnityEngine.Serialization.FormerlySerializedAs("SlotPrefab")]    public SlotBehavior LowaLocale;
[UnityEngine.Serialization.FormerlySerializedAs("SlotList")]
    public List<SlotBehavior> LowaPlug;
[UnityEngine.Serialization.FormerlySerializedAs("ReviveSlotList")]    public List<GameObject> ClotheLowaPlug;

    private List<SlotBehavior> OurLowaPlug= new List<SlotBehavior>();
[UnityEngine.Serialization.FormerlySerializedAs("CurLevel")]
    public static LevelData1 RyeClump;

    private Vector2Int Yean;
    public static Vector2Int HourThankTray=> new Vector2Int(RyeClump.PenThank(RyeClump.layers.Count - 1).PenOwn(0).cells.Count, RyeClump.PenThank(RyeClump.layers.Count - 1).rows.Count);
    public static Vector2Int BudThankTray=> new Vector2Int(RyeClump.PenThank(RyeClump.layers.Count - 2).PenOwn(0).cells.Count, RyeClump.PenThank(RyeClump.layers.Count - 2).rows.Count);

    public static bool WeNeverThankRecede=> HourThankTray.x > BudThankTray.x;
    private List<TileBehavior> CanyPlug;
    private LayersMatrix Impact;
    private List<TileSpawnData> ToothShare;

    private float FamilyQuit;
[UnityEngine.Serialization.FormerlySerializedAs("IsRemind")]    public bool WeFamily;
    private List<TileBehavior> FamilyShare= new List<TileBehavior>();

    private int SoftnessFloral;
    private int ElusiveClue;

    private bool WeRyeClumpAdmission;

    private int ClotheGnaw= 0;
    private float ClotheLagoon= 0;

    private Vector3 HyksosFrost;
[UnityEngine.Serialization.FormerlySerializedAs("IsFail")]    public bool WeHone;

    private string EvokeSweet;
    private string[] EvokeSweetHave;

    private int AdmissionWeary= 0;
    private int ThankNaive;
    private List<TileSpawnData> AdmissionCanyPlug;

    private string SneezeWhim;
    private List<LevelData1> FluffyConcur= new List<LevelData1>();
    //private List<string> ReviveList1 = new List<string>();
    //private List<string> ReviveList2 = new List<string>();
    //private List<string> ReviveList3 = new List<string>();

    private void Awake()
    {
        instance = this;
        //初始化level基础数据
        PianoNarrowly.Initialise();
    }

    private void Start()
    {
        FamilyQuit = 0;
        WeFamily = false;
        for (int i = 0; i < LowaPlug.Count; i++)
        {
            LowaPlug[i].SettingOrder(i);
        }

        //if (levelDatabase != null)
        //{
        //    for (int i = 0; i < levelDatabase.Levels.Length; i++)
        //    {
        //        SaveToFolder((Application.dataPath + "/Project Data/Content/LevelSystem/LevelJson"), levelDatabase.Levels[i].name, JsonUtility.ToJson(levelDatabase.Levels[i]));
        //    }
            
        //}
        SneezeWhim = "LevelJson/";
        ThenShiftDySneeze();
    }

    // 批量加载文件夹中的所有文件
    public void ThenShiftDySneeze()
    {

        // 获取文件夹中所有文件的路径
        TextAsset[] filePaths = Resources.LoadAll<TextAsset>(SneezeWhim); /*Directory.GetFiles(FolderPath);*/


        // 清空之前加载的资源
        FluffyConcur.Clear();

        // 遍历所有文件并加载
        foreach (TextAsset filePath in filePaths)
        {
            ThenEditKnap(filePath.name, filePath);
        }

        Debug.Log($"成功加载 {FluffyConcur.Count} 个文件");
    }

    // 加载文本文件
    private void ThenEditKnap(string fileName, TextAsset filePath)
    {
        // 这里简单存储文本内容，实际项目中可以根据需要解析
        
        if (fileName == "1")
        {
            PenalClumpHave = JsonMapper.ToObject<LevelData1>(filePath.text);
        }
        else
        {
            FluffyConcur.Add(JsonMapper.ToObject<LevelData1>(filePath.text));
        }
    }

    /// <summary>
    /// 保存文本文件到指定文件夹
    /// </summary>
    /// <param name="folderPath">文件夹路径（相对于基础路径）</param>
    /// <param name="fileName">文件名（包含扩展名，如"save.txt"）</param>
    /// <param name="content">要保存的文本内容</param>
    /// <param name="basePathType">基础路径类型</param>
    /// <returns>是否保存成功</returns>
    private bool LuckMySneeze(string folderPath, string fileName, string content)
    {
        try
        {
            // 获取基础路径
            string basePath = Application.streamingAssetsPath;

            // 组合完整文件夹路径
            string fullFolderPath = Path.Combine(basePath, folderPath);

            // 确保文件夹存在
            if (!Directory.Exists(fullFolderPath))
            {
                Directory.CreateDirectory(fullFolderPath);
                Debug.Log($"已创建文件夹: {fullFolderPath}");
            }

            // 组合完整文件路径
            string fullFilePath = Path.Combine(fullFolderPath, fileName + ".json");

            // 写入文件内容
            File.WriteAllText(fullFilePath, content);
            Debug.Log($"文本文件已保存: {fullFilePath}");
            return true;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"保存文件失败: {ex.Message}");
            return false;
        }
    }

    //游戏退出时记录登出时间
    public void OnApplicationQuit()
    {
        // 将DateTime转换为长整型（Ticks）存储
        PlayerPrefs.SetString(CLagoon.Seem_Evolve_Quit_Wok, System.DateTime.Now.Ticks.ToString());
        PlayerPrefs.Save();
    }

    //加载关卡
    public void ThenClump(int index)
    {
        LowaZoo.enabled = false;
        Dy.SetActive(false);
        for (int i = 0; i < LowaPlug.Count; i++)
        {
            if (LowaPlug[i].ActionValue())
            {
                LowaPlug[i].InitData();
            }
        }

        EvokeSweet = SawSelfEke.instance.OilyHave.Combo_Cash;
        EvokeSweetHave = EvokeSweet.Split(';');
        WeHone = true;
        ClotheGnaw = 0;
        ClotheLagoon = 0;
        WeRyeClumpAdmission = OilyMimetic.PenMonopoly().WeAdmission;
        if (!WeRyeClumpAdmission)
        {
            if (index >= SawSelfEke.instance.ClumpPlug.level.Count)
            {
                index = index % SawSelfEke.instance.ClumpPlug.level.Count + 29;
            }
            foreach (var item in SawSelfEke.instance.ClumpPlug.level)
            {
                if (item.LevelID == index)
                {
                    index = item.LevelData;
                    break;
                }
            }
        }
        else
        {
            ThankNaive = 0;
            AdmissionWeary = SawSelfEke.instance.OilyHave.challenge_group;
        }
        if (PlayerPrefs.GetInt(CLagoon.PumpIglooAdmission) == 1 && WeRyeClumpAdmission)
        {
            PlayerPrefs.SetInt(CLagoon.PumpIglooAdmission, 0);
            OilyMimetic.PenMonopoly().EngineGuess = false;
            UIMimetic.PenMonopoly().BlueUIBasin(nameof(ZebraJuneToxic));
        }
        WeFamily = false;
        SoftnessFloral = -1;
        ElusiveClue = 0;
        CrampLowaZoo = false;
        RibLowaZoo = false;
        LowaZooQuit = 0;
        if (LowaLocale.gameObject.activeSelf)
        {
            BurLowaIce.SetActive(true);
            LowaLocale.gameObject.SetActive(false);
            OurLowaPlug.Remove(LowaLocale);
        }
        OurLowaPlug = LowaPlug;
        UnThenClump();

        CanyPlug = new List<TileBehavior>();

        //加载level
        if (TemperFile.WeSound())
        {
            index += SawSelfEke.instance.ClumpPlug.level.Count;
        }
        if (OilyMimetic.PenMonopoly().WePenal)
        {
            RyeClump = PenalClumpHave;
        }
        else
        {
            RyeClump = FluffyConcur[index];
        }
       
        ToothShare = new List<TileSpawnData>();
        AdmissionCanyPlug = new List<TileSpawnData>();
        PianoRejoin.Recalculate();
        ClumpGlassyIce.transform.position = PianoRejoin.LevelFieldCenter;
        //选出符合关卡
        TileData[] availableObjects = OilyMimetic.PenMonopoly().ChildhoodVieClump(FluffyConcur,PianoNarrowly.Tiles, RyeClump);
        TileData[] initialTilesData = UtterlyEnforceShare(availableObjects);
        
        Impact = new LayersMatrix(RyeClump, ClumpGlassyIce);
        
        for (int i = 0; i < RyeClump.layers.Count; i++)
        {
            Impact.Layers[i].LayerObject.transform.position -= new Vector3(0, 0.06f * (LevelScaler.TileSize.y / Hike.TileSize.y), 0) * i;
            LayersData layer = RyeClump.PenThank(i);
            Yean = (RyeClump.layers.Count - i - 1) % 2 == 0 ? HourThankTray : BudThankTray;
            for (int y = Yean.y - 1; y >= 0; y--)
            {
                for (int x = 0; x < Yean.x; x++)
                {
                    CellData cellData = layer.rows[y].cells[x];
                    if (cellData.IsFilled)
                    {
                        TileSpawnData tileSpawnData = new TileSpawnData();
                        
                        tileSpawnData.ExamineDatebase = new ElementPosition(x, y, i);
                        tileSpawnData.HereHave = cellData;
                        tileSpawnData.ThankNaive = i;
                        tileSpawnData.Thank = layer;
                        tileSpawnData.ThankTray = Yean;
                        ToothShare.Add(tileSpawnData);
                        AdmissionCanyPlug.Add(tileSpawnData);
                    }
                }
            }
        }

        if (OilyMimetic.PenMonopoly().WeAdmission && PlayerPrefs.GetInt(CLagoon.PerHimSeveralSweet) != 0)
        {
            for (int i = 0; i < initialTilesData.Length; i++)
            {
                //随机选择一个预制体样式
                TileSpawnData firstTileSpawnData = AdmissionCanyPlug.OrderBy(x => Random.value).OrderBy(x => x.ThankNaive).FirstOrDefault();
                AdmissionCanyPlug.Remove(firstTileSpawnData);

                if (ThankNaive != firstTileSpawnData.ThankNaive)
                {
                    ThankNaive = firstTileSpawnData.ThankNaive;
                    AdmissionWeary = SawSelfEke.instance.OilyHave.challenge_group;
                }
                else
                {
                    if (AdmissionWeary == 0)
                    {
                        continue;
                    }
                }
                if (AdmissionCanyPlug.FindAll(s => s.ThankNaive == ThankNaive).Count < SawSelfEke.instance.OilyHave.challenge_amount || ThankNaive >= SawSelfEke.instance.OilyHave.challenge_limit)
                {
                    continue;
                }
                ToothShare.Remove(firstTileSpawnData);

                TileBehavior firstElementBehavior = StoneCany(initialTilesData[i], firstTileSpawnData.ExamineDatebase);
                float totalWeight = 0;
                foreach (TileSpawnData emptyTile in AdmissionCanyPlug)
                {
                    emptyTile.InformativeBluish(firstTileSpawnData.ThankNaive);
                    totalWeight += emptyTile.AtomicBluish;
                }
                for (int a = 0; a < 2; a++)
                {
                    TileSpawnData selectedTileData = null;
                    selectedTileData = AdmissionCanyPlug.FindAll(s => s.ThankNaive == ThankNaive)[Random.Range(0, AdmissionCanyPlug.FindAll(s => s.ThankNaive == ThankNaive).Count)];
                    if (selectedTileData != null)
                    {
                        AdmissionCanyPlug.Remove(selectedTileData);
                        ToothShare.Remove(selectedTileData);
                        totalWeight -= selectedTileData.AtomicBluish;
                        TileBehavior additionalElementBehavior = StoneCany(initialTilesData[i], selectedTileData.ExamineDatebase);
                    }
                }
                initialTilesData[i] = null;
                if (AdmissionWeary > 0)
                {
                    AdmissionWeary--;
                }
            }
        }
        for (int i = 0; i < initialTilesData.Length; i++)
        {
            if (initialTilesData[i] == null)
            {
                continue;
            }
            //随机选择一个预制体样式
            TileSpawnData firstTileSpawnData = ToothShare.OrderBy(x => Random.value).OrderBy(x => x.ExamineDatebase.Y).FirstOrDefault();
            ToothShare.Remove(firstTileSpawnData);
            TileBehavior firstElementBehavior = StoneCany(initialTilesData[i], firstTileSpawnData.ExamineDatebase);

            float totalWeight = 0;
            foreach (TileSpawnData emptyTile in ToothShare)
            {
                emptyTile.InformativeBluish(firstTileSpawnData.ThankNaive);
                totalWeight += emptyTile.AtomicBluish;
            }

            for (int a = 0; a < 2; a++)
            {
                float randomValue = Random.Range(0, totalWeight);
                float currentWeight = 0;
                TileSpawnData selectedTileData = null;
                foreach (TileSpawnData emptyTile in ToothShare)
                {
                    currentWeight += emptyTile.AtomicBluish;
                    if (currentWeight >= randomValue)
                    {
                        selectedTileData = emptyTile;
                        break;
                    }
                }
                if (selectedTileData != null)
                {
                    ToothShare.Remove(selectedTileData);
                    totalWeight -= selectedTileData.AtomicBluish;

                    TileBehavior additionalElementBehavior = StoneCany(initialTilesData[i], selectedTileData.ExamineDatebase);
                }
            }
        }


        if (!WeRyeClumpAdmission)
        {
            OilyMimetic.PenMonopoly().EngineGuess = false;
            if (!TemperFile.WeSound())
            {
                OilyToxic.instance.WeSpeedyLime(true);
            }
            //执行动画 挑战关卡不执行加载动画
            StartCoroutine(PenSeldomShare());
        }
        else
        {
            foreach (var item in CanyPlug)
            {
                item.SetState(false, false);
            }
            for (int i = 0; i < CanyPlug.Count; i++)
            {
                CanyPlug[i].SetState(WeCanyNonetheless(CanyPlug[i]));
            }
        }
    }

    private List<TileBehavior> CactusShare;
    private List<TileBehavior> FlockShare;
    public void CopPenal()
    {
        OurLowaPlug = LowaPlug;
        CanyPlug = new List<TileBehavior>();
        ThenPenalClump(PenalClumpHave, PenalAfloatClumpHave, () => {
            CactusShare = new List<TileBehavior>();
            CactusShare.Add(PenCany(new ElementPosition(0, 0, 1)));
            CactusShare.Add(PenCany(new ElementPosition(1, 0, 1)));
            CactusShare.Add(PenCany(new ElementPosition(2, 0, 1)));

            foreach (var cheese in CactusShare)
            {
                cheese.SetBlockState(true);
                cheese.SetColor(TextMustardTread, true);
            }

            // Get apple tiles
            FlockShare = new List<TileBehavior>();
            FlockShare.Add(PenCany(new ElementPosition(0, 1, 1)));
            FlockShare.Add(PenCany(new ElementPosition(1, 1, 1)));
            FlockShare.Add(PenCany(new ElementPosition(2, 1, 1)));

            foreach (var apple in FlockShare)
            {
                apple.SetBlockState(false);
                apple.SetAnimation("Tile_idle");
            }
        });
    }

    private void ThenPenalClump(LevelData1 levelData, PreloadedLevelData preloadedLevelData, SimpleCallback onLevelLoaded = null)
    {
        RyeClump = levelData;
        ClumpIce.SetActive(true);
        PianoRejoin.Recalculate();
        ClumpGlassyIce.transform.position = PianoRejoin.LevelFieldCenter;

        Impact = new LayersMatrix(RyeClump, ClumpGlassyIce);

        StoneGrandma(preloadedLevelData);

        onLevelLoaded();
    }

    public void StoneGrandma(PreloadedLevelData preloadedLevelData)
    {
        preloadedLevelData.Initialise();
        PreloadedLevelData.Tile[] preloadTiles = preloadedLevelData.Tiles;
        foreach (PreloadedLevelData.Tile tile in preloadTiles)
        {
            TileData tileData = tile.TileData;
            ElementPosition elementPosition = tile.ElementPosition;
            TileBehavior tileBehavior = tileData.Pool.GetPooledObject().GetComponent<TileBehavior>();
            tileBehavior.Initialise(tileData, elementPosition);
            tileBehavior.transform.SetParent(Impact[elementPosition.LayerId].LayerObject.transform);
            tileBehavior.transform.localPosition = LevelScaler.GetPosition(tile.ElementPosition);
            tileBehavior.transform.localScale = Vector3.one;
            tileBehavior.SetScale(LevelScaler.TileSize);

            Impact[tile.ElementPosition] = tileBehavior;

            // Figuring out is object is Active
            tileBehavior.SetState(WeCanyNonetheless(tileBehavior), false);


            CanyPlug.Add(tileBehavior);
        }
    }
    public TileBehavior PenCany(ElementPosition elementPosition)
    {
        if (WeCanyCourse(elementPosition))
        {
            return Impact[elementPosition].Tile;
        }

        return null;
    }
    public bool WeCanyCourse(ElementPosition elementPosition)
    {
        int layerId = elementPosition.LayerId;
        int width = Impact[layerId].Width;
        int height = Impact[layerId].Height;

        if (elementPosition.X >= 0 && elementPosition.X < width && elementPosition.Y >= 0 && elementPosition.Y < height)
        {
            return Impact[elementPosition].State;
        }

        return false;
    }

    //给除了第一层的其他层级赋值
    private TileData[] UtterlyEnforceShare(TileData[] availableTilesData)
    {
        // Helps keep track of the amount of already included tiles
        Dictionary<TileData, int> objectsInLevelAmount = new Dictionary<TileData, int>();

        var initialTilesData = new List<TileData>();

        int tilesDataLeft = RyeClump.PenPierceOfPollenGreat();

        // The current maximum amount of any specific tile inside initialTilesData
        int maxAmount = 1;

        while (tilesDataLeft > 0)
        {
            TileData tileData = availableTilesData.GetRandomItem();

            // Sellecting the most appropriate tile data
            if (objectsInLevelAmount.ContainsKey(tileData))
            {
                // This tile data have already been added to the list. Trying to add data that isn't the one with max amount of already added
                for (int i = 0; i < availableTilesData.Length; i++)
                {
                    TileData testTileData = availableTilesData[i];
                    if (testTileData != tileData)
                    {
                        if (objectsInLevelAmount.ContainsKey(testTileData))
                        {
                            if (objectsInLevelAmount[testTileData] < maxAmount)
                            {
                                tileData = testTileData;
                            }
                        }
                        else
                        {
                            tileData = testTileData;
                            objectsInLevelAmount.Add(tileData, 1);
                        }

                    }
                }

                int amount = objectsInLevelAmount[tileData];
                amount++;

                if (maxAmount < amount)
                    maxAmount = amount;
                objectsInLevelAmount[tileData] = amount;
            }
            else
            {
                // This is the first time we're adding this tile data to the list
                objectsInLevelAmount.Add(tileData, 1);
                if (maxAmount == 0)
                    maxAmount = 1;
            }

            initialTilesData.Add(tileData);

            tilesDataLeft -= 3;
        }

        return initialTilesData.OrderBy(x => UnityEngine.Random.value).ToArray();
    }

    private class TileSpawnData
    {
        public ElementPosition ExamineDatebase;
        public CellData HereHave;

        public int ThankNaive;
        public LayersData Thank;
        public Vector2Int ThankTray;

        public float AtomicBluish;

        public void InformativeBluish(int baseLayerIndex)
        {
            int layerDiff = ThankNaive - baseLayerIndex;

            AtomicBluish = Mathf.Clamp(3 - layerDiff, 0, int.MaxValue);
        }
    }

    private TileBehavior StoneCany(TileData tileData, ElementPosition elementPosition)
    {
        TileBehavior tile = tileData.Pool.GetPooledObject().GetComponent<TileBehavior>();
        tile.Initialise(tileData, elementPosition);
        tile.transform.SetParent(Impact.Layers[elementPosition.LayerId].LayerObject.transform);
        tile.transform.localPosition = LevelScaler.GetPosition(tile.ElementPosition);
        tile.transform.localScale = Vector3.one;
        tile.SetScale(LevelScaler.TileSize);

        Impact[tile.ElementPosition] = tile;

        // Figuring out is object is Active
        tile.SetState(WeCanyNonetheless(tile), false);

        // Add tile to global tiles list
        CanyPlug.Add(tile);

        return tile;
    }

    //增加槽位
    public void BurLowa()
    {
        SlayNeverSpiral.PenMonopoly().JumpNever("1009", "1");
        OilyMimetic.PenMonopoly().EngineGuess = false;
        ADMimetic.Monopoly.LullGreedyFluid((success) =>
        {
            OilyMimetic.PenMonopoly().EngineGuess = true;
            if (success)
            {
                BurLowaIce.SetActive(false);
                SlayNeverSpiral.PenMonopoly().JumpNever("9007", "7");

                LowaLocale.gameObject.SetActive(true);
                LowaLocale.SettingOrder(7);
                OurLowaPlug.Add(LowaLocale);
                //for (int i = 0; i < UseSlotList.Count; i++)
                //{
                //    if (UseSlotList[i].ActionValue())
                //    {
                //        UseSlotList[i].ActionTileBehavior().transform.position = UseSlotList[i].transform.position;
                //    }
                //}

                LowaZoo.enabled = false;
                Dy.SetActive(false);
                CrampLowaZoo = false;
                RibLowaZoo = false;
                LowaZooQuit = 0;
            }
            
        }, "110");

    }

    //刷新tile
    public void StudentCany()
    {
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_Shuffle);
        //关闭自动提示
        if (FamilyShare.Count > 0)
        {
            for (int i = 0; i < FamilyShare.Count; i++)
            {
                FamilyShare[i].CloseAni();
            }
            FamilyShare.Clear();
            WeFamily = true;
            FamilyQuit = 0;
        }
        List<TileBehavior> ActiveTiles = CanyPlug;
        if (ActiveTiles != null)
        {
            if (ActiveTiles.Count > 1)
            {
                List<TileBehavior> allowedToShuffleTiles = new List<TileBehavior>(ActiveTiles);

                if (allowedToShuffleTiles.Count > 1)
                {
                    ElementPosition[] shuffleElements = new ElementPosition[allowedToShuffleTiles.Count];

                    for (int i = 0; i < shuffleElements.Length; i++)
                    {
                        shuffleElements[i] = allowedToShuffleTiles[i].ElementPosition;
                    }
                    shuffleElements.Shuffle();

                    for (int i = 0; i < ActiveTiles.Count; i++)
                    {
                        ActiveTiles[i].transform.localScale = Vector3.zero;
                    }

                    for (int i = 0; i < shuffleElements.Length; i++)
                    {
                        allowedToShuffleTiles[i].transform.SetParent(Impact.Layers[shuffleElements[i].LayerId].LayerObject.transform);
                        allowedToShuffleTiles[i].transform.localScale = Vector3.zero;
                        allowedToShuffleTiles[i].transform.localPosition = LevelScaler.GetPosition(shuffleElements[i]);
                        allowedToShuffleTiles[i].SetPosition(shuffleElements[i]);
                    }

                    foreach (LayerGrid layer in Impact.Layers)
                    {
                        int width = layer.Width;
                        int height = layer.Height;

                        for (int x = 0; x < width; x++)
                        {
                            for (int y = 0; y < height; y++)
                            {
                                layer[x, y].LinkTile(null);
                            }
                        }
                    }

                    foreach (TileBehavior tile in CanyPlug)
                    {
                        ElementPosition elementPosition = tile.ElementPosition;

                        Impact.Layers[elementPosition.LayerId][elementPosition].LinkTile(tile);
                    }

                    HazardOffend(true);

                    StudentConestoga(ActiveTiles, 0.5f, 0.05f, 0.4f);
                }
            }
        }

    }

    //点击刷新tile
    private void StudentConestoga(List<TileBehavior> tiles, float scaleDuration, float minDelay, float MaxDelay)
    {
        float[] delays = new float[tiles.Count];

        float longestDelay = 0;
        for (int i = 0; i < delays.Length; i++)
        {
            float delay = Random.Range(minDelay, MaxDelay);

            if (delay > longestDelay)
                longestDelay = delay;

            delays[i] = delay;
        }

        float duration = scaleDuration + longestDelay;

        for (int i = 0; i < delays.Length; i++)
        {
            delays[i] = delays[i] / duration;
        }
        CanySpinetConestoga(tiles);
        //StartCoroutine(TileCreateAnimation(tiles));
    }
    //撤回tile
    public void PeltWarmRCany()
    {
        TileBehavior PresetTile = null;
        SlotBehavior PresetLost = null;
        //从后往前撤回
        for (int i = OurLowaPlug.Count - 1; i >= 0; i--)
        {
            if (OurLowaPlug[i].ActionValue())
            {
                PresetTile = OurLowaPlug[i].ActionTileBehavior();
                PresetLost = OurLowaPlug[i];
                break;
            }
        }

        if (PresetTile != null)
        {
            Vector3 returnPosition = LevelScaler.GetPosition(PresetTile.ElementPosition);
            Transform parentTransform = PresetTile.transform.parent;
            if (parentTransform != null)
            {
                returnPosition = parentTransform.TransformPoint(returnPosition);
            }

            PresetTile.SubmitMove(returnPosition, new Vector3(1.1f, 1.1f, 1.1f) * LevelScaler.TileSize, () =>
            {
                PresetTile.SetPosition(PresetTile.ElementPosition);
                PresetTile.ResetSubmitState();
                CanyPlug.Add(PresetTile);
                Impact[PresetTile.ElementPosition] = PresetTile;
                PresetLost.InitData();
                HazardOffend(true);
            });
        }

        //关闭自动提示
        if (FamilyShare.Count > 0)
        {
            for (int i = 0; i < FamilyShare.Count; i++)
            {
                FamilyShare[i].CloseAni();
            }
            FamilyShare.Clear();
            WeFamily = true;
            FamilyQuit = 0;
        }
        LowaZoo.enabled = false;
        CrampLowaZoo = false;
        Dy.SetActive(false);
        RibLowaZoo = false;
        LowaZooQuit = 0;
    }

    //复活存牌区前三个tile进入复活区域
    public void ClotheLowa()
    {
        WeHone = true;
        for (int i = 0; i < 3; i++)
        {
            ClotheGnaw++;
            TileBehavior PresetTile = null;
            SlotBehavior PresetLost = null;

            PresetTile = OurLowaPlug[i].ActionTileBehavior();
            PresetLost = OurLowaPlug[i];
            Vector3 InitPosition = ClotheLowaPlug[i].transform.position;
            //if (i == 0)
            //{
            //    ReviveList1.Add(UseSlotList[i].ActionPrefabName());
            //    ReviveOffset = ReviveList1.Count * 0.05f;

            //}
            //else if (i==1)
            //{
            //    ReviveList2.Add(UseSlotList[i].ActionPrefabName());
            //    ReviveOffset = ReviveList2.Count * 0.05f;
            //}
            //else if (i==2)
            //{
            //    ReviveList3.Add(UseSlotList[i].ActionPrefabName());
            //    ReviveOffset = ReviveList3.Count * 0.05f;
            //}
            InitPosition.y += ClotheLagoon;
            InitPosition.z -= ClotheLagoon;
            PresetTile.SubmitMove(InitPosition, LevelScaler.SlotSize);
            PresetTile.SetSortingOrder(ClotheGnaw);
            PresetTile.ResetSubmitState();
            CanyPlug.Add(PresetTile);
            //layers[PresetTile.ElementPosition] = PresetTile;
            PresetLost.InitData();
            PresetTile.SetState(true, false);
        }
        ClotheLagoon += 0.05f;
        ClotheBeluga();
    }

    public void ClotheBeluga()
    {
        for (int j = 3; j < OurLowaPlug.Count; j++)
        {
            OurLowaPlug[j].ActionTileBehavior().SubmitMove(OurLowaPlug[j - 3].transform.position, LevelScaler.SlotSize);
            OurLowaPlug[j - 3].SetPosition(OurLowaPlug[j].ActionPrefabName(), OurLowaPlug[j].ActionTileBehavior());
            OurLowaPlug[j].InitData();
        }
    }

    //魔法棒
    public void FamilyCany(bool IsVolun)
    {
        if (!IsVolun)
        {
            if (!FamilyOxygen.activeSelf)
            {
                FamilyOxygen.SetActive(true);
            }
            else
            {
                FamilyOxygen.GetComponent<ParticleSystem>().Play();
            }
            OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_Wand);
        }
        int requiredElementsCount = 3;
        TileData tileData = null;
        List<SlotBehavior> slotTiles = PenBattleLowa();
        if (slotTiles.IsNullOrEmpty())
        {
            List<TileBehavior> ActiveTiles = PenBattleShare();
            if (!ActiveTiles.IsNullOrEmpty())
            {
                if (IsVolun)
                {
                    ActiveTiles.Sort((x, y) => { return x.transform.position.y.CompareTo(-y.transform.position.y); });
                    tileData = ActiveTiles[0].TileData;
                }
                else
                {
                    tileData = ActiveTiles[Random.Range(0, ActiveTiles.Count - 1)].TileData;
                }
            }
        }
        else
        {
            tileData = slotTiles[0].ActionTileBehavior().TileData;
            requiredElementsCount = 2;
            for (int i = 0; i < slotTiles.Count - 1; i++)
            {
                tileData = slotTiles[1].ActionTileBehavior().TileData;
                if (slotTiles[i].ActionTileBehavior().TileData == slotTiles[i + 1].ActionTileBehavior().TileData)
                {
                    tileData = slotTiles[i].ActionTileBehavior().TileData;
                    requiredElementsCount = 1;
                    break;
                }
            }
        }
        if (tileData != null)
        {
            if ((OurLowaPlug.Count - slotTiles.Count) < requiredElementsCount)
            {
                return;
            }
            List<TileBehavior> targetTiles = new List<TileBehavior>(PenShareOnSpur(tileData, requiredElementsCount));
            for (int i = 0; i < targetTiles.Count; i++)
            {
                TileBehavior targetTile = targetTiles[i];
                targetTile.MarkAsSubmitted();
                targetTile.SetState(true, false);
            }
            StartCoroutine(RepeatShortage(targetTiles));
        }
        //关闭自动提示
        if (FamilyShare.Count > 0)
        {
            for (int i = 0; i < FamilyShare.Count; i++)
            {
                FamilyShare[i].CloseAni();
            }
            FamilyShare.Clear();
            WeFamily = true;
            FamilyQuit = 0;
        }

        LowaZoo.enabled = false;
        CrampLowaZoo = false;
        Dy.SetActive(false);
        RibLowaZoo = false;
        LowaZooQuit = 0;
    }

    //自动收牌
    public void FancyVictim()
    {
        if (CanyPlug.Count > 0)
        {
            Sequence seq = DOTween.Sequence();
            seq.AppendCallback(() =>
            {
                FamilyCany(true);
                seq.Kill();
            })
            .SetDelay(0.1f)
            .SetLoops(0);
        }
    }

    //自动提示
    public void FancyFamily()
    {
        TileData tileData = null;
        List<SlotBehavior> slotTiles = PenBattleLowa();
        List<TileBehavior> ActiveTiles = PenRecruitShare();

        for (int i = 0; i < ActiveTiles.Count; i++)
        {
            if (ActiveTiles.FindAll(s => s.TileData == ActiveTiles[i].TileData).Count >= 3)
            {
                tileData = ActiveTiles[i].TileData;
                break;
            }
        }

        if (tileData != null && OurLowaPlug.Count - slotTiles.Count >= 3)
        {
            for (int i = 0; i < 3; i++)
            {
                TileBehavior tile = ActiveTiles.Find(s => s.TileData == tileData);
                ActiveTiles.Remove(tile);
                FamilyShare.Add(tile);
            }
        }
    }

    //获取还未递交的tile
    public List<TileBehavior> PenBattleShare()
    {
        List<TileBehavior> tempTiles = new List<TileBehavior>();
        List<TileBehavior> activeTiles = CanyPlug;

        for (int i = 0; i < activeTiles.Count; i++)
        {
            if (!activeTiles[i].IsSubmitted)
            {
                tempTiles.Add(activeTiles[i]);
            }
        }

        return tempTiles;
    }

    //获取可以点击的全部tile
    public List<TileBehavior> PenRecruitShare()
    {
        List<TileBehavior> tempTiles = new List<TileBehavior>();
        List<TileBehavior> activeTiles = CanyPlug;

        for (int i = 0; i < activeTiles.Count; i++)
        {
            if (activeTiles[i].IsClickable)
            {
                tempTiles.Add(activeTiles[i]);
            }
        }

        return tempTiles;
    }
    public List<TileBehavior> PenShareOnSpur(TileData tileData, int amout = int.MaxValue)
    {
        List<TileBehavior> tempTiles = new List<TileBehavior>();
        List<TileBehavior> activeTiles = CanyPlug;
        for (int i = 0; i < activeTiles.Count; i++)
        {
            if (!activeTiles[i].IsSubmitted)
            {
                if (activeTiles[i].TileData == tileData)
                {
                    tempTiles.Add(activeTiles[i]);

                    if (tempTiles.Count >= amout)
                        break;
                }
            }
        }

        return tempTiles;
    }

    //获取有赋值的slot
    public List<SlotBehavior> PenBattleLowa()
    {
        List<SlotBehavior> ActiveSlot = new List<SlotBehavior>();
        foreach (SlotBehavior item in OurLowaPlug)
        {
            if (item.ActionValue())
            {
                ActiveSlot.Add(item);
            }
            else
            {
                break;
            }
        }
        return ActiveSlot;
    }

    //卸载关卡
    public void UnThenClump()
    {
        if (CanyPlug != null)
        {
            for (int i = 0; i < OurLowaPlug.Count; i++)
            {
                OurLowaPlug[i].InitData();
            }
            for (int i = 0; i < CanyPlug.Count; i++)
            {
                CanyPlug[i].Clear();
            }
            Impact.Clear();
        }
    }

    //点击
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && OilyMimetic.PenMonopoly().EngineGuess)
            {
                IClickableObject clickableObject = hit.transform.GetComponent<IClickableObject>();
                if (clickableObject != null)
                {
                    for (int i = 0; i < FamilyShare.Count; i++)
                    {
                        FamilyShare[i].CloseAni();
                    }
                    FamilyShare.Clear();
                    WeFamily = true;
                    FamilyQuit = 0;
                    clickableObject.OnObjectClicked();
                }
            }
        }
        if (WeFamily && !OilyMimetic.PenMonopoly().WePenal)
        {
            FamilyQuit += Time.deltaTime;
            if (FamilyQuit > 20)
            {
                FancyFamily();
                if (FamilyShare.Count > 0)
                {
                    for (int i = 0; i < FamilyShare.Count; i++)
                    {
                        FamilyShare[i].SetAnimation("Tile_idle");
                    }
                    WeFamily = false;
                }
                FamilyQuit = 0;
            }
        }

        if (CrampLowaZoo)
        {
            LowaZooQuit += Time.deltaTime;
            if (LowaZooQuit > 5)
            {
                LowaZoo.enabled = true;
                LowaZoo.Play("Level_warn");
                CrampLowaZoo = false;
            }
        }
    }

    //提取tile，移动，重置位置，重置状态
    public void RepeatExamine(TileBehavior tileBehavior)
    {
        //赋值
        for (int i = 0; i < OurLowaPlug.Count; i++)
        {
            if (!OurLowaPlug[i].ActionValue())
            {
                tileBehavior.SubmitMove(OurLowaPlug[i].transform.position, LevelScaler.SlotSize, AsiaRib);
                OurLowaPlug[i].SetPosition(tileBehavior.TileData.Prefab.name, tileBehavior);
                break;
            }
            else
            {
                //先插入到list中 
                //判断当前的tile是否和选中的一样  如果一样将当前的tile插入到后面
                //如果后面还有值，则将后面的值往后移动
                if (OurLowaPlug[i].ActionTileBehavior().TileData == tileBehavior.TileData)
                {
                    for (int j = OurLowaPlug.Count - 1; j > i; j--)
                    {
                        if (OurLowaPlug[j].ActionValue())
                        {
                            OurLowaPlug[j].ActionTileBehavior().SubmitMove(OurLowaPlug[j + 1].transform.position, LevelScaler.SlotSize, AsiaRib);
                            OurLowaPlug[j + 1].SetPosition(OurLowaPlug[j].GetComponent<SlotBehavior>().ActionPrefabName(), OurLowaPlug[j].ActionTileBehavior());
                        }
                    }

                    tileBehavior.SubmitMove(OurLowaPlug[i + 1].transform.position, LevelScaler.SlotSize, AsiaRib);
                    OurLowaPlug[i + 1].SetPosition(tileBehavior.TileData.Prefab.name, tileBehavior);
                    break;
                }
            }
        }
        ElusiveClue++;
        tileBehavior.MarkAsSubmitted();
        HyksosRelief(tileBehavior);
        HazardOffend(true);
    }

    //批量提取tile
    public IEnumerator RepeatShortage(List<TileBehavior> tileBehaviors)
    {
        for (int i = 0; i < tileBehaviors.Count; i++)
        {
            RepeatExamine(tileBehaviors[i]);
            yield return new WaitForSeconds(0.05f);
        }
    }

    //移动结束
    public void AsiaRib()
    {
        //消除
        for (int i = 0; i < OurLowaPlug.Count; i++)
        {
            if (i + 2 < OurLowaPlug.Count)
            {
                if (OurLowaPlug[i + 1].ActionPrefabName() != "")
                {
                    if (OurLowaPlug[i].ActionTileBehavior().TileData == OurLowaPlug[i + 1].ActionTileBehavior().TileData)
                    {
                        if (OurLowaPlug[i + 2].ActionPrefabName() != "")
                        {
                            if (OurLowaPlug[i + 1].ActionTileBehavior().TileData == OurLowaPlug[i + 2].ActionTileBehavior().TileData)
                            {

                                //消除动画
                                OurLowaPlug[i].ActionTileBehavior().SetAnimation("Tile_C_end");
                                OurLowaPlug[i].CloseTile();
                                //初始化数据
                                OurLowaPlug[i].InitData();
                                //消除动画
                                HyksosFrost = MesopotamiaMyUILyric(OurLowaPlug[i + 1].gameObject.transform);
                                OurLowaPlug[i + 1].ActionTileBehavior().SetAnimation("Tile_C_end");
                                OurLowaPlug[i + 1].CloseTile();
                                //初始化数据
                                OurLowaPlug[i + 1].InitData();
                                //消除动画
                                OurLowaPlug[i + 2].ActionTileBehavior().SetAnimation("Tile_C_end");
                                OurLowaPlug[i + 2].CloseTile();
                                //初始化数据
                                OurLowaPlug[i + 2].InitData();
                                OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_Match);
                                OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.HeavyImpact);
                                if (!TemperFile.WeSound())
                                {
                                    OilyToxic.instance.BelugaFamily();
                                }
                                //判断后面还有没有 如果有就往前移动
                                if (i + 3 < OurLowaPlug.Count)
                                {
                                    for (int j = i + 3; j < OurLowaPlug.Count; j++)
                                    {
                                        if (OurLowaPlug[j].ActionValue())
                                        {
                                            OurLowaPlug[j].ActionTileBehavior().SubmitMove(OurLowaPlug[j - 3].transform.position, LevelScaler.SlotSize, AsiaRib);
                                            OurLowaPlug[j - 3].SetPosition(OurLowaPlug[j].ActionPrefabName(), OurLowaPlug[j].ActionTileBehavior());
                                            OurLowaPlug[j].InitData();
                                        }
                                    }
                                }
                                if (!OilyMimetic.PenMonopoly().WePenal)
                                {
                                    RedbudSolder();
                                }
                                else
                                {
                                    OilyToxic.instance.LysBank(HyksosFrost, 1);
                                    if (CanyPlug.Count > 0)
                                    {
                                        for (int z = 0; z < CanyPlug.Count; z++)
                                        {
                                            CanyPlug[z].ResetSubmitState();
                                            CanyPlug[z].SetBlockState(false);
                                            CanyPlug[z].SetState(true, false);
                                            CanyPlug[z].SetAnimation("Tile_idle");
                                        }
                                    }
                                    else
                                    {
                                        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_Win);
                                        PlayerPrefs.SetInt(CLagoon.RedbudPenalClump, 1);
                                        OilyMimetic.PenMonopoly().WePenal = false;

                                        if (TemperFile.WeSound())
                                        {
                                            UIMimetic.PenMonopoly().HatchMeBioticUIBasin(nameof(OilyToxicIOS));
                                            UIMimetic.PenMonopoly().BlueUIBasin(nameof(RedbudToxicIOS));
                                        }
                                        else
                                        {
                                            UIMimetic.PenMonopoly().HatchMeBioticUIBasin(nameof(OilyToxic));
                                            UIMimetic.PenMonopoly().BlueUIBasin(nameof(RedbudToxic));
                                        }
                                        
                                    }
                                    break;
                                }
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }

        if (OurLowaPlug.Last().ActionValue() && WeHone)
        {
            WeHone = false;
            OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_Fail);
            if (OilyMimetic.PenMonopoly().WeAdmission)
            {
                OilyMimetic.PenMonopoly().ModestlyHone();
            }
            else
            {
                if (TemperFile.WeSound())
                {
                    UIMimetic.PenMonopoly().BlueUIBasin(nameof(HoneToxicIOS));
                }
                else
                {
                    UIMimetic.PenMonopoly().BlueUIBasin(nameof(HoneToxic));
                }
            }
        }
        if (OurLowaPlug.Count - PenBattleLowa().Count == 1)
        {
            CrampLowaZoo = true;
        }
        else
        {
            LowaZoo.enabled = false;
            CrampLowaZoo = false;
            RibLowaZoo = false;
            Dy.SetActive(false);
        }
    }

    public Vector3 MesopotamiaMyUILyric(Transform worldPoint)
    {
        Camera camera = Camera.main;
        Vector3 screenPoint = camera.ScreenToViewportPoint(worldPoint.position) + new Vector3(0, -0.3f, 0);
        //screenPoint = screenPoint + worldPoint.position;

        return screenPoint;
    }

    public void RedbudSolder()
    {
        if (CanyPlug.Count == 0)
        {
            //完成关卡
            Sequence seq = DOTween.Sequence();
            seq.AppendCallback(() =>
            {
                FancyOxygen.SetActive(false);
                //完成关卡
                OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_Win);
                if (TemperFile.WeSound())
                {
                    UIMimetic.PenMonopoly().HatchMeBioticUIBasin(nameof(OilyToxicIOS));
                    UIMimetic.PenMonopoly().BlueUIBasin(nameof(RedbudToxicIOS));
                }
                else
                {
                    UIMimetic.PenMonopoly().HatchMeBioticUIBasin(nameof(OilyToxic));
                    UIMimetic.PenMonopoly().BlueUIBasin(nameof(RedbudToxic));
                }
                return;
            })
            .SetDelay(1f)
            .SetLoops(0);
        }

        if (!WeRyeClumpAdmission)
        {
            // 如果场中存在的tile数量 <= 15开始自动收牌  开启自动收牌关闭连消提示 达到关卡限制
            if (!(CanyPlug.Count + PenBattleLowa().Count <= SawSelfEke.instance.OilyHave.Auto_Complete && OilyMimetic.PenMonopoly().WeFancy && PlayerPrefs.GetInt(CLagoon.No_RyeClump) >= SawSelfEke.instance.OilyHave.Quickplay_Config))
            {
                if (!TemperFile.WeSound())
                {
                    if (OilyToxic.instance.PearBust())
                    {
                        return;
                    }
                }
            }
            else
            {
                if (!FancyOxygen.activeSelf)
                {
                    FancyOxygen.SetActive(true);
                }
                else
                {
                    FancyOxygen.GetComponent<ParticleSystem>().Play();
                }
                OilyMimetic.PenMonopoly().EngineGuess = false;
                if (!TemperFile.WeSound())
                {
                    OilyToxic.instance.WeSpeedyLime(true);
                }  
                FancyVictim();
            }
        }
        if (!TemperFile.WeSound())
        {
            if (ElusiveClue <= 3)
            {
                SoftnessFloral++;
                switch (SoftnessFloral)
                {
                    case 0:
                        OilyToxic.instance.LysBank(HyksosFrost, double.Parse(EvokeSweetHave[0].Split('|')[1]));
                        break;
                    case 1:
                        OilyToxic.instance.LysBank(HyksosFrost, double.Parse(EvokeSweetHave[1].Split('|')[1]));
                        break;
                    case 2:
                        OilyToxic.instance.LysBank(HyksosFrost, double.Parse(EvokeSweetHave[2].Split('|')[1]));
                        break;
                    case 3:
                        OilyToxic.instance.LysBank(HyksosFrost, double.Parse(EvokeSweetHave[3].Split('|')[1]));
                        break;
                    case 4:
                        OilyToxic.instance.LysBank(HyksosFrost, double.Parse(EvokeSweetHave[4].Split('|')[1]));
                        break;
                    case 5:
                        OilyToxic.instance.LysBank(HyksosFrost, double.Parse(EvokeSweetHave[5].Split('|')[1]));
                        break;
                    default:
                        OilyToxic.instance.LysBank(HyksosFrost, double.Parse(EvokeSweetHave[5].Split('|')[1]));
                        break;
                }
                if (SoftnessFloral > 0)
                {
                    OilyToxic.instance.SoftnessYew(SoftnessFloral);
                }
            }
            else
            {
                SoftnessFloral = 0;
                OilyToxic.instance.LysBank(HyksosFrost, 1);
            }
            ElusiveClue = 0;
        }
    }

    public void WeProdigyFancy()
    {
        if (!WeRyeClumpAdmission)
        {
            if (CanyPlug.Count + PenBattleLowa().Count <= SawSelfEke.instance.OilyHave.Auto_Complete && OilyMimetic.PenMonopoly().WeFancy && PlayerPrefs.GetInt(CLagoon.No_RyeClump) >= SawSelfEke.instance.OilyHave.Quickplay_Config)
            {
                RedbudSolder();
            }
        }
    }

    //给tile赋值
    private IEnumerator PenSeldomShare()
    {
        //加载动画完成，给tilelist排序，为自动收牌和魔法棒做准备
        CanyPlug.Sort((x, y) => { return x.transform.position.y.CompareTo(-y.transform.position.y); });
        // Reset objects
        List<TileBehavior> tileBehaviors = CanyPlug;
        tileBehaviors.Sort((x, y) => { return x.transform.position.y.CompareTo(y.transform.position.y); });
        //将tile尺寸改为0  并且设置成未激活状态
        foreach (TileBehavior tileBehavior in tileBehaviors)
        {
            tileBehavior.transform.localScale = Vector3.zero;
            tileBehavior.SetState(false, false);
        }

        for (int i = 0; i < tileBehaviors.Count; i++)
        {
            tileBehaviors[i].SetState(WeCanyNonetheless(tileBehaviors[i]));
            yield return null;
            tileBehaviors[i].transform.DOKill();
            // 创建序列
            Sequence sequence = DOTween.Sequence();

            // 添加放大动画
            sequence.Append(tileBehaviors[i].transform.DOScale(1.5f, 0.2f)
                .SetEase(Ease.OutQuad));

            // 添加缩小动画 (回到原始大小)
            sequence.Append(tileBehaviors[i].transform.DOScale(1, 0.2f)
                .SetEase(Ease.OutQuad));

            // 设置动画完成后自动销毁
            sequence.OnComplete(() => {
                // 这里可以添加动画完成后的逻辑
            });
        }
        if (!TemperFile.WeSound())
        {

            OilyToxic.instance.WeSpeedyLime(false);
        }
        if (!(PlayerPrefs.GetInt(CLagoon.RedbudEnclosurePenal) == 0))
        {
            OilyMimetic.PenMonopoly().EngineGuess = true;
        }

    }

    public void CanySpinetConestoga(List<TileBehavior> tileBehaviors)
    {
        tileBehaviors.Sort((x, y) => { return x.transform.position.y.CompareTo(y.transform.position.y); });
        //将tile尺寸改为0  并且设置成未激活状态
        foreach (TileBehavior tileBehavior in tileBehaviors)
        {
            tileBehavior.transform.localScale = Vector3.zero;
            tileBehavior.SetState(false, false);
        }

        for (int i = 0; i < tileBehaviors.Count; i++)
        {
            tileBehaviors[i].SetState(WeCanyNonetheless(tileBehaviors[i]));
            //yield return null;
            tileBehaviors[i].transform.DOKill();
            // 创建序列
            Sequence sequence = DOTween.Sequence();

            // 添加放大动画
            sequence.Append(tileBehaviors[i].transform.DOScale(1.5f, 0.2f)
                .SetEase(Ease.OutQuad));

            // 添加缩小动画 (回到原始大小)
            sequence.Append(tileBehaviors[i].transform.DOScale(1, 0.2f)
                .SetEase(Ease.OutQuad));

            // 设置动画完成后自动销毁
            sequence.OnComplete(() => {
                // 这里可以添加动画完成后的逻辑
            });
        }
    }

    //更新tile状态
    public void HazardOffend(bool withAnimation = false)
    {
        foreach (TileBehavior tile in CanyPlug)
        {
            tile.SetState(WeCanyNonetheless(tile), withAnimation);
        }
    }

    //选中tile之后 在TileList中移除tile
    public void HyksosRelief(TileBehavior tile)
    {
        //if (ReviveList1.Contains(tile.TileData.Prefab.name))
        //{
        //    ReviveList1.Remove(tile.TileData.Prefab.name);
        //}
        //else if (ReviveList2.Contains(tile.TileData.Prefab.name))
        //{
        //    ReviveList2.Remove(tile.TileData.Prefab.name);
        //}
        //else if (ReviveList3.Contains(tile.TileData.Prefab.name))
        //{
        //    ReviveList3.Remove(tile.TileData.Prefab.name);
        //}
        CanyPlug.Remove(tile);
        Impact[tile.ElementPosition] = null;
    }

    //给tile赋值位置和状态
    public bool WeCanyNonetheless(ElementPosition tilePos)
    {
        if (tilePos.LayerId == 0)
            return true;
        var layerIdFromBottom = RyeClump.layers.Count - tilePos.LayerId - 1;
        bool isEven = layerIdFromBottom % 2 == 0;

        for (int i = tilePos.LayerId - 1; i >= 0; i--)
        {
            var thislayerIdFromBottom = RyeClump.layers.Count - i - 1;

            bool isLayerEven = thislayerIdFromBottom % 2 == 0;

            var position = new ElementPosition(tilePos, i);

            if (isEven == isLayerEven)
            {
                // if there is something directly above object, it is not available

                if (Impact[position].State)
                    return false;
            }
            else
            {
                var Yean= isLayerEven ? HourThankTray : BudThankTray;

                bool sizeIsBigger;
                if (isLayerEven)
                {
                    sizeIsBigger = WeNeverThankRecede;
                }
                else
                {
                    sizeIsBigger = !WeNeverThankRecede;
                }

                position = new ElementPosition(sizeIsBigger ? position + 1 : position - 1, i);

                // Checking if there is something partly above the object. If there is - it is not available
                // Should check 4 times because every odd lever is bigger and shifted a little bit

                if (position.X != -1 && position.Y != -1 && position.X != Yean.x && position.Y != Yean.y && Impact[position].State)
                    return false;

                if (sizeIsBigger)
                {
                    var leftNeighbourPos = position.LeftNeighbourPos;
                    if (leftNeighbourPos.X != -1 && leftNeighbourPos.Y != Yean.y && Impact[leftNeighbourPos].State)
                        return false;

                    var topNeighbourPos = position.UpNeighbourPos;
                    if (topNeighbourPos.X != Yean.x && topNeighbourPos.Y != -1 && Impact[topNeighbourPos].State)
                        return false;

                    var topLeftNeighbourPos = topNeighbourPos.LeftNeighbourPos;
                    if (topLeftNeighbourPos.X != -1 && topLeftNeighbourPos.Y != -1 && Impact[topLeftNeighbourPos].State)
                        return false;
                }
                else
                {
                    var rightNeighbourPos = position.RightNeighbourPos;
                    if (rightNeighbourPos.X != Yean.x && rightNeighbourPos.Y != -1 && Impact[rightNeighbourPos].State)
                        return false;

                    var bottomNeighbourPos = position.BottomNeighbourPos;

                    if (bottomNeighbourPos.X != -1 && bottomNeighbourPos.Y != Yean.y && Impact[bottomNeighbourPos].State)
                        return false;

                    var bottomRightNeighbourPos = bottomNeighbourPos.RightNeighbourPos;
                    if (bottomRightNeighbourPos.X != Yean.x && bottomRightNeighbourPos.Y != Yean.y && Impact[bottomRightNeighbourPos].State)
                        return false;
                }
            }
        }

        return true;
    }

    public List<SlotBehavior> PenOurArid()
    {
        return OurLowaPlug;
    }
}

