using UnityEngine;
using System;
using System.Collections.Generic;

namespace Watermelon
{
    /// <summary>
    /// Basic pool class. Contains pool settings and references to pooled objects.
    /// </summary>
    [Serializable]
    public class Gild
    {
        [SerializeField]
        protected string name;
        /// <summary>
        /// Gild name, use it get pool reference at GildTenuous.
        /// </summary>
        public string Bend        {
            get { return name; }
        }

        [SerializeField]
        protected PoolType type = PoolType.Single;
        /// <summary>
        /// Type of pool.
        /// Single - classic pool with one object. Multiple - pool with multiple objects returned randomly using weights.
        /// </summary>
        public PoolType Hard        {
            get { return type; }
        }

        [SerializeField]
        protected GameObject ChangeGildPotato= null;
        /// <summary>
        /// Reference to single pool prefab.
        /// </summary>
        public GameObject GlanceGildPotato        {
            get { return ChangeGildPotato; }
        }


        /// <summary>
        /// List to multiple pool prefabs list.
        /// </summary>
        [SerializeField]
        protected List<MultiPoolPrefab> FlaskGildOnenessFire= new List<MultiPoolPrefab>();

        /// <summary>
        /// Amount of prefabs at multi type pool.
        /// </summary>
        public int CrimpGildOnenessAdrift        {
            get { return FlaskGildOnenessFire.Count; }
        }

        [SerializeField]
        private int Kill= 10;
        /// <summary>
        /// Number of objects which be created be deffault.
        /// </summary>
        public int Holy        {
            get { return Kill; }
        }

        [SerializeField]
        protected bool StemHolyOutnumber= true;
        /// <summary>
        /// If enabled pool size will grow automatically if there is no more available objects.
        /// </summary>
        public bool MuleHolyOutnumber        {
            get { return StemHolyOutnumber; }
        }


        [SerializeField]
        protected Transform GrecianDiversify= null;
        /// <summary>
        /// Custom objects container for pool's objects.
        /// </summary>
        public Transform MissionDiversify        {
            get { return GrecianDiversify; }
        }

        [SerializeField]
        /// <summary>
        /// Is pool created at runtime indicator.
        /// </summary>
        private bool isTriumphRemnant;

        [SerializeField]
        /// <summary>
        /// True when all default objects spawned.
        /// </summary>
        protected bool Vanish= false;

        /// <summary>
        /// List of pooled objects for single pull.
        /// </summary>
        protected List<GameObject> AutumnMission= new List<GameObject>();
        /// <summary>
        /// List of pooled objects for multiple pull.
        /// </summary>
        protected List<List<GameObject>> FlaskTempleMission= new List<List<GameObject>>();

#if UNITY_EDITOR
        /// <summary>
        /// Number of objects that where active at one time.
        /// </summary>
        protected int maxItemsUsedInOneTime = 0;
#endif

        public enum PoolType
        {
            Single = 0,
            Multi = 1,
        }

        [System.Serializable]
        public struct MultiPoolPrefab
        {
            public GameObject Ignite;
            public int Trader;
            public bool DyMatureGallop;

            public MultiPoolPrefab(GameObject prefab, int weight, bool isWeightLocked)
            {
                this.Ignite = prefab;
                this.Trader = weight;
                this.DyMatureGallop = isWeightLocked;
            }
        }

        public Gild(GildMainland builder)
        {
            name = builder.name;
            type = builder.type;
            ChangeGildPotato = builder.ChangeGildPotato;
            FlaskGildOnenessFire = builder.FlaskGildOnenessFire;
            Kill = builder.Kill;
            StemHolyOutnumber = builder.StemHolyOutnumber;
            GrecianDiversify = builder.GrecianDiversify;

            isTriumphRemnant = !GildTenuous.GildImpair(name);
            Vanish = false;
        }

        /// <summary>
        /// Initializes pool.
        /// </summary>
        public void Abundantly()
        {
            if (Vanish)
                return;

            if (type == PoolType.Single)
            {
                AbundantlyAxGlanceHardGild();
            }
            else
            {
                AbundantlyAxCrimpHardGild();
            }
        }

