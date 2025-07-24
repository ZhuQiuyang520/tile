using DG.Tweening;
using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using Watermelon;

public class RoadBrother : MonoBehaviour
{
    public static RoadBrother instance;

    [SerializeField] LevelDatabase AfterFollower;
    public static LevelDatabase Follower=> instance.AfterFollower;
    [SerializeField] LevelData IdealBleakNeck;
    [SerializeField] PreloadedLevelData IdealLinearBleakNeck;
    [SerializeField] LevelScaler AfterPoison;
    [SerializeField] GameData Wipe;
    [SerializeField] Color PoleSocietyTract;
[UnityEngine.Serialization.FormerlySerializedAs("RemindEffect")]
    public GameObject ForgetVenice;
[UnityEngine.Serialization.FormerlySerializedAs("VolunEffect")]    public GameObject PearlVenice;
[UnityEngine.Serialization.FormerlySerializedAs("SlotAni")]
    public Animator ThawEra;
[UnityEngine.Serialization.FormerlySerializedAs("mb")]    public GameObject Dy;
    private bool StoveThawEra;
    private bool SewThawEra;
    private float ThawEraPass;
[UnityEngine.Serialization.FormerlySerializedAs("LevelObj")]
    public GameObject BleakLop;
[UnityEngine.Serialization.FormerlySerializedAs("LevelParentObj")]    public GameObject BleakMaidenLop;
[UnityEngine.Serialization.FormerlySerializedAs("AddSlotObj")]
    public GameObject LidThawLop;
[UnityEngine.Serialization.FormerlySerializedAs("SlotPrefab")]    public SlotBehavior ThawPotato;
[UnityEngine.Serialization.FormerlySerializedAs("SlotList")]
    public List<SlotBehavior> ThawFire;
[UnityEngine.Serialization.FormerlySerializedAs("ReviveSlotList")]    public List<GameObject> UpwindThawFire;

    private List<SlotBehavior> LieThawFire= new List<SlotBehavior>();
[UnityEngine.Serialization.FormerlySerializedAs("CurLevel")]
    public static LevelData EatBleak;
    public static GameData Neck=> instance.Wipe;

    private Vector2Int Kill;
    public static Vector2Int SailValueHoly=> new Vector2Int(EatBleak.GetLayer(EatBleak.AmountOfLayers - 1).GetRow(0).AmountOfCells, EatBleak.GetLayer(EatBleak.AmountOfLayers - 1).AmountOfRows);
    public static Vector2Int RobValueHoly=> new Vector2Int(EatBleak.GetLayer(EatBleak.AmountOfLayers - 2).GetRow(0).AmountOfCells, EatBleak.GetLayer(EatBleak.AmountOfLayers - 2).AmountOfRows);

    public static bool OfRarerValueHandle=> SailValueHoly.x > RobValueHoly.x;
    private List<TileBehavior> DripFire;
    private LayersMatrix Recede;
    private List<TileSpawnData> TradeHumor;

    private float ForgetPass;
[UnityEngine.Serialization.FormerlySerializedAs("IsRemind")]    public bool OfForget;
    private List<TileBehavior> ForgetHumor= new List<TileBehavior>();

    private int AdequacyBorrow;
    private int MexicanFeat;

    private bool OfEatBleakTelescope;

    private int UpwindSord= 0;
    private float UpwindAssert= 0;

    //private Transform ObtainShake;

    private Vector3 ObtainShakeV3;

    

    public bool IsFail;

    //private List<string> ReviveList1 = new List<string>();
    //private List<string> ReviveList2 = new List<string>();
    //private List<string> ReviveList3 = new List<string>();

    private void Awake()
    {
        instance = this;
        //初始化level基础数据
        AfterFollower.Initialise();
    }

    private void Start()
    {
        ForgetPass = 0;
        OfForget = false;
        for (int i = 0; i < ThawFire.Count; i++)
        {
            ThawFire[i].SettingOrder(i);
        }
    }

    //游戏退出时记录登出时间
    public void OnApplicationQuit()
    {
        // 将DateTime转换为长整型（Ticks）存储
        PlayerPrefs.SetString(CConfig.Last_Logout_Time_Key, System.DateTime.Now.Ticks.ToString());
        PlayerPrefs.Save();
    }

