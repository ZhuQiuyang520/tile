using DG.Tweening;
using LitJson;
using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Watermelon;

public class RaftMeeting : MonoBehaviour
{
    public static RaftMeeting instance;

    [SerializeField] LevelDatabase OunceFlagpole;
    public static LevelDatabase Flagpole=> instance.OunceFlagpole;
    [SerializeField] LevelData UntieGrantWeed;
    [SerializeField] PreloadedLevelData UntieLessonGrantWeed;
    [SerializeField] LevelScaler OunceStress;
    [SerializeField] GameData Site;
    [SerializeField] Color PaveConsistSolar;
[UnityEngine.Serialization.FormerlySerializedAs("RemindEffect")]
[UnityEngine.Serialization.FormerlySerializedAs("ForgetVenice")]    public GameObject RavineLovely;
[UnityEngine.Serialization.FormerlySerializedAs("VolunEffect")]    [UnityEngine.Serialization.FormerlySerializedAs("PearlVenice")]public GameObject CloudLovely;
[UnityEngine.Serialization.FormerlySerializedAs("SlotAni")]
[UnityEngine.Serialization.FormerlySerializedAs("ThawEra")]    public Animator LoadJoy;
[UnityEngine.Serialization.FormerlySerializedAs("mb")]    [UnityEngine.Serialization.FormerlySerializedAs("Dy")]public GameObject By;
    private bool OrganLoadJoy;
    private bool SeaLoadJoy;
    private float LoadJoyTern;
[UnityEngine.Serialization.FormerlySerializedAs("LevelObj")]
[UnityEngine.Serialization.FormerlySerializedAs("BleakLop")]    public GameObject GrantTar;
[UnityEngine.Serialization.FormerlySerializedAs("LevelParentObj")]    [UnityEngine.Serialization.FormerlySerializedAs("BleakMaidenLop")]public GameObject GrantBioticTar;
[UnityEngine.Serialization.FormerlySerializedAs("AddSlotObj")]
[UnityEngine.Serialization.FormerlySerializedAs("LidThawLop")]    public GameObject SodLoadTar;
[UnityEngine.Serialization.FormerlySerializedAs("SlotPrefab")]    [UnityEngine.Serialization.FormerlySerializedAs("ThawPotato")]public SlotBehavior LoadIgnite;
[UnityEngine.Serialization.FormerlySerializedAs("SlotList")]
[UnityEngine.Serialization.FormerlySerializedAs("ThawFire")]    public List<SlotBehavior> LoadLife;
[UnityEngine.Serialization.FormerlySerializedAs("ReviveSlotList")]    [UnityEngine.Serialization.FormerlySerializedAs("UpwindThawFire")]public List<GameObject> DivineLoadLife;

    private List<SlotBehavior> TonLoadLife= new List<SlotBehavior>();
[UnityEngine.Serialization.FormerlySerializedAs("CurLevel")]
[UnityEngine.Serialization.FormerlySerializedAs("EatBleak")]    public static LevelData BayGrant;
    public static GameData Weed=> instance.Site;

    private Vector2Int Ploy;
    public static Vector2Int TalkGrassCone=> new Vector2Int(BayGrant.GetLayer(BayGrant.AmountOfLayers - 1).GetRow(0).AmountOfCells, BayGrant.GetLayer(BayGrant.AmountOfLayers - 1).AmountOfRows);
    public static Vector2Int RagGrassCone=> new Vector2Int(BayGrant.GetLayer(BayGrant.AmountOfLayers - 2).GetRow(0).AmountOfCells, BayGrant.GetLayer(BayGrant.AmountOfLayers - 2).AmountOfRows);

    public static bool MeSmokeGrassCopper=> TalkGrassCone.x > RagGrassCone.x;
    private List<TileBehavior> BoatLife;
    private LayersMatrix Harbor;
    private List<TileSpawnData> ColorMaser;

    private float RavineTern;
[UnityEngine.Serialization.FormerlySerializedAs("IsRemind")]    [UnityEngine.Serialization.FormerlySerializedAs("OfForget")]public bool MeRavine;
    private List<TileBehavior> RavineMaser= new List<TileBehavior>();

    private int LuncheonButton;
    private int EagerlyWold;

    private bool MeBayGrantOutrigger;

    private int DivineHolm= 0;
    private float DivineResume= 0;

    //private Transform ObtainShake;

    private Vector3 BalticThingV3;
[UnityEngine.Serialization.FormerlySerializedAs("IsFail")]
    public bool OfBold;

    private string AngryLoder;
    private string[] AngryLoderCage;

    private int CharacterSpite= 0;
    private int PlaceNever;
    private List<TileSpawnData> CharacterWillSalt;
[UnityEngine.Serialization.FormerlySerializedAs("IsAppleSprite")]
    //private List<string> ReviveList1 = new List<string>();
    //private List<string> ReviveList2 = new List<string>();
    //private List<string> ReviveList3 = new List<string>();

    public Sprite[] OfApaceLocate;
[UnityEngine.Serialization.FormerlySerializedAs("IsAppleIcon")]    public Image[] OfApacePost;

    private void Awake()
    {
        instance = this;
        //初始化level基础数据
        OunceFlagpole.Initialise();

        //if (CommonUtil.IsApple())
        //{
        //    for (int i = 0; i < IsAppleSprite.Length; i++)
        //    {
        //        IsAppleIcon[i].sprite = IsAppleSprite[i];
        //    }
        //}
    }