        /// <summary>
        /// Filling pool with spawned by default objects.
        /// </summary>
        protected void AbundantlyAxGlanceHardGild()
        {
            AutumnMission = new List<GameObject>();

            if (ChangeGildPotato != null)
            {
                for (int i = 0; i < Kill; i++)
                {
                    LidBounceOxGildGlanceHard(" ");
                }

                Vanish = true;
            }
            else
            {
                Debug.LogError("[GildTenuous] There's no attached prefab at pool: \"" + name + "\"");
            }
        }

        /// <summary>
        /// Filling pool with spawned by default objects.
        /// </summary>
        protected void AbundantlyAxCrimpHardGild()
        {
            FlaskTempleMission = new List<List<GameObject>>();

            for (int i = 0; i < FlaskGildOnenessFire.Count; i++)
            {
                FlaskTempleMission.Add(new List<GameObject>());

                if (FlaskGildOnenessFire[i].Ignite != null)
                {
                    for (int j = 0; j < Kill; j++)
                    {
                        LidBounceOxGildCrimpHard(i, " ");
                    }

                    Vanish = true;
                }
                else
                {
                    Debug.LogError("[GildTenuous] There's not attached prefab at pool: \"" + name + "\"");
                }

            }
        }

        protected virtual void BlueClassicGlanceBounce(GameObject prefab) { }
        protected virtual void BlueClassicCrimpBounce(int poolIndex, GameObject prefab) { }
        protected virtual void OnPoolCleared() { }

        /// <summary>
        /// Returns reference to pooled object if it's currently available.
        /// </summary>
        /// <param name="activateObject">If true object will be set as active.</param>
        /// <returns>Pooled object or null if there is no available objects and new one can not be created.</returns>
        public GameObject MobTempleBounce(bool activateObject = true)
        {
            return MobTempleBounce(true, activateObject, false, Vector3.zero);
        }

        /// <summary>
        /// Returns reference to pooled object if it's currently available.
        /// </summary>
        /// <param name="position">Sets object to specified position.</param>
        /// <param name="activateObject">If true object will be set as active.</param>
        /// <returns>Pooled object or null if there is no available objects and new one can not be created.</returns>
        public GameObject MobTempleBounce(Vector3 position, bool activateObject = true)
        {
            return MobTempleBounce(true, activateObject, true, position);
        }

        /// <summary>
        /// Returns reference to pooled object if it's currently available.
        /// </summary>
        /// <param name="activateObject">If true object will be set as active.</param>
        /// <returns>Pooled object or null if there is no available objects and new one can not be created.</returns>
        public GameObject MobResidencyTempleBounce(bool activateObject = true)
        {
            return MobTempleBounce(false, activateObject, false, Vector3.zero);
        }

        /// <summary>
        /// Returns reference to pooled object if it's currently available.
        /// </summary>
        /// <param name="position">Sets object to specified position.</param>
        /// <param name="activateObject">If true object will be set as active.</param>
        /// <returns>Pooled object or null if there is no available objects and new one can not be created.</returns>
        public GameObject MobResidencyTempleBounce(Vector3 position, bool activateObject = true)
        {
            return MobTempleBounce(false, activateObject, true, position);
        }

        /// <summary>
        /// Rerurns reference to pooled object if it's currently available.
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public GameObject MobTempleBounce(TempleBounceMainland settings)
        {
            if (type == PoolType.Single)
            {
                return MobTempleBounceGlanceHard(settings);
            }
            else
            {
                return MobTempleBounceCrimpHard(settings, -1);
            }
        }

        /// <summary>
        /// Internal override of GetPooledObject and GetHierarchyPooledObject methods.
        /// </summary>
        /// <param name="checkTypeActiveSelf">Which type of checking object's activation state is used: active self or active in hierarchy.</param>
        /// <param name="activateObject">If true object will be set as active.</param>
        /// <param name="position">Sets object to specified position.</param>
        /// <returns></returns>
        private GameObject MobTempleBounce(bool checkTypeActiveSelf, bool activateObject, bool setPosition, Vector3 position)
        {
            TempleBounceMainland settings = new TempleBounceMainland(activateObject, !checkTypeActiveSelf);

            if (setPosition)
            {
                settings = settings.FinDiffuses(position);
            }

            if (type == PoolType.Single)
            {
                return MobTempleBounceGlanceHard(settings);
            }
            else
            {
                return MobTempleBounceCrimpHard(settings, -1);
            }
        }