    //加载关卡
    public void BeamBleak(int index)
    {
        IsFail = true;
        UpwindSord = 0;
        UpwindAssert = 0;
        OfEatBleakTelescope = RoadTenuous.GetInstance().OfTelescope;
        if (PlayerPrefs.GetInt(CConfig.OnceEnterChallenge) == 1 && OfEatBleakTelescope)
        {
            PlayerPrefs.SetInt(CConfig.OnceEnterChallenge, 0);
            RoadTenuous.GetInstance().ReliefStilt = false;
            UIManager.GetInstance().ShowUIForms(nameof(WispyLikeLoder));
        }
        OfForget = false;
        AdequacyBorrow = -1;
        MexicanFeat = 0;
        StoveThawEra = false;
        SewThawEra = false;
        ThawEraPass = 0;
        if (ThawPotato.gameObject.activeSelf)
        {
            LidThawLop.SetActive(true);
            ThawPotato.gameObject.SetActive(false);
            LieThawFire.Remove(ThawPotato);
        }
        LieThawFire = ThawFire;
        UnBeamBleak();

        DripFire = new List<TileBehavior>();
        
        //加载level
        EatBleak = AfterFollower.GetLevel(index);
            
        TradeHumor = new List<TileSpawnData>();
        AfterPoison.Recalculate();
        BleakMaidenLop.transform.position = AfterPoison.LevelFieldCenter;
        TileData[] availableObjects = AfterFollower.AvailableForLevel(EatBleak);
        TileData[] initialTilesData = ElevateStomachHumor(availableObjects);

        Recede = new LayersMatrix(EatBleak, BleakMaidenLop);
        for (int i = 0; i < EatBleak.AmountOfLayers; i++)
        {
            Recede.Layers[i].LayerObject.transform.position -= new Vector3(0,0.06f * (LevelScaler.TileSize.y/Wipe.TileSize.y),0) * i;
            Layer layer = EatBleak.GetLayer(i);
            Kill = (EatBleak.AmountOfLayers - i - 1) % 2 == 0 ? SailValueHoly : RobValueHoly;
            for (int y = Kill.y - 1; y >= 0; y--)
            {
                for (int x = 0; x < Kill.x; x++)
                {
                    CellData cellData = layer[y].GetCell(x);
                    if (cellData.IsFilled)
                    {
                        TileSpawnData tileSpawnData = new TileSpawnData();
                        tileSpawnData.ScholarDiffuses = new ElementPosition(x, y, i);
                        tileSpawnData.JuneNeck = cellData;
                        tileSpawnData.ValueAlarm = i;
                        tileSpawnData.Value = layer;
                        tileSpawnData.ValueHoly = Kill;
                        TradeHumor.Add(tileSpawnData);
                    }
                }
            }
        }
        for (int i = 0; i < initialTilesData.Length; i++)
        {
            //随机选择一个预制体样式
            TileSpawnData firstTileSpawnData = TradeHumor.OrderBy(x => Random.value).OrderBy(x => x.ScholarDiffuses.Y).FirstOrDefault();
            TradeHumor.Remove(firstTileSpawnData);
            TileBehavior firstElementBehavior = LapisDrip(initialTilesData[i], firstTileSpawnData.ScholarDiffuses);

            float totalWeight = 0;
            foreach (TileSpawnData emptyTile in TradeHumor)
            {
                emptyTile.AcquisitionMature(firstTileSpawnData.ValueAlarm);
                totalWeight += emptyTile.HardenMature;
            }

            for (int a = 0; a < 2; a++)
            {
                float randomValue = Random.Range(0, totalWeight);
                float currentWeight = 0;
                TileSpawnData selectedTileData = null;
                foreach (TileSpawnData emptyTile in TradeHumor)
                {
                    currentWeight += emptyTile.HardenMature;
                    if (currentWeight >= randomValue)
                    {
                        selectedTileData = emptyTile;
                        break;
                    }
                }
                if (selectedTileData != null)
                {
                    TradeHumor.Remove(selectedTileData);
                    totalWeight -= selectedTileData.HardenMature;

                    TileBehavior additionalElementBehavior = LapisDrip(initialTilesData[i], selectedTileData.ScholarDiffuses);
                }
            }
        }
        
        
        if (!OfEatBleakTelescope)
        {
            //执行动画 挑战关卡不执行加载动画
            StartCoroutine(MobAcidicHumor());
        }
        else
        {
            foreach (var item in DripFire)
            {
                item.SetState(false, false);
            }
            for (int i = 0; i < DripFire.Count; i++)
            {
                DripFire[i].SetState(OfDripUndisturbed(DripFire[i]));
            }
        }
    }

    private List<TileBehavior> FrescoHumor;
    private List<TileBehavior> DitchHumor;
    public void AimIdeal()
    {
        LieThawFire = ThawFire;
        DripFire = new List<TileBehavior>();
        BeamIdealBleak(IdealBleakNeck, IdealLinearBleakNeck, () => {
            FrescoHumor = new List<TileBehavior>();
            FrescoHumor.Add(MobDrip(new ElementPosition(0, 0, 1)));
            FrescoHumor.Add(MobDrip(new ElementPosition(1, 0, 1)));
            FrescoHumor.Add(MobDrip(new ElementPosition(2, 0, 1)));

            foreach (var cheese in FrescoHumor)
            {
                cheese.SetBlockState(true);
                cheese.SetColor(PoleSocietyTract, true);
            }

            // Get apple tiles
            DitchHumor = new List<TileBehavior>();
            DitchHumor.Add(MobDrip(new ElementPosition(0, 1, 1)));
            DitchHumor.Add(MobDrip(new ElementPosition(1, 1, 1)));
            DitchHumor.Add(MobDrip(new ElementPosition(2, 1, 1)));

            foreach (var apple in DitchHumor)
            {
                apple.SetBlockState(false);
                apple.SetAnimation("Tile_idle");
            }
        });
    }