    private void Start()
    {
        RavineTern = 0;
        MeRavine = false;
        for (int i = 0; i < LoadLife.Count; i++)
        {
            LoadLife[i].SettingOrder(i);
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
    public void SkinGrant(int index)
    {
        
        for (int i = 0; i < LoadLife.Count; i++)
        {
            if (LoadLife[i].ActionValue())
            {
                LoadLife[i].InitData();
            }
        }
        AngryLoder = NetInfoMgr.instance.GameData.Combo_Cash;
        AngryLoderCage = AngryLoder.Split(';');
        OfBold = true;
        DivineHolm = 0;
        DivineResume = 0;
        MeBayGrantOutrigger = RaftNonself.GetInstance().MeOutrigger;

        if (!MeBayGrantOutrigger)
        {
            if (index >= NetInfoMgr.instance.LevelList.level.Count)
            {
                index = index % NetInfoMgr.instance.LevelList.level.Count + 29;
            }
            foreach (var item in NetInfoMgr.instance.LevelList.level)
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
            PlaceNever = 0;
            CharacterSpite = NetInfoMgr.instance.GameData.challenge_group;
        }
        if (PlayerPrefs.GetInt(CConfig.OnceEnterChallenge) == 1 && MeBayGrantOutrigger)
        {
            PlayerPrefs.SetInt(CConfig.OnceEnterChallenge, 0);
            RaftNonself.GetInstance().EmpireStilt = false;
            UIManager.GetInstance().ShowUIForms(nameof(StyleGlueNeedy));
        }
        MeRavine = false;
        LuncheonButton = -1;
        EagerlyWold = 0;
        LoadJoy.enabled = false;
        By.SetActive(false);
        OrganLoadJoy = false;
        SeaLoadJoy = false;
        LoadJoyTern = 0;
        if (LoadIgnite.gameObject.activeSelf)
        {
            SodLoadTar.SetActive(true);
            LoadIgnite.gameObject.SetActive(false);
            TonLoadLife.Remove(LoadIgnite);
        }
        TonLoadLife = LoadLife;
        WeSkinGrant();

        BoatLife = new List<TileBehavior>();

        //加载level
        if (CommonUtil.IsApple())
        {
            index += NetInfoMgr.instance.LevelList.level.Count;
        }

        BayGrant = OunceFlagpole.GetLevel(index);
        ColorMaser = new List<TileSpawnData>();
        CharacterWillSalt = new List<TileSpawnData>();
        OunceStress.Recalculate();
        GrantBioticTar.transform.position = OunceStress.LevelFieldCenter;
        TileData[] availableObjects = OunceFlagpole.AvailableForLevel(BayGrant);
        TileData[] initialTilesData = BurgessBiologyMaser(availableObjects);

        Harbor = new LayersMatrix(BayGrant, GrantBioticTar);
        for (int i = 0; i < BayGrant.AmountOfLayers; i++)
        {
            Harbor.Layers[i].LayerObject.transform.position -= new Vector3(0,0.06f * (LevelScaler.TileSize.y/Site.TileSize.y),0) * i;
            Layer layer = BayGrant.GetLayer(i);
            Ploy = (BayGrant.AmountOfLayers - i - 1) % 2 == 0 ? TalkGrassCone : RagGrassCone;
            for (int y = Ploy.y - 1; y >= 0; y--)
            {
                for (int x = 0; x < Ploy.x; x++)
                {
                    CellData cellData = layer[y].GetCell(x);
                    if (cellData.IsFilled)
                    {
                        TileSpawnData tileSpawnData = new TileSpawnData();
                        tileSpawnData.AbreastEvenness = new ElementPosition(x, y, i);
                        tileSpawnData.MuteWeed = cellData;
                        tileSpawnData.GrassAbove = i;
                        tileSpawnData.Value = layer;
                        tileSpawnData.GrassCone = Ploy;
                        ColorMaser.Add(tileSpawnData);
                        CharacterWillSalt.Add(tileSpawnData);
                    }
                }
            }
        }
        if (RaftNonself.GetInstance().MeOutrigger && PlayerPrefs.GetInt(CConfig.NowDayChallenAward) != 0)
        {
            for (int i = 0; i < initialTilesData.Length; i++)
            {
                //随机选择一个预制体样式
                TileSpawnData firstTileSpawnData = CharacterWillSalt.OrderBy(x => Random.value).OrderBy(x => x.GrassAbove).FirstOrDefault();
                CharacterWillSalt.Remove(firstTileSpawnData);

                if (PlaceNever != firstTileSpawnData.GrassAbove)
                {
                    PlaceNever = firstTileSpawnData.GrassAbove;
                    CharacterSpite = NetInfoMgr.instance.GameData.challenge_group;
                }
                else
                {
                    if (CharacterSpite == 0)
                    {
                        continue;
                    }
                }
                if (CharacterWillSalt.FindAll(s => s.GrassAbove == PlaceNever).Count < NetInfoMgr.instance.GameData.challenge_amount || PlaceNever >= NetInfoMgr.instance.GameData.challenge_limit)
                {
                    continue;
                }
                ColorMaser.Remove(firstTileSpawnData);
                
                TileBehavior firstElementBehavior = DepotBoat(initialTilesData[i], firstTileSpawnData.AbreastEvenness);
                float totalWeight = 0;
                foreach (TileSpawnData emptyTile in CharacterWillSalt)
                {
                    emptyTile.PublicationAccess(firstTileSpawnData.GrassAbove);
                    totalWeight += emptyTile.DifferAccess;
                }
                for (int a = 0; a < 2; a++)
                {
                    TileSpawnData selectedTileData = null;
                    selectedTileData = CharacterWillSalt.FindAll(s => s.GrassAbove == PlaceNever)[Random.Range(0, CharacterWillSalt.FindAll(s => s.GrassAbove == PlaceNever).Count)];
                    if (selectedTileData != null)
                    {
                        CharacterWillSalt.Remove(selectedTileData);
                        ColorMaser.Remove(selectedTileData);
                        totalWeight -= selectedTileData.DifferAccess;
                        TileBehavior additionalElementBehavior = DepotBoat(initialTilesData[i], selectedTileData.AbreastEvenness);
                    }
                }
                initialTilesData[i] = null;
                if (CharacterSpite > 0)
                {
                    CharacterSpite--;
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
            TileSpawnData firstTileSpawnData = ColorMaser.OrderBy(x => Random.value).OrderBy(x => x.AbreastEvenness.Y).FirstOrDefault();
            ColorMaser.Remove(firstTileSpawnData);
            TileBehavior firstElementBehavior = DepotBoat(initialTilesData[i], firstTileSpawnData.AbreastEvenness);
            float totalWeight = 0;
            foreach (TileSpawnData emptyTile in ColorMaser)
            {
                emptyTile.PublicationAccess(firstTileSpawnData.AbreastEvenness.LayerId);
                totalWeight += emptyTile.DifferAccess;
            }

            for (int a = 0; a < 2; a++)
            {
                float randomValue = Random.Range(0, totalWeight);
                float currentWeight = 0;
                TileSpawnData selectedTileData = null;

                foreach (TileSpawnData emptyTile in ColorMaser)
                {
                    currentWeight += emptyTile.DifferAccess;
                    if (currentWeight >= randomValue)
                    {
                        selectedTileData = emptyTile;
                        break;
                    }
                }

                if (selectedTileData != null)
                {
                    ColorMaser.Remove(selectedTileData);
                    totalWeight -= selectedTileData.DifferAccess;

                    TileBehavior additionalElementBehavior = DepotBoat(initialTilesData[i], selectedTileData.AbreastEvenness);
                }
            }
        }

        if (!MeBayGrantOutrigger)
        {
            RaftNonself.GetInstance().EmpireStilt = false;
            if (!CommonUtil.IsApple())
            {
                RaftNeedy.instance.OfFecundSoda(true);
            }
            //执行动画 挑战关卡不执行加载动画
            StartCoroutine(YouInlandMaser());
           
        }
        else
        {
            foreach (var item in BoatLife)
            {
                item.SetState(false, false);
            }
            for (int i = 0; i < BoatLife.Count; i++)
            {
                BoatLife[i].SetState(MeBoatAdolescence(BoatLife[i]));
            }
        }
        
    }

    private List<TileBehavior> KnightMaser;
    private List<TileBehavior> CrushMaser;
    public void GapUntie()
    {
        TonLoadLife = LoadLife;
        BoatLife = new List<TileBehavior>();
        SkinUntieGrant(UntieGrantWeed, UntieLessonGrantWeed, () => {
            KnightMaser = new List<TileBehavior>();
            KnightMaser.Add(YouBoat(new ElementPosition(0, 0, 1)));
            KnightMaser.Add(YouBoat(new ElementPosition(1, 0, 1)));
            KnightMaser.Add(YouBoat(new ElementPosition(2, 0, 1)));
            
            foreach (var cheese in KnightMaser)
            {
                cheese.SetBlockState(true);
                cheese.SetColor(PaveConsistSolar, true);
            }

            // Get apple tiles
            CrushMaser = new List<TileBehavior>();
            CrushMaser.Add(YouBoat(new ElementPosition(0, 1, 1)));
            CrushMaser.Add(YouBoat(new ElementPosition(1, 1, 1)));
            CrushMaser.Add(YouBoat(new ElementPosition(2, 1, 1)));

            foreach (var apple in CrushMaser)
            {
                apple.SetBlockState(false);
                apple.SetAnimation("Tile_idle");
            }
        });
    }

    private void SkinUntieGrant(LevelData levelData, PreloadedLevelData preloadedLevelData,SimpleCallback onLevelLoaded = null)
    {
        BayGrant = levelData;
        GrantTar.SetActive(true);
        OunceStress.Recalculate();
        GrantBioticTar.transform.position = OunceStress.LevelFieldCenter;

        Harbor = new LayersMatrix(BayGrant, GrantBioticTar);
        
        DepotFlaming(preloadedLevelData);

        onLevelLoaded();
    }

    public void DepotFlaming(PreloadedLevelData preloadedLevelData)
    {
        preloadedLevelData.Initialise();
        PreloadedLevelData.Tile[] preloadTiles = preloadedLevelData.Tiles;
        foreach (PreloadedLevelData.Tile tile in preloadTiles)
        {
            TileData tileData = tile.TileData;
            ElementPosition elementPosition = tile.ElementPosition;
            TileBehavior tileBehavior = tileData.Pool.YouMarginTravel().GetComponent<TileBehavior>();
            tileBehavior.Initialise(tileData, elementPosition);
            tileBehavior.transform.SetParent(Harbor[elementPosition.LayerId].LayerObject.transform);
            tileBehavior.transform.localPosition = LevelScaler.GetPosition(tile.ElementPosition);
            tileBehavior.transform.localScale = Vector3.one;
            tileBehavior.SetScale(LevelScaler.TileSize);

            Harbor[tile.ElementPosition] = tileBehavior;

            // Figuring out is object is Active
            tileBehavior.SetState(MeBoatAdolescence(tileBehavior), false);


            BoatLife.Add(tileBehavior);
        }
    }
    public TileBehavior YouBoat(ElementPosition elementPosition)
    {
        if (MeBoatOliver(elementPosition))
        {
            return Harbor[elementPosition].Tile;
        }

        return null;
    }
    public bool MeBoatOliver(ElementPosition elementPosition)
    {
        int layerId = elementPosition.LayerId;
        int width = Harbor[layerId].Width;
        int height = Harbor[layerId].Height;

        if (elementPosition.X >= 0 && elementPosition.X < width && elementPosition.Y >= 0 && elementPosition.Y < height)
        {
            return Harbor[elementPosition].State;
        }

        return false;
    }

    //给除了第一层的其他层级赋值
    private TileData[] BurgessBiologyMaser(TileData[] availableTilesData)
    {
        // Helps keep track of the amount of already included tiles
        Dictionary<TileData, int> objectsInLevelAmount = new Dictionary<TileData, int>();

        var initialTilesData = new List<TileData>();

        int tilesDataLeft = BayGrant.GetAmountOfFilledCells();

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
        public ElementPosition AbreastEvenness;
        public CellData MuteWeed;

        public int GrassAbove;
        public Layer Value;
        public Vector2Int GrassCone;

        public float DifferAccess;

        public void PublicationAccess(int baseLayerIndex)
        {
            int layerDiff = GrassAbove - baseLayerIndex;

            DifferAccess = Mathf.Clamp(3 - layerDiff, 0, int.MaxValue);
        }
    }

    private TileBehavior DepotBoat(TileData tileData, ElementPosition elementPosition)
    {
        TileBehavior tile = tileData.Pool.YouMarginTravel().GetComponent<TileBehavior>();
        tile.Initialise(tileData, elementPosition);
        tile.transform.SetParent(Harbor.Layers[elementPosition.LayerId].LayerObject.transform);
        tile.transform.localPosition = LevelScaler.GetPosition(tile.ElementPosition);
        tile.transform.localScale = Vector3.one;
        tile.SetScale(LevelScaler.TileSize);
        
        Harbor[tile.ElementPosition] = tile;

        // Figuring out is object is Active
        tile.SetState(MeBoatAdolescence(tile), false);

        // Add tile to global tiles list
        BoatLife.Add(tile);

        return tile;
    }

    //增加槽位
    public void SodLoad()
    {
        PostEventScript.GetInstance().SendEvent("1009", "1");
        RaftNonself.GetInstance().EmpireStilt = false;
        ADManager.Instance.playRewardVideo((success) =>
        {
            RaftNonself.GetInstance().EmpireStilt = true;
            if (success)
            {
                SodLoadTar.SetActive(false);
                PostEventScript.GetInstance().SendEvent("9007", "7");

                LoadIgnite.gameObject.SetActive(true);
                LoadIgnite.SettingOrder(7);
                TonLoadLife.Add(LoadIgnite);
                //for (int i = 0; i < LieThawFire.Count; i++)
                //{
                //    if (LieThawFire[i].ActionValue())
                //    {
                //        LieThawFire[i].ActionTileBehavior().transform.position = LieThawFire[i].transform.position;
                //    }
                //}

                LoadJoy.enabled = false;
                By.SetActive(false);
                OrganLoadJoy = false;
                SeaLoadJoy = false;
                LoadJoyTern = 0;
            }
            
        }, "110");
        
    }

    //刷新tile
    public void SaguaroBoat()
    {
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_Shuffle);
        //关闭自动提示
        if (RavineMaser.Count > 0)
        {
            for (int i = 0; i < RavineMaser.Count; i++)
            {
                RavineMaser[i].CloseAni();
            }
            RavineMaser.Clear();
            MeRavine = true;
            RavineTern = 0;
        }
        List<TileBehavior> ActiveTiles = BoatLife;
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
                        allowedToShuffleTiles[i].transform.SetParent(Harbor.Layers[shuffleElements[i].LayerId].LayerObject.transform);
                        allowedToShuffleTiles[i].transform.localScale = Vector3.zero;
                        allowedToShuffleTiles[i].transform.localPosition = LevelScaler.GetPosition(shuffleElements[i]);
                        allowedToShuffleTiles[i].SetPosition(shuffleElements[i]);
                    }

                    foreach (LayerGrid layer in Harbor.Layers)
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

                    foreach (TileBehavior tile in BoatLife)
                    {
                        ElementPosition elementPosition = tile.ElementPosition;

                        Harbor.Layers[elementPosition.LayerId][elementPosition].LinkTile(tile);
                    }

                    LatterHeroic(true);
                    SaguaroIngenuity(ActiveTiles, 0.5f, 0.05f, 0.4f);
                }
            }
        }
        
    }

    //点击刷新tile
    private void SaguaroIngenuity(List<TileBehavior> tiles ,float scaleDuration , float minDelay , float MaxDelay)
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
        BoatFamilyIngenuity(tiles);
        //StartCoroutine(DripFosterWaterfall(tiles));
    }
    //撤回tile
    public void CostFailRBoat()
    {
        TileBehavior PresetTile = null;
        SlotBehavior PresetLost = null;
        //从后往前撤回
        for (int i = TonLoadLife.Count - 1; i >= 0; i--)
        {
            if (TonLoadLife[i].ActionValue())
            {
                PresetTile = TonLoadLife[i].ActionTileBehavior();
                PresetLost = TonLoadLife[i];
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

            PresetTile.SubmitMove(returnPosition, new Vector3(1.03f, 1.03f, 1f) * LevelScaler.TileSize, () =>
            {
                PresetTile.SetPosition(PresetTile.ElementPosition);
                PresetTile.ResetSubmitState();
                BoatLife.Add(PresetTile);
                Harbor[PresetTile.ElementPosition] = PresetTile;
                PresetLost.InitData();
                LatterHeroic(true);
            });
        }

        //关闭自动提示
        if (RavineMaser.Count > 0)
        {
            for (int i = 0; i < RavineMaser.Count; i++)
            {
                RavineMaser[i].CloseAni();
            }
            RavineMaser.Clear();
            MeRavine = true;
            RavineTern = 0;
        }
        LoadJoy.enabled = false;
        OrganLoadJoy = false;
        By.SetActive(false);
        SeaLoadJoy = false;
        LoadJoyTern = 0;
    }

    //复活存牌区前三个tile进入复活区域
    public void DivineLoad()
    {
        OfBold = true;
        for (int i = 0; i < 3; i++)
        {
            DivineHolm++;
            TileBehavior PresetTile = null;
            SlotBehavior PresetLost = null;

            PresetTile = TonLoadLife[i].ActionTileBehavior();
            PresetLost = TonLoadLife[i];
            Vector3 InitPosition = DivineLoadLife[i].transform.position;
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
            InitPosition.y += DivineResume;
            InitPosition.z -= DivineResume;
            PresetTile.SubmitMove(InitPosition, LevelScaler.SlotSize);
            PresetTile.SetSortingOrder(DivineHolm);
            PresetTile.ResetSubmitState();
            BoatLife.Add(PresetTile);
            //layers[PresetTile.ElementPosition] = PresetTile;
            PresetLost.InitData();
            PresetTile.SetState(true,false);
        }
        DivineResume += 0.05f;
        DivineBasket();
    }

    public void DivineBasket()
    {
        for (int j = 3; j < TonLoadLife.Count; j++)
        {
            TonLoadLife[j].ActionTileBehavior().SubmitMove(TonLoadLife[j - 3].transform.position, LevelScaler.SlotSize);
            TonLoadLife[j - 3].SetPosition(TonLoadLife[j].ActionPrefabName(), TonLoadLife[j].ActionTileBehavior());
            TonLoadLife[j].InitData();
        }
    }

    //魔法棒
    public void RavineBoat(bool IsVolun)
    {
        if (!IsVolun)
        {
            if (!RavineLovely.activeSelf)
            {
                RavineLovely.SetActive(true);
            }
            else
            {
                RavineLovely.GetComponent<ParticleSystem>().Play();
            }
            RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_Wand);
        }
        int requiredElementsCount = 3;
        TileData tileData = null;
        List<SlotBehavior> slotTiles = YouGovernLoad();
        if (slotTiles.IsNullOrEmpty())
        {
            List<TileBehavior> ActiveTiles = YouGovernMaser();
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
            if ((TonLoadLife.Count - slotTiles.Count) < requiredElementsCount)
            {
                return;
            }
            List<TileBehavior> targetTiles = new List<TileBehavior>(YouMaserMyNext(tileData, requiredElementsCount));
            for (int i = 0; i < targetTiles.Count; i++)
            {
                TileBehavior targetTile = targetTiles[i];
                targetTile.MarkAsSubmitted();
                targetTile.SetState(true, false);
            }
            StartCoroutine(ImposeSplinter(targetTiles));
        }
        //关闭自动提示
        if (RavineMaser.Count > 0)
        {
            for (int i = 0; i < RavineMaser.Count; i++)
            {
                RavineMaser[i].CloseAni();
            }
            RavineMaser.Clear();
            MeRavine = true;
            RavineTern = 0;
        }

        LoadJoy.enabled = false;
        OrganLoadJoy = false;
        By.SetActive(false);
        SeaLoadJoy = false;
        LoadJoyTern = 0;
    }

    //自动收牌  每次手牌停顿0.5f
    public void CloudTypify()
    {
        if (BoatLife.Count > 0)
        {
            Sequence seq = DOTween.Sequence();
            seq.AppendCallback(() =>
            {
                RavineBoat(true);
                seq.Kill();
            })
            .SetDelay(0.1f)
            .SetLoops(0);
        }
    }

    //自动提示
    public void CloudRavine()
    {
        TileData tileData = null;
        List<SlotBehavior> slotTiles = YouGovernLoad();
        List<TileBehavior> ActiveTiles = YouPatriotMaser();
        
        for (int i = 0; i < ActiveTiles.Count; i++)
        {
            if (ActiveTiles.FindAll(s => s.TileData == ActiveTiles[i].TileData).Count >= 3)
            {
                tileData = ActiveTiles[i].TileData;
                break;
            }
        }

        if (tileData != null && TonLoadLife.Count - slotTiles.Count >= 3)
        {
            for (int i = 0; i < 3; i++)
            {
                TileBehavior tile = ActiveTiles.Find(s => s.TileData == tileData);
                ActiveTiles.Remove(tile);
                RavineMaser.Add(tile);
            }
        }
    }

    //获取还未递交的tile
    public List<TileBehavior> YouGovernMaser()
    {
        List<TileBehavior> tempTiles = new List<TileBehavior>();
        List<TileBehavior> activeTiles = BoatLife;

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
    public List<TileBehavior> YouPatriotMaser()
    {
        List<TileBehavior> tempTiles = new List<TileBehavior>();
        List<TileBehavior> activeTiles = BoatLife;

        for (int i = 0; i < activeTiles.Count; i++)
        {
            if (activeTiles[i].IsClickable)
            {
                tempTiles.Add(activeTiles[i]);
            }
        }

        return tempTiles;
    }
    public List<TileBehavior> YouMaserMyNext(TileData tileData , int amout = int.MaxValue)
    {
        List<TileBehavior> tempTiles = new List<TileBehavior>();
        List<TileBehavior> activeTiles = BoatLife;
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
    public List<SlotBehavior> YouGovernLoad()
    {
        List<SlotBehavior> ActiveSlot = new List<SlotBehavior>();
        foreach (SlotBehavior item in TonLoadLife)
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
    public void WeSkinGrant()
    {
        if (BoatLife != null)
        {
            for (int i = 0; i < TonLoadLife.Count; i++)
            {
                TonLoadLife[i].InitData();
            }
            for (int i = 0; i < BoatLife.Count; i++)
            {
                BoatLife[i].Clear();
            }
            Harbor.Clear();
        }
    }

    //点击
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit) && RaftNonself.GetInstance().EmpireStilt)
            {
                IClickableObject clickableObject = hit.transform.GetComponent<IClickableObject>();
                if (clickableObject != null)
                {
                    for (int i = 0; i < RavineMaser.Count; i++)
                    {
                        RavineMaser[i].CloseAni();
                    }
                    RavineMaser.Clear();
                    MeRavine = true;
                    RavineTern = 0;
                    clickableObject.OnObjectClicked();
                }
            }
        }
        if (MeRavine && !RaftNonself.GetInstance().MeUntie)
        {
            RavineTern += Time.deltaTime;
            if (RavineTern > 20)
            {
                CloudRavine();
                if (RavineMaser.Count > 0)
                {
                    for (int i = 0; i < RavineMaser.Count; i++)
                    {
                        RavineMaser[i].SetAnimation("Tile_idle");
                    }
                    MeRavine = false;
                }
                RavineTern = 0;
            }
        }

        if (OrganLoadJoy)
        {
            LoadJoyTern += Time.deltaTime;
            if (LoadJoyTern > 5)
            {
                LoadJoy.enabled = true;
                LoadJoy.Play("Level_warn");
                OrganLoadJoy = false;
            }
        }
    }

    //提取tile，移动，重置位置，重置状态
    public void ImposeAbreast(TileBehavior tileBehavior)
    {
        //赋值
        for (int i = 0; i < TonLoadLife.Count; i++)
        {
            if (!TonLoadLife[i].ActionValue())
            {
                tileBehavior.SubmitMove(TonLoadLife[i].transform.position, LevelScaler.SlotSize, EmitSea);
                TonLoadLife[i].SetPosition(tileBehavior.TileData.Prefab.name, tileBehavior);
                break;
            }
            else
            {
                //先插入到list中 
                //判断当前的tile是否和选中的一样  如果一样将当前的tile插入到后面
                //如果后面还有值，则将后面的值往后移动
                if (TonLoadLife[i].ActionTileBehavior().TileData == tileBehavior.TileData)
                {
                    for (int j = TonLoadLife.Count - 1; j > i; j--)
                    {
                        if (TonLoadLife[j].ActionValue())
                        {
                            TonLoadLife[j].ActionTileBehavior().SubmitMove(TonLoadLife[j + 1].transform.position, LevelScaler.SlotSize, EmitSea);
                            TonLoadLife[j + 1].SetPosition(TonLoadLife[j].GetComponent<SlotBehavior>().ActionPrefabName(), TonLoadLife[j].ActionTileBehavior());
                        }
                    }

                    tileBehavior.SubmitMove(TonLoadLife[i+1].transform.position, LevelScaler.SlotSize, EmitSea);
                    TonLoadLife[i+1].SetPosition(tileBehavior.TileData.Prefab.name, tileBehavior);
                    break;
                }
            } 
        }
        EagerlyWold++;
        tileBehavior.MarkAsSubmitted();
        BalticTravel(tileBehavior);
        LatterHeroic(true);
    }

    //批量提取tile
    public IEnumerator ImposeSplinter(List<TileBehavior> tileBehaviors)
    {
        for (int i = 0; i < tileBehaviors.Count; i++)
        {
            ImposeAbreast(tileBehaviors[i]);
            yield return new WaitForSeconds(0.05f);
        }
    }

    //移动结束
    public void EmitSea()
    {
        //消除
        for (int i = 0; i < TonLoadLife.Count; i++)
        {
            if (i + 2 < TonLoadLife.Count)
            {
                if (TonLoadLife[i + 1].ActionPrefabName() != "")
                {
                    if (TonLoadLife[i].ActionTileBehavior().TileData == TonLoadLife[i + 1].ActionTileBehavior().TileData)
                    {
                        if (TonLoadLife[i + 2].ActionPrefabName() != "")
                        {
                            if (TonLoadLife[i+1].ActionTileBehavior().TileData == TonLoadLife[i + 2].ActionTileBehavior().TileData)
                            {

                                //消除动画
                                TonLoadLife[i].ActionTileBehavior().SetAnimation("Tile_C_end");
                                TonLoadLife[i].CloseTile();
                                //初始化数据
                                TonLoadLife[i].InitData();
                                //消除动画
                                BalticThingV3 = NonethelessItUIHurry(TonLoadLife[i + 1].gameObject.transform) ;
                                //ObtainShake = screenpointToUIPoint() ;
                                TonLoadLife[i + 1].ActionTileBehavior().SetAnimation("Tile_C_end");
                                TonLoadLife[i + 1].CloseTile();
                                //初始化数据
                                TonLoadLife[i + 1].InitData();
                                //消除动画
                                TonLoadLife[i + 2].ActionTileBehavior().SetAnimation("Tile_C_end");
                                TonLoadLife[i + 2].CloseTile();
                                //初始化数据
                                TonLoadLife[i + 2].InitData();
                                RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_Match);
                                RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.HeavyImpact);
                                if (!CommonUtil.IsApple())
                                {
                                    RaftNeedy.instance.OregonAscent();
                                }
                                //判断后面还有没有 如果有就往前移动
                                if (i + 3 < TonLoadLife.Count)
                                {
                                    for (int j = i + 3; j < TonLoadLife.Count; j++)
                                    {
                                        if (TonLoadLife[j].ActionValue())
                                        {
                                            TonLoadLife[j].ActionTileBehavior().SubmitMove(TonLoadLife[j - 3].transform.position, LevelScaler.SlotSize, EmitSea);
                                            TonLoadLife[j - 3].SetPosition(TonLoadLife[j].ActionPrefabName(), TonLoadLife[j].ActionTileBehavior());
                                            TonLoadLife[j].InitData();
                                        }
                                    }
                                }
                                if (!RaftNonself.GetInstance().MeUntie)
                                {
                                    CattleFrench();
                                }
                                else
                                {
                                    if (CommonUtil.IsApple())
                                    {
                                        WhipSixth.instance.AimBulb(BalticThingV3, 1);
                                    }
                                    else
                                    {
                                        RaftNeedy.instance.AimBulb(BalticThingV3, 1);
                                    }
                                    
                                    if (BoatLife.Count > 0)
                                    {
                                        for (int z = 0; z < BoatLife.Count; z++)
                                        {
                                            BoatLife[z].ResetSubmitState();
                                            BoatLife[z].SetBlockState(false);
                                            BoatLife[z].SetState(true, false);
                                            BoatLife[z].SetAnimation("Tile_idle");
                                        }
                                    }
                                    else
                                    {
                                        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_Win);
                                        PlayerPrefs.SetInt(CConfig.FinishGuideLevel, 1);
                                        RaftNonself.GetInstance().MeUntie = false;
                                        if (CommonUtil.IsApple())
                                        {
                                            UIManager.GetInstance().CloseOrReturnUIForms(nameof(WhipSixth));
                                        }
                                        else
                                        {
                                            UIManager.GetInstance().CloseOrReturnUIForms(nameof(RaftNeedy));
                                        }
                                        
                                        if (CommonUtil.IsApple())
                                        {
                                            UIManager.GetInstance().ShowUIForms(nameof(PenSixth));
                                        }
                                        else
                                        {
                                            UIManager.GetInstance().ShowUIForms(nameof(CattleNeedy));
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
        if (TonLoadLife.Last().ActionValue() && OfBold)
        {
            OfBold = false;
            RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_Fail);
            if (RaftNonself.GetInstance().MeOutrigger)
            {
                RaftNonself.GetInstance().CharacterBold();
            }
            else
            {
                if (CommonUtil.IsApple())
                {
                    UIManager.GetInstance().ShowUIForms(nameof(BoldSixth));
                }
                else
                {
                    UIManager.GetInstance().ShowUIForms(nameof(YolkNeedy));
                }
            }
        }
        if (TonLoadLife.Count - YouGovernLoad().Count == 1)
        {
            OrganLoadJoy = true;
        }
        else
        {
            LoadJoy.enabled = false;
            OrganLoadJoy = false;
            SeaLoadJoy = false;
            By.SetActive(false);
        }
    }

    public Vector3 NonethelessItUIHurry(Transform worldPoint)
    {
        Camera camera = Camera.main;
        Vector3 screenPoint = camera.ScreenToViewportPoint(worldPoint.position) + new Vector3(0, -0.3f,0);
        //screenPoint = screenPoint + worldPoint.position;

        return screenPoint;
    }

    public void CattleFrench()
    {
        if (BoatLife.Count == 0)
        {
            Sequence seq = DOTween.Sequence();
            seq.AppendCallback(() =>
            {
                CloudLovely.SetActive(false);
                //完成关卡
                RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_Win);
                
                if (CommonUtil.IsApple())
                {
                    UIManager.GetInstance().CloseOrReturnUIForms(nameof(WhipSixth));
                    UIManager.GetInstance().ShowUIForms(nameof(PenSixth));
                }
                else
                {
                    UIManager.GetInstance().CloseOrReturnUIForms(nameof(RaftNeedy));
                    UIManager.GetInstance().ShowUIForms(nameof(CattleNeedy));
                }
                return;
            })
            .SetDelay(1f)
            .SetLoops(0);
            
        }

        if (!MeBayGrantOutrigger)
        {
            // 如果场中存在的tile数量 <= 15开始自动收牌  开启自动收牌关闭连消提示 达到关卡限制
            if (!(BoatLife.Count + YouGovernLoad().Count <= NetInfoMgr.instance.GameData.Auto_Complete && RaftNonself.GetInstance().MeCloud && PlayerPrefs.GetInt(CConfig.sv_CurLevel) >= NetInfoMgr.instance.GameData.Quickplay_Config))
            {
                if (!CommonUtil.IsApple())
                {
                    if (RaftNeedy.instance.DomeShoe())
                    {
                        return;
                    }
                }
                
            }
            else
            {
                if (!CloudLovely.activeSelf)
                {
                    CloudLovely.SetActive(true);
                }
                else
                {
                    CloudLovely.GetComponent<ParticleSystem>().Play();
                }
                RaftNonself.GetInstance().EmpireStilt = false;
                if (!CommonUtil.IsApple())
                {
                    RaftNeedy.instance.OfFecundSoda(true);
                }
                CloudTypify();
            }
        }
        //if (!(DripFire.Count + MobMidwayThaw().Count <= NetInfoMgr.instance.GameData.Auto_Complete && RaftNonself.GetInstance().OfPearl && PlayerPrefs.GetInt(CConfig.sv_CurLevel) >= NetInfoMgr.instance.GameData.Quickplay_Config))
        //{
        if (EagerlyWold <= 3)
        {
            LuncheonButton++;
            switch (LuncheonButton)
            {
            case 0:
                if (CommonUtil.IsApple())
                {
                    WhipSixth.instance.AimBulb(BalticThingV3, double.Parse(AngryLoderCage[0].Split('|')[1]));
                }
                else
                {
                    RaftNeedy.instance.AimBulb(BalticThingV3, double.Parse(AngryLoderCage[0].Split('|')[1]));
                }
                break;
            case 1:
                if (CommonUtil.IsApple())
                {
                    WhipSixth.instance.AimBulb(BalticThingV3, double.Parse(AngryLoderCage[1].Split('|')[1]));
                }
                else
                {
                    RaftNeedy.instance.AimBulb(BalticThingV3, double.Parse(AngryLoderCage[1].Split('|')[1]));
                }
                break;
            case 2:
                if (CommonUtil.IsApple())
                {
                    WhipSixth.instance.AimBulb(BalticThingV3, double.Parse(AngryLoderCage[2].Split('|')[1]));
                }
                else
                {
                    RaftNeedy.instance.AimBulb(BalticThingV3, double.Parse(AngryLoderCage[2].Split('|')[1]));
                }
                    
                break;
            case 3:
                if (CommonUtil.IsApple())
                {
                    WhipSixth.instance.AimBulb(BalticThingV3, double.Parse(AngryLoderCage[3].Split('|')[1]));
                }
                else
                {
                    RaftNeedy.instance.AimBulb(BalticThingV3, double.Parse(AngryLoderCage[3].Split('|')[1]));
                }
                    
                break;
            case 4:
                if (CommonUtil.IsApple())
                {
                    WhipSixth.instance.AimBulb(BalticThingV3, double.Parse(AngryLoderCage[4].Split('|')[1]));
                }
                else
                {
                    RaftNeedy.instance.AimBulb(BalticThingV3, double.Parse(AngryLoderCage[4].Split('|')[1]));
                }
                break;
            case 5:
                if (CommonUtil.IsApple())
                {
                    WhipSixth.instance.AimBulb(BalticThingV3, double.Parse(AngryLoderCage[5].Split('|')[1]));
                }
                else
                {
                    RaftNeedy.instance.AimBulb(BalticThingV3, double.Parse(AngryLoderCage[5].Split('|')[1]));
                }
            break;
            default:
                if (CommonUtil.IsApple())
                {
                    WhipSixth.instance.AimBulb(BalticThingV3, double.Parse(AngryLoderCage[5].Split('|')[1]));
                }
                else
                {
                    RaftNeedy.instance.AimBulb(BalticThingV3, double.Parse(AngryLoderCage[5].Split('|')[1]));
                }
                    
                break;
            }
            if (LuncheonButton > 0)
            {
                if (!CommonUtil.IsApple())
                {
                    RaftNeedy.instance.LuncheonLug(LuncheonButton);
                }
            }
        }
        else
        {
            LuncheonButton = 0;
            if (CommonUtil.IsApple())
            {
                WhipSixth.instance.AimBulb(BalticThingV3, 1);
            }
            else
            {
                RaftNeedy.instance.AimBulb(BalticThingV3, 1);
            }
        }
        EagerlyWold = 0;
        //}
    }

    public void OfTriggerQuest()
    {
        if (!MeBayGrantOutrigger)
        {
            if (BoatLife.Count + YouGovernLoad().Count <= NetInfoMgr.instance.GameData.Auto_Complete && RaftNonself.GetInstance().MeCloud && PlayerPrefs.GetInt(CConfig.sv_CurLevel) >= NetInfoMgr.instance.GameData.Quickplay_Config)
            {
                CattleFrench();
            }
        }
    }

    //给tile赋值
    private IEnumerator YouInlandMaser()
    {
        //加载动画完成，给tilelist排序，为自动收牌和魔法棒做准备
        BoatLife.Sort((x, y) => { return x.transform.position.y.CompareTo(-y.transform.position.y); });
        
        // Reset objects
        List<TileBehavior> tileBehaviors = BoatLife;
        tileBehaviors.Sort((x, y) => { return x.transform.localPosition.y.CompareTo(y.transform.localPosition.y); });
        //将tile尺寸改为0  并且设置成未激活状态
        foreach (TileBehavior tileBehavior in tileBehaviors)
        {
            tileBehavior.transform.localScale = Vector3.zero;
            tileBehavior.SetState(false, false);
        }

        for (int i = 0; i < tileBehaviors.Count; i++)
        {
            tileBehaviors[i].SetState(MeBoatAdolescence(tileBehaviors[i]));
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
        if (!CommonUtil.IsApple())
        {

            RaftNeedy.instance.OfFecundSoda(false);
        }
        if (!(PlayerPrefs.GetInt(CConfig.FinishWangzhuanGuide) == 0))
        {
            RaftNonself.GetInstance().EmpireStilt = true;
        }
        
    }

    public void BoatFamilyIngenuity(List<TileBehavior> tileBehaviors)
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
            tileBehaviors[i].SetState(MeBoatAdolescence(tileBehaviors[i]));
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

    //public IEnumerator DripFosterWaterfall(List<TileBehavior> tileBehaviors)
    //{
    //    tileBehaviors.Sort((x, y) => { return x.transform.position.y.CompareTo(y.transform.position.y); });
    //    //将tile尺寸改为0  并且设置成未激活状态
    //    foreach (TileBehavior tileBehavior in tileBehaviors)
    //    {
    //        tileBehavior.transform.localScale = Vector3.zero;
    //        tileBehavior.SetState(false, false);
    //    }

    //    for (int i = 0; i < tileBehaviors.Count; i++)
    //    {
    //        tileBehaviors[i].SetState(OfDripUndisturbed(tileBehaviors[i]));
    //        yield return null;
    //        tileBehaviors[i].transform.DOKill();
    //        // 创建序列
    //        Sequence sequence = DOTween.Sequence();

    //        // 添加放大动画
    //        sequence.Append(tileBehaviors[i].transform.DOScale(1.5f, 0.2f)
    //            .SetEase(Ease.OutQuad));

    //        // 添加缩小动画 (回到原始大小)
    //        sequence.Append(tileBehaviors[i].transform.DOScale(1, 0.2f)
    //            .SetEase(Ease.OutQuad));

    //        // 设置动画完成后自动销毁
    //        sequence.OnComplete(() =>
    //        {
    //            // 这里可以添加动画完成后的逻辑
    //        });
    //    }
    //}

    //更新tile状态
    public void LatterHeroic(bool withAnimation = false)
    {
        foreach (TileBehavior tile in BoatLife)
        {
            tile.SetState(MeBoatAdolescence(tile), withAnimation);
        }
    }

    //选中tile之后 在TileList中移除tile
    public void BalticTravel(TileBehavior tile)
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
        BoatLife.Remove(tile);
        Harbor[tile.ElementPosition] = null;
    }

    //给tile赋值位置和状态
    public bool MeBoatAdolescence(ElementPosition tilePos)
    {
        if (tilePos.LayerId == 0)
            return true;
        var layerIdFromBottom = BayGrant.AmountOfLayers - tilePos.LayerId - 1;
        bool isEven = layerIdFromBottom % 2 == 0;

        for (int i = tilePos.LayerId - 1; i >= 0; i--)
        {
            var thislayerIdFromBottom = BayGrant.AmountOfLayers - i - 1;

            bool isLayerEven = thislayerIdFromBottom % 2 == 0;

            var Allusion= new ElementPosition(tilePos, i);

            if (isEven == isLayerEven)
            {
                // if there is something directly above object, it is not available

                if (Harbor[Allusion].State)
                    return false;
            }
            else
            {
                var Ploy= isLayerEven ? TalkGrassCone : RagGrassCone;

                bool sizeIsBigger;
                if (isLayerEven)
                {
                    sizeIsBigger = MeSmokeGrassCopper;
                }
                else
                {
                    sizeIsBigger = !MeSmokeGrassCopper;
                }

                Allusion = new ElementPosition(sizeIsBigger ? Allusion + 1 : Allusion - 1, i);

                // Checking if there is something partly above the object. If there is - it is not available
                // Should check 4 times because every odd lever is bigger and shifted a little bit

                if (Allusion.X != -1 && Allusion.Y != -1 && Allusion.X != Ploy.x && Allusion.Y != Ploy.y && Harbor[Allusion].State)
                    return false;

                if (sizeIsBigger)
                {
                    var leftNeighbourPos = Allusion.LeftNeighbourPos;
                    if (leftNeighbourPos.X != -1 && leftNeighbourPos.Y != Ploy.y && Harbor[leftNeighbourPos].State)
                        return false;

                    var topNeighbourPos = Allusion.UpNeighbourPos;
                    if (topNeighbourPos.X != Ploy.x && topNeighbourPos.Y != -1 && Harbor[topNeighbourPos].State)
                        return false;

                    var topLeftNeighbourPos = topNeighbourPos.LeftNeighbourPos;
                    if (topLeftNeighbourPos.X != -1 && topLeftNeighbourPos.Y != -1 && Harbor[topLeftNeighbourPos].State)
                        return false;
                }
                else
                {
                    var rightNeighbourPos = Allusion.RightNeighbourPos;
                    if (rightNeighbourPos.X != Ploy.x && rightNeighbourPos.Y != -1 && Harbor[rightNeighbourPos].State)
                        return false;

                    var bottomNeighbourPos = Allusion.BottomNeighbourPos;

                    if (bottomNeighbourPos.X != -1 && bottomNeighbourPos.Y != Ploy.y && Harbor[bottomNeighbourPos].State)
                        return false;

                    var bottomRightNeighbourPos = bottomNeighbourPos.RightNeighbourPos;
                    if (bottomRightNeighbourPos.X != Ploy.x && bottomRightNeighbourPos.Y != Ploy.y && Harbor[bottomRightNeighbourPos].State)
                        return false;
                }
            }
        }

        return true;
    }

    public List<SlotBehavior> YouTonDime()
    {
        return TonLoadLife;
    }
}