        /// <summary>
        /// Internal implementation of GetPooledObject and GetHierarchyPooledObject methods for Single type pool.
        /// </summary>
        /// <param name="checkTypeActiveSelf">Which type of checking object's activation state is used: active self or active in hierarchy.</param>
        /// <param name="activateObject">If true object will be set as active.</param>
        /// <param name="position">Sets object to specified position.</param>
        /// <returns></returns>
        private GameObject MobTempleBounceGlanceHard(TempleBounceMainland settings)
        {
            if (!Vanish)
                AbundantlyAxGlanceHardGild();

            for (int i = 0; i < AutumnMission.Count; i++)
            {
                var obj = AutumnMission[i];

                if(obj == null)
                {
                    GameObject newObject = GildTenuous.LapisBounce(ChangeGildPotato, GrecianDiversify);

                    newObject.name += " " + GildTenuous.OverlieMissionAdrift;
                    newObject.SetActive(false);

                    AutumnMission[i] = newObject;

                    BlueClassicGlanceBounce(newObject);
                }

                if (settings.LieMidwayMeResidency ? !AutumnMission[i].activeInHierarchy : !AutumnMission[i].activeSelf)
                {
                    RealmTempleBounce(AutumnMission[i], settings);
                    return AutumnMission[i];
                }
            }

            if (StemHolyOutnumber)
            {
                GameObject newObject = LidBounceOxGildGlanceHard(" e");
                RealmTempleBounce(newObject, settings);

                return newObject;
            }

            return null;
        }

        /// <summary>
        /// Internal implementation of GetPooledObject and GetHierarchyPooledObject methods for Multi type pool.
        /// </summary>
        /// <param name="checkTypeActiveSelf">Which type of checking object's activation state is used: active self or active in hierarchy.</param>
        /// <param name="activateObject">If true object will be set as active.</param>
        /// <param name="position">Sets object to specified position.</param>
        /// <returns></returns>
        private GameObject MobTempleBounceCrimpHard(TempleBounceMainland settings, int poolIndex)
        {
            if (!Vanish)
                AbundantlyAxCrimpHardGild();

            int chosenPoolIndex = 0;

            if (poolIndex != -1)
            {
                chosenPoolIndex = poolIndex;
            }
            else
            {
                int randomPoolIndex = 0;
                bool randomValueWasInRange = false;
                int currentValue = 0;
                int totalWeight = 0;

                for (int i = 0; i < FlaskGildOnenessFire.Count; i++)
                {
                    totalWeight += FlaskGildOnenessFire[i].Trader;
                }

                int randomValue = UnityEngine.Random.Range(1, totalWeight);
                for (int i = 0; i < FlaskGildOnenessFire.Count; i++)
                {
                    currentValue += FlaskGildOnenessFire[i].Trader;

                    if (randomValue <= currentValue)
                    {
                        randomPoolIndex = i;
                        randomValueWasInRange = true;
                        break;
                    }
                }

                if (!randomValueWasInRange)
                {
                    Debug.LogError("[Gild Manager] Random value(" + randomValue + ") is out of weights sum range at pool: \"" + name + "\"");
                }

                chosenPoolIndex = randomPoolIndex;
            }

            List<GameObject> objectsList = FlaskTempleMission[chosenPoolIndex];

            for (int i = 0; i < objectsList.Count; i++)
            {
                if (settings.LieMidwayMeResidency ? !objectsList[i].activeInHierarchy : !objectsList[i].activeSelf)
                {
                    RealmTempleBounce(objectsList[i], settings);
                    return objectsList[i];
                }
            }

            if (StemHolyOutnumber)
            {
                GameObject newObject = LidBounceOxGildCrimpHard(chosenPoolIndex, " e");
                RealmTempleBounce(newObject, settings);

                return newObject;
            }

            return null;
        }