    private void BeamIdealBleak(LevelData levelData, PreloadedLevelData preloadedLevelData,SimpleCallback onLevelLoaded = null)
    {
        EatBleak = levelData;
        BleakLop.SetActive(true);
        AfterPoison.Recalculate();
        BleakMaidenLop.transform.position = AfterPoison.LevelFieldCenter;

        Recede = new LayersMatrix(EatBleak, BleakMaidenLop);
        
        LapisMission(preloadedLevelData);

        onLevelLoaded();
    }

    public void LapisMission(PreloadedLevelData preloadedLevelData)
    {
        preloadedLevelData.Initialise();
        PreloadedLevelData.Tile[] preloadTiles = preloadedLevelData.Tiles;
        foreach (PreloadedLevelData.Tile tile in preloadTiles)
        {
            TileData tileData = tile.TileData;
            ElementPosition elementPosition = tile.ElementPosition;
            TileBehavior tileBehavior = tileData.Pool.MobTempleBounce().GetComponent<TileBehavior>();
            tileBehavior.Initialise(tileData, elementPosition);
            tileBehavior.transform.SetParent(Recede[elementPosition.LayerId].LayerObject.transform);
            tileBehavior.transform.localPosition = LevelScaler.GetPosition(tile.ElementPosition);
            tileBehavior.transform.localScale = Vector3.one;
            tileBehavior.SetScale(LevelScaler.TileSize);

            Recede[tile.ElementPosition] = tileBehavior;

            // Figuring out is object is Active
            tileBehavior.SetState(OfDripUndisturbed(tileBehavior), false);


            DripFire.Add(tileBehavior);
        }
    }
    public TileBehavior MobDrip(ElementPosition elementPosition)
    {
        if (OfDripImpair(elementPosition))
        {
            return Recede[elementPosition].Tile;
        }

        return null;
    }
    public bool OfDripImpair(ElementPosition elementPosition)
    {
        int layerId = elementPosition.LayerId;
        int width = Recede[layerId].Width;
        int height = Recede[layerId].Height;

        if (elementPosition.X >= 0 && elementPosition.X < width && elementPosition.Y >= 0 && elementPosition.Y < height)
        {
            return Recede[elementPosition].State;
        }

        return false;
    }

    //给除了第一层的其他层级赋值
    private TileData[] ElevateStomachHumor(TileData[] availableTilesData)
    {
        // Helps keep track of the amount of already included tiles
        Dictionary<TileData, int> objectsInLevelAmount = new Dictionary<TileData, int>();

        var initialTilesData = new List<TileData>();

        int tilesDataLeft = EatBleak.GetAmountOfFilledCells();

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
        public ElementPosition ScholarDiffuses;
        public CellData JuneNeck;

        public int ValueAlarm;
        public Layer Value;
        public Vector2Int ValueHoly;

        public float HardenMature;

        public void AcquisitionMature(int baseLayerIndex)
        {
            int layerDiff = ValueAlarm - baseLayerIndex;

            HardenMature = Mathf.Clamp(3 - layerDiff, 0, int.MaxValue);
        }
    }

    private TileBehavior LapisDrip(TileData tileData, ElementPosition elementPosition)
    {
        TileBehavior tile = tileData.Pool.MobTempleBounce().GetComponent<TileBehavior>();
        tile.Initialise(tileData, elementPosition);
        tile.transform.SetParent(Recede.Layers[elementPosition.LayerId].LayerObject.transform);
        tile.transform.localPosition = LevelScaler.GetPosition(tile.ElementPosition);
        tile.transform.localScale = Vector3.one;
        tile.SetScale(LevelScaler.TileSize);
        
        Recede[tile.ElementPosition] = tile;

        // Figuring out is object is Active
        tile.SetState(OfDripUndisturbed(tile), false);

        // Add tile to global tiles list
        DripFire.Add(tile);

        return tile;
    }