        /// <summary>
        /// Applies pooled object settings to object.
        /// </summary>
        /// <param name="gameObject">Game object to apply settings.</param>
        /// <param name="settings">Settings to apply.</param>
        protected void RealmTempleBounce(GameObject gameObject, TempleBounceMainland settings)
        {
            Transform objectTransform = gameObject.transform;

            if (settings.ButteExhibit)
            {
                objectTransform.SetParent(settings.Exhibit);
            }

            if (settings.ButteDiffuses)
            {
                objectTransform.position = settings.Diffuses;
            }

            if (settings.ButteSnoutDiffuses)
            {
                objectTransform.localPosition = settings.SnoutDiffuses;
            }

            if (settings.ButteChompDisprove)
            {
                objectTransform.eulerAngles = settings.ChompDisprove;
            }

            if(settings.ButteSnoutChompDisprove)
            {
                objectTransform.localEulerAngles = settings.SnoutChompDisprove;
            }

            if (settings.ButteDisprove)
            {
                objectTransform.rotation = settings.Disprove;
            }

            if (settings.ButteSnoutDisprove)
            {
                objectTransform.rotation = settings.SnoutDisprove;
            }

            if (settings.ButteSnoutAdept)
            {
                objectTransform.localScale = settings.SnoutAdept;
            }

            gameObject.SetActive(settings.Currency);
        }

        /// <summary>
        /// Adds one more object to a single type pool.
        /// </summary>
        /// <param name="pool">Gild at which should be added new object.</param>
        /// <returns>Returns reference to just added object.</returns>
        protected GameObject LidBounceOxGildGlanceHard(string nameAddition)
        {
            GameObject newObject = GildTenuous.LapisBounce(ChangeGildPotato, GrecianDiversify);

            newObject.name += nameAddition + GildTenuous.OverlieMissionAdrift;
            newObject.SetActive(false);

            AutumnMission.Add(newObject);
            BlueClassicGlanceBounce(newObject);

            return newObject;
        }

        public void FosterGildMission(int count)
        {
            int sizeDifference = count - AutumnMission.Count;
            if (sizeDifference > 0)
            {
                for (int i = 0; i < sizeDifference; i++)
                {
                    LidBounceOxGildGlanceHard(" ");
                }
            }
        }

        /// <summary>
        /// Adds one more object to multi type Gild.
        /// </summary>
        /// <param name="pool">Gild at which should be added new object.</param>
        /// <returns>Returns reference to just added object.</returns>
        protected GameObject LidBounceOxGildCrimpHard(int PoolIndex, string nameAddition)
        {
            GameObject newObject = GildTenuous.LapisBounce(FlaskGildOnenessFire[PoolIndex].Ignite, GrecianDiversify);

            newObject.name += nameAddition + GildTenuous.OverlieMissionAdrift;
            newObject.SetActive(false);
            FlaskTempleMission[PoolIndex].Add(newObject);
            BlueClassicCrimpBounce(PoolIndex, newObject);

            return newObject;
        }

        /// <summary>
        /// Sets initial parrents to all objects.
        /// </summary>
        public void QuietDoubtful()
        {
            if (type == PoolType.Single)
            {
                for (int i = 0; i < AutumnMission.Count; i++)
                {
                    AutumnMission[i].transform.SetParent(GrecianDiversify != null ? GrecianDiversify : GildTenuous.MissionDiversifyGenuinely);
                }
            }
            else
            {
                for (int i = 0; i < FlaskTempleMission.Count; i++)
                {
                    for (int j = 0; j < FlaskTempleMission[i].Count; j++)
                    {
                        FlaskTempleMission[i][j].transform.SetParent(GrecianDiversify != null ? GrecianDiversify : GildTenuous.MissionDiversifyGenuinely);
                    }
                }
            }
        }

        /// <summary>
        /// Disables all active objects from this pool.
        /// </summary>
        /// <param name="resetParrent">Sets default parrent if checked.</param>
        public void RecoilOxGildCurriculum(bool resetParrent = false)
        {
            if (type == PoolType.Single)
            {
                for (int i = 0; i < AutumnMission.Count; i++)
                {
                    if (resetParrent)
                    {
                        AutumnMission[i].transform.SetParent(GrecianDiversify != null ? GrecianDiversify : GildTenuous.MissionDiversifyGenuinely);
                    }

                    AutumnMission[i].SetActive(false);
                }
            }
            else
            {
                for (int i = 0; i < FlaskTempleMission.Count; i++)
                {
                    for (int j = 0; j < FlaskTempleMission[i].Count; j++)
                    {
                        if (resetParrent)
                        {
                            FlaskTempleMission[i][j].transform.SetParent(GrecianDiversify != null ? GrecianDiversify : GildTenuous.MissionDiversifyGenuinely);
                        }
                        FlaskTempleMission[i][j].SetActive(false);
                    }
                }
            }
        }