    //增加槽位
    public void LidThaw()
    {
        ADManager.Instance.playRewardVideo((success) =>
        {
            LidThawLop.SetActive(false);
            PostEventScript.GetInstance().SendEvent("9007", "7");
            ThawPotato.gameObject.SetActive(true);
            ThawPotato.SettingOrder(7);
            LieThawFire.Add(ThawPotato);
            for (int i = 0; i < LieThawFire.Count; i++)
            {
                if (LieThawFire[i].ActionValue())
                {
                    LieThawFire[i].ActionTileBehavior().transform.position = LieThawFire[i].transform.position;
                }
            }

            ThawEra.enabled = false;
            Dy.SetActive(false);
            StoveThawEra = false;
            SewThawEra = false;
            ThawEraPass = 0;
        }, "110");
        
    }

    //刷新tile
    public void BookletDrip()
    {
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_Shuffle);
        //关闭自动提示
        if (ForgetHumor.Count > 0)
        {
            for (int i = 0; i < ForgetHumor.Count; i++)
            {
                ForgetHumor[i].CloseAni();
            }
            ForgetHumor.Clear();
            OfForget = true;
            ForgetPass = 0;
        }
        List<TileBehavior> ActiveTiles = DripFire;
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
                        allowedToShuffleTiles[i].transform.localScale = Vector3.zero;
                        allowedToShuffleTiles[i].transform.localPosition = LevelScaler.GetPosition(shuffleElements[i]);
                        allowedToShuffleTiles[i].SetPosition(shuffleElements[i]);
                    }

                    foreach (LayerGrid layer in Recede.Layers)
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

                    foreach (TileBehavior tile in DripFire)
                    {
                        ElementPosition elementPosition = tile.ElementPosition;

                        Recede.Layers[elementPosition.LayerId][elementPosition].LinkTile(tile);
                    }

                    DrenchSalmon(true);

                    BookletWaterfall(ActiveTiles, 0.5f, 0.05f, 0.4f);
                }
            }
        }
        
    }

    //点击刷新tile
    private void BookletWaterfall(List<TileBehavior> tiles ,float scaleDuration , float minDelay , float MaxDelay)
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
        StartCoroutine(DripFosterWaterfall(tiles));
    }
    //撤回tile
    public void BeltDareRDrip()
    {
        TileBehavior PresetTile = null;
        SlotBehavior PresetLost = null;
        //从后往前撤回
        for (int i = LieThawFire.Count - 1; i >= 0; i--)
        {
            if (LieThawFire[i].ActionValue())
            {
                PresetTile = LieThawFire[i].ActionTileBehavior();
                PresetLost = LieThawFire[i];
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
                DripFire.Add(PresetTile);
                Recede[PresetTile.ElementPosition] = PresetTile;
                PresetLost.InitData();
                DrenchSalmon(true);
            });
        }

        //关闭自动提示
        if (ForgetHumor.Count > 0)
        {
            for (int i = 0; i < ForgetHumor.Count; i++)
            {
                ForgetHumor[i].CloseAni();
            }
            ForgetHumor.Clear();
            OfForget = true;
            ForgetPass = 0;
        }
        ThawEra.enabled = false;
        StoveThawEra = false;
        Dy.SetActive(false);
        SewThawEra = false;
        ThawEraPass = 0;
    }

    public void UpwindThaw()
    {
        IsFail = true;
        for (int i = 0; i < 3; i++)
        {
            UpwindSord++;
            TileBehavior PresetTile = null;
            SlotBehavior PresetLost = null;

            PresetTile = LieThawFire[i].ActionTileBehavior();
            PresetLost = LieThawFire[i];
            Vector3 InitPosition = UpwindThawFire[i].transform.position;
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
            InitPosition.y += UpwindAssert;
            InitPosition.z -= UpwindAssert;
            PresetTile.SubmitMove(InitPosition, LevelScaler.SlotSize);
            PresetTile.SetSortingOrder(UpwindSord);
            PresetTile.ResetSubmitState();
            DripFire.Add(PresetTile);
            //layers[PresetTile.ElementPosition] = PresetTile;
            PresetLost.InitData();
            PresetTile.SetState(true,false);
        }
        UpwindAssert += 0.05f;
        UpwindDeepen();
    }

    public void UpwindDeepen()
    {
        for (int j = 3; j < LieThawFire.Count; j++)
        {
            LieThawFire[j].ActionTileBehavior().SubmitMove(LieThawFire[j - 3].transform.position, LevelScaler.SlotSize);
            LieThawFire[j - 3].SetPosition(LieThawFire[j].ActionPrefabName(), LieThawFire[j].ActionTileBehavior());
            LieThawFire[j].InitData();
        }
    }

    //魔法棒
    public void ForgetDrip(bool IsVolun)
    {
        if (!IsVolun)
        {
            if (!ForgetVenice.activeSelf)
            {
                ForgetVenice.SetActive(true);
            }
            else
            {
                ForgetVenice.GetComponent<ParticleSystem>().Play();
            }
            RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_Wand);
        }
        int requiredElementsCount = 3;
        TileData tileData = null;
        List<SlotBehavior> slotTiles = MobMidwayThaw();
        if (slotTiles.IsNullOrEmpty())
        {
            List<TileBehavior> ActiveTiles = MobMidwayHumor();
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
                if (slotTiles[i].ActionTileBehavior().TileData == slotTiles[i+1].ActionTileBehavior().TileData)
                {
                    tileData = slotTiles[i].ActionTileBehavior().TileData;
                    requiredElementsCount = 1;
                    break;
                }
            }
        }
        if (tileData != null)
        {
            if ((LieThawFire.Count - slotTiles.Count) < requiredElementsCount)
            {
                return;
            }
            List<TileBehavior> targetTiles = new List<TileBehavior>(MobHumorUpHard(tileData, requiredElementsCount));
            for (int i = 0; i < targetTiles.Count; i++)
            {
                TileBehavior targetTile = targetTiles[i];
                targetTile.MarkAsSubmitted();
                targetTile.SetState(true, false);
            }
            StartCoroutine(EdibleTriangle(targetTiles));
        }
        //关闭自动提示
        if (ForgetHumor.Count > 0)
        {
            for (int i = 0; i < ForgetHumor.Count; i++)
            {
                ForgetHumor[i].CloseAni();
            }
            ForgetHumor.Clear();
            OfForget = true;
            ForgetPass = 0;
        }

        ThawEra.enabled = false;
        StoveThawEra = false;
        Dy.SetActive(false);
        SewThawEra = false;
        ThawEraPass = 0;
    }

    //自动收牌
    public void PearlClient()
    {
        if (DripFire.Count > 0)
        {
            ForgetDrip(true);
        }
    }

    //自动提示
    public void PearlForget()
    {
        TileData tileData = null;
        List<SlotBehavior> slotTiles = MobMidwayThaw();
        List<TileBehavior> ActiveTiles = MobOnclickHumor();
        
        for (int i = 0; i < ActiveTiles.Count; i++)
        {
            if (ActiveTiles.FindAll(s => s.TileData == ActiveTiles[i].TileData).Count >= 3)
            {
                tileData = ActiveTiles[i].TileData;
                break;
            }
        }

        if (tileData != null && LieThawFire.Count - slotTiles.Count >= 3)
        {
            for (int i = 0; i < 3; i++)
            {
                TileBehavior tile = ActiveTiles.Find(s => s.TileData == tileData);
                ActiveTiles.Remove(tile);
                ForgetHumor.Add(tile);
            }
        }
    }

    //获取还未递交的tile
    public List<TileBehavior> MobMidwayHumor()
    {
        List<TileBehavior> tempTiles = new List<TileBehavior>();
        List<TileBehavior> activeTiles = DripFire;

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
    public List<TileBehavior> MobOnclickHumor()
    {
        List<TileBehavior> tempTiles = new List<TileBehavior>();
        List<TileBehavior> activeTiles = DripFire;

        for (int i = 0; i < activeTiles.Count; i++)
        {
            if (activeTiles[i].IsClickable)
            {
                tempTiles.Add(activeTiles[i]);
            }
        }

        return tempTiles;
    }
    public List<TileBehavior> MobHumorUpHard(TileData tileData , int amout = int.MaxValue)
    {
        List<TileBehavior> tempTiles = new List<TileBehavior>();
        List<TileBehavior> activeTiles = DripFire;
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
    public List<SlotBehavior> MobMidwayThaw()
    {
        List<SlotBehavior> ActiveSlot = new List<SlotBehavior>();
        foreach (SlotBehavior item in LieThawFire)
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
    public void UnBeamBleak()
    {
        if (DripFire != null)
        {
            for (int i = 0; i < LieThawFire.Count; i++)
            {
                LieThawFire[i].InitData();
            }
            for (int i = 0; i < DripFire.Count; i++)
            {
                DripFire[i].Clear();
            }
            Recede.Clear();
        }
    }

    //点击
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit) && RoadTenuous.GetInstance().ReliefStilt)
            {
                IClickableObject clickableObject = hit.transform.GetComponent<IClickableObject>();
                if (clickableObject != null)
                {
                    for (int i = 0; i < ForgetHumor.Count; i++)
                    {
                        ForgetHumor[i].CloseAni();
                    }
                    ForgetHumor.Clear();
                    OfForget = true;
                    ForgetPass = 0;
                    clickableObject.OnObjectClicked();
                }
            }
        }
        if (OfForget && !RoadTenuous.GetInstance().OfIdeal)
        {
            ForgetPass += Time.deltaTime;
            if (ForgetPass > 20)
            {
                PearlForget();
                if (ForgetHumor.Count > 0)
                {
                    for (int i = 0; i < ForgetHumor.Count; i++)
                    {
                        ForgetHumor[i].SetAnimation("Tile_idle");
                    }
                    OfForget = false;
                }
                ForgetPass = 0;
            }
        }

        if (StoveThawEra)
        {
            ThawEraPass += Time.deltaTime;
            if (ThawEraPass > 5)
            {
                ThawEra.enabled = true;
                ThawEra.Play("Level_warn");
                StoveThawEra = false;
            }
        }
    }

    //提取tile，移动，重置位置，重置状态
    public void EdibleScholar(TileBehavior tileBehavior)
    {
        //赋值
        for (int i = 0; i < LieThawFire.Count; i++)
        {
            if (!LieThawFire[i].ActionValue())
            {
                tileBehavior.SubmitMove(LieThawFire[i].transform.position, LevelScaler.SlotSize, SelfSew);
                LieThawFire[i].SetPosition(tileBehavior.TileData.Prefab.name, tileBehavior);
                break;
            }
            else
            {
                //先插入到list中 
                //判断当前的tile是否和选中的一样  如果一样将当前的tile插入到后面
                //如果后面还有值，则将后面的值往后移动
                if (LieThawFire[i].ActionTileBehavior().TileData == tileBehavior.TileData)
                {
                    for (int j = LieThawFire.Count - 1; j > i; j--)
                    {
                        if (LieThawFire[j].ActionValue())
                        {
                            LieThawFire[j].ActionTileBehavior().SubmitMove(LieThawFire[j + 1].transform.position, LevelScaler.SlotSize, SelfSew);
                            LieThawFire[j + 1].SetPosition(LieThawFire[j].GetComponent<SlotBehavior>().ActionPrefabName(), LieThawFire[j].ActionTileBehavior());
                        }
                    }

                    tileBehavior.SubmitMove(LieThawFire[i+1].transform.position, LevelScaler.SlotSize, SelfSew);
                    LieThawFire[i+1].SetPosition(tileBehavior.TileData.Prefab.name, tileBehavior);
                    break;
                }
            } 
        }
        MexicanFeat++;
        tileBehavior.MarkAsSubmitted();
        ObtainBounce(tileBehavior);
        DrenchSalmon(true);
    }

    //批量提取tile
    public IEnumerator EdibleTriangle(List<TileBehavior> tileBehaviors)
    {
        for (int i = 0; i < tileBehaviors.Count; i++)
        {
            EdibleScholar(tileBehaviors[i]);
            yield return new WaitForSeconds(0.05f);
        }
    }

    //移动结束
    public void SelfSew()
    {
        //消除
        for (int i = 0; i < LieThawFire.Count; i++)
        {
            if (i + 1 < LieThawFire.Count && i + 2 < LieThawFire.Count)
            {
                if (LieThawFire[i + 1].ActionPrefabName() != "")
                {
                    if (LieThawFire[i].ActionTileBehavior().TileData == LieThawFire[i + 1].ActionTileBehavior().TileData)
                    {
                        if (LieThawFire[i + 2].ActionPrefabName() != "")
                        {
                            if (LieThawFire[i + 1].ActionTileBehavior().TileData == LieThawFire[i + 2].ActionTileBehavior().TileData)
                            {

                                //消除动画
                                LieThawFire[i].ActionTileBehavior().SetAnimation("Tile_C_end");
                                LieThawFire[i].CloseTile();
                                //初始化数据
                                LieThawFire[i].InitData();
                                //消除动画
                                ObtainShakeV3 = screenpointToUIPoint(LieThawFire[i + 1].gameObject.transform) ;
                                //ObtainShake = screenpointToUIPoint() ;
                                LieThawFire[i + 1].ActionTileBehavior().SetAnimation("Tile_C_end");
                                LieThawFire[i + 1].CloseTile();
                                //初始化数据
                                LieThawFire[i + 1].InitData();
                                //消除动画
                                LieThawFire[i + 2].ActionTileBehavior().SetAnimation("Tile_C_end");
                                LieThawFire[i + 2].CloseTile();
                                //初始化数据
                                LieThawFire[i + 2].InitData();
                                RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_Match);
                                RoadTenuous.GetInstance().UsuallyStuff();
                                //判断后面还有没有 如果有就往前移动
                                if (i + 3 < LieThawFire.Count)
                                {
                                    for (int j = i + 3; j < LieThawFire.Count; j++)
                                    {
                                        if (LieThawFire[j].ActionValue())
                                        {
                                            LieThawFire[j].ActionTileBehavior().SubmitMove(LieThawFire[j - 3].transform.position, LevelScaler.SlotSize, SelfSew);
                                            LieThawFire[j - 3].SetPosition(LieThawFire[j].ActionPrefabName(), LieThawFire[j].ActionTileBehavior());
                                            LieThawFire[j].InitData();
                                        }
                                    }
                                }
                                if (!RoadTenuous.GetInstance().OfIdeal)
                                {
                                    ElliotDemise();
                                }
                                else
                                {
                                    RoadLoder.instance.OatWing(ObtainShakeV3, 1);
                                    if (DripFire.Count > 0)
                                    {
                                        for (int z = 0; z < DripFire.Count; z++)
                                        {
                                            DripFire[z].ResetSubmitState();
                                            DripFire[z].SetBlockState(false);
                                            DripFire[z].SetState(true, false);
                                            DripFire[z].SetAnimation("Tile_idle");
                                        }
                                    }
                                    else
                                    {
                                        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_Win);
                                        PlayerPrefs.SetInt(CConfig.FinishGuideLevel, 1);
                                        RoadTenuous.GetInstance().OfIdeal = false;
                                        UIManager.GetInstance().CloseOrReturnUIForms(nameof(RoadLoder));
                                        UIManager.GetInstance().ShowUIForms(nameof(ElliotLoder));
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
        if (LieThawFire.Last().ActionValue() && IsFail)
        {
            IsFail = false;
            RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_Fail);
            if (RoadTenuous.GetInstance().OfTelescope)
            {
                RoadTenuous.GetInstance().ChallengeFail();
                //UIManager.GetInstance().ShowUIForms(nameof(TelescopeTerm));
            }
            else
            {
                //UIManager.GetInstance().CloseOrReturnUIForms(nameof(RoadLoder));
                UIManager.GetInstance().ShowUIForms(nameof(TermLoder));
            }
        }
        if (LieThawFire.Count - MobMidwayThaw().Count == 1)
        {
            StoveThawEra = true;
        }
        else
        {
            ThawEra.enabled = false;
            StoveThawEra = false;
            SewThawEra = false;
            Dy.SetActive(false);
        }
    }

    public Vector3 screenpointToUIPoint(Transform worldPoint)
    {
        Camera camera = Camera.main;
        Vector3 screenPoint = camera.ScreenToViewportPoint(worldPoint.position) + new Vector3(0, -0.3f,0);
        //screenPoint = screenPoint + worldPoint.position;

        return screenPoint;
    }

    public void ElliotDemise()
    {
        if (DripFire.Count == 0)
        {
            PearlVenice.SetActive(false);
            //完成关卡
            RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_Win);
            UIManager.GetInstance().CloseOrReturnUIForms(nameof(RoadLoder));
            UIManager.GetInstance().ShowUIForms(nameof(ElliotLoder));
            return;
        }

        if (!OfEatBleakTelescope)
        {
            // 如果场中存在的tile数量 <= 15开始自动收牌  开启自动收牌关闭连消提示 达到关卡限制
            if (DripFire.Count + MobMidwayThaw().Count <= NetInfoMgr.instance.GameData.Auto_Complete && RoadTenuous.GetInstance().OfPearl && PlayerPrefs.GetInt(CConfig.sv_CurLevel) >= NetInfoMgr.instance.GameData.Quickplay_Config)
            {
                if (!PearlVenice.activeSelf)
                {
                    PearlVenice.SetActive(true);
                }
                else
                {
                    PearlVenice.GetComponent<ParticleSystem>().Play();
                }
                PearlClient();
            }
            else
            {
                RoadLoder.instance.TheyRift();
            }
        }
        if (!(DripFire.Count + MobMidwayThaw().Count <= NetInfoMgr.instance.GameData.Auto_Complete && RoadTenuous.GetInstance().OfPearl && PlayerPrefs.GetInt(CConfig.sv_CurLevel) >= NetInfoMgr.instance.GameData.Quickplay_Config))
        {
            if (MexicanFeat <= 3)
            {
                AdequacyBorrow++;
                switch (AdequacyBorrow)
                {
                    case 0:
                        RoadLoder.instance.OatWing(ObtainShakeV3, 1);
                        break;
                    case 1:
                        RoadLoder.instance.OatWing(ObtainShakeV3, 3);
                        break;
                    case 2:
                        RoadLoder.instance.OatWing(ObtainShakeV3, 5);
                        break;
                    case 3:
                        RoadLoder.instance.OatWing(ObtainShakeV3, 7);
                        break;
                    case 4:
                        RoadLoder.instance.OatWing(ObtainShakeV3, 10);
                        break;
                    case 5:
                        RoadLoder.instance.OatWing(ObtainShakeV3, 15);
                        break;
                    default:
                        RoadLoder.instance.OatWing(ObtainShakeV3, 15);
                        break;
                }
                if (AdequacyBorrow > 0)
                {
                    RoadLoder.instance.AdequacyJob(AdequacyBorrow);
                }
            }
            else
            {
                AdequacyBorrow = 0;
                RoadLoder.instance.OatWing(ObtainShakeV3, 1);
            }
            MexicanFeat = 0;
        }
    }

    //给tile赋值
    private IEnumerator MobAcidicHumor()
    {
        // Reset objects
        List<TileBehavior> tileBehaviors = DripFire;
        tileBehaviors.Sort((x, y) => { return x.transform.position.y.CompareTo(y.transform.position.y); });
        //将tile尺寸改为0  并且设置成未激活状态
        foreach (TileBehavior tileBehavior in tileBehaviors)
        {
            tileBehavior.transform.localScale = Vector3.zero;
            tileBehavior.SetState(false, false);
        }

        for (int i = 0; i < tileBehaviors.Count; i++)
        {
            tileBehaviors[i].SetState(OfDripUndisturbed(tileBehaviors[i]));
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

        //加载动画完成，给tilelist排序，为自动收牌和魔法棒做准备
        DripFire.Sort((x, y) => { return x.transform.position.y.CompareTo(-y.transform.position.y); });
    }

    public IEnumerator DripFosterWaterfall(List<TileBehavior> tileBehaviors)
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
            tileBehaviors[i].SetState(OfDripUndisturbed(tileBehaviors[i]));
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
    }

    //更新tile状态
    public void DrenchSalmon(bool withAnimation = false)
    {
        foreach (TileBehavior tile in DripFire)
        {
            tile.SetState(OfDripUndisturbed(tile), withAnimation);
        }
    }

    //选中tile之后 在TileList中移除tile
    public void ObtainBounce(TileBehavior tile)
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
        DripFire.Remove(tile);
        Recede[tile.ElementPosition] = null;
    }

    //给tile赋值位置和状态
    public bool OfDripUndisturbed(ElementPosition tilePos)
    {
        if (tilePos.LayerId == 0)
            return true;
        var layerIdFromBottom = EatBleak.AmountOfLayers - tilePos.LayerId - 1;
        bool isEven = layerIdFromBottom % 2 == 0;

        for (int i = tilePos.LayerId - 1; i >= 0; i--)
        {
            var thislayerIdFromBottom = EatBleak.AmountOfLayers - i - 1;

            bool isLayerEven = thislayerIdFromBottom % 2 == 0;

            var Pedagogy= new ElementPosition(tilePos, i);

            if (isEven == isLayerEven)
            {
                // if there is something directly above object, it is not available

                if (Recede[Pedagogy].State)
                    return false;
            }
            else
            {
                var Kill= isLayerEven ? SailValueHoly : RobValueHoly;

                bool sizeIsBigger;
                if (isLayerEven)
                {
                    sizeIsBigger = OfRarerValueHandle;
                }
                else
                {
                    sizeIsBigger = !OfRarerValueHandle;
                }

                Pedagogy = new ElementPosition(sizeIsBigger ? Pedagogy + 1 : Pedagogy - 1, i);

                // Checking if there is something partly above the object. If there is - it is not available
                // Should check 4 times because every odd lever is bigger and shifted a little bit

                if (Pedagogy.X != -1 && Pedagogy.Y != -1 && Pedagogy.X != Kill.x && Pedagogy.Y != Kill.y && Recede[Pedagogy].State)
                    return false;

                if (sizeIsBigger)
                {
                    var leftNeighbourPos = Pedagogy.LeftNeighbourPos;
                    if (leftNeighbourPos.X != -1 && leftNeighbourPos.Y != Kill.y && Recede[leftNeighbourPos].State)
                        return false;

                    var topNeighbourPos = Pedagogy.UpNeighbourPos;
                    if (topNeighbourPos.X != Kill.x && topNeighbourPos.Y != -1 && Recede[topNeighbourPos].State)
                        return false;

                    var topLeftNeighbourPos = topNeighbourPos.LeftNeighbourPos;
                    if (topLeftNeighbourPos.X != -1 && topLeftNeighbourPos.Y != -1 && Recede[topLeftNeighbourPos].State)
                        return false;
                }
                else
                {
                    var rightNeighbourPos = Pedagogy.RightNeighbourPos;
                    if (rightNeighbourPos.X != Kill.x && rightNeighbourPos.Y != -1 && Recede[rightNeighbourPos].State)
                        return false;

                    var bottomNeighbourPos = Pedagogy.BottomNeighbourPos;

                    if (bottomNeighbourPos.X != -1 && bottomNeighbourPos.Y != Kill.y && Recede[bottomNeighbourPos].State)
                        return false;

                    var bottomRightNeighbourPos = bottomNeighbourPos.RightNeighbourPos;
                    if (bottomRightNeighbourPos.X != Kill.x && bottomRightNeighbourPos.Y != Kill.y && Recede[bottomRightNeighbourPos].State)
                        return false;
                }
            }
        }

        return true;
    }

    public List<SlotBehavior> MobLieDoll()
    {
        return LieThawFire;
    }
}