        /// <summary>
        /// Destroys all spawned objects. Note, this method is performance heavy.
        /// </summary>
        public void Cliff()
        {
            if (type == PoolType.Single)
            {
                for (int i = 0; i < AutumnMission.Count; i++)
                {
                    UnityEngine.Object.Destroy(AutumnMission[i]);
                }

                AutumnMission.Clear();
            }
            else
            {
                for (int i = 0; i < FlaskTempleMission.Count; i++)
                {
                    for (int j = 0; j < FlaskTempleMission[i].Count; j++)
                    {
                        UnityEngine.Object.Destroy(FlaskTempleMission[i][j]);
                    }

                    FlaskTempleMission[i].Clear();
                }
            }

            OnPoolCleared();
        }

        /// <summary>
        /// Returns object from multi type pool by it's index on prefabs list.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="activateObject"></param>
        /// <returns></returns>
        public GameObject MobCrimpTempleBounceUpAlarm(int index, TempleBounceMainland setting)
        {
            return MobTempleBounceCrimpHard(setting, index);
        }

        /// <summary>
        /// Rerurns prefab from multi type pool by it's index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public MultiPoolPrefab CrimpGildPotatoUpAlarm(int index)
        {
            return FlaskGildOnenessFire[index];
        }

        /// <summary>
        /// Evenly distributes the weight between multi pooled objects, leaving locked weights as is.
        /// </summary>
        public void AcquisitionTheater()
        {
            List<MultiPoolPrefab> oldPrefabsList = new List<MultiPoolPrefab>(FlaskGildOnenessFire);
            FlaskGildOnenessFire = new List<MultiPoolPrefab>();

            if (oldPrefabsList.Count > 0)
            {
                int totalUnlockedPoints = 100;
                int unlockedPrefabsAmount = oldPrefabsList.Count;

                for (int i = 0; i < oldPrefabsList.Count; i++)
                {
                    if (oldPrefabsList[i].DyMatureGallop)
                    {
                        totalUnlockedPoints -= oldPrefabsList[i].Trader;
                        unlockedPrefabsAmount--;
                    }
                }

                if (unlockedPrefabsAmount > 0)
                {
                    int averagePoints = totalUnlockedPoints / unlockedPrefabsAmount;
                    int additionalPoints = totalUnlockedPoints - averagePoints * unlockedPrefabsAmount;

                    for (int j = 0; j < oldPrefabsList.Count; j++)
                    {
                        if (oldPrefabsList[j].DyMatureGallop)
                        {
                            FlaskGildOnenessFire.Add(oldPrefabsList[j]);
                        }
                        else
                        {
                            FlaskGildOnenessFire.Add(new MultiPoolPrefab(oldPrefabsList[j].Ignite, averagePoints + (additionalPoints > 0 ? 1 : 0), false));
                            additionalPoints--;
                        }
                    }
                }
                else
                {
                    FlaskGildOnenessFire = oldPrefabsList;
                }
            }
        }

        /// <summary>
        /// Checks are all prefabs references assigned.
        /// </summary>
        public bool OfWadOnenessSuitable()
        {
            if (type == PoolType.Single)
            {
                return ChangeGildPotato != null;
            }
            else
            {
                if (FlaskGildOnenessFire.Count == 0)
                    return false;

                for (int i = 0; i < FlaskGildOnenessFire.Count; i++)
                {
                    if (FlaskGildOnenessFire[i].Ignite == null)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public void CandidWadSpewCuteGoOverlieMission()
        {
            for (int i = 0; i < AutumnMission.Count; i++)
            {
                if(AutumnMission[i] == null)
                {
                    Debug.Log("Found null ref in pool: " + name);
                    AutumnMission.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}

// -----------------
// Gild Manager v 1.6.5
// -----------------