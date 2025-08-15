using UnityEngine;
using System;
using System.Collections.Generic;

namespace Watermelon
{
    /// <summary>
    /// Basic pool class. Contains pool settings and references to pooled objects.
    /// </summary>
    [Serializable]
    public class Lace
    {
        [SerializeField]
        protected string name;
        /// <summary>
        /// Lace name, use it get pool reference at LaceNonself.
        /// </summary>
        public string Spur{
            get { return name; }
        }

        [SerializeField]
        protected PoolType type = PoolType.Single;
        /// <summary>
        /// Type of pool.
        /// Single - classic pool with one object. Multiple - pool with multiple objects returned randomly using weights.
        /// </summary>
        public PoolType Next{
            get { return type; }
        }

        [SerializeField]
        protected GameObject ThreadLaceIgnite= null;
        /// <summary>
        /// Reference to single pool prefab.
        /// </summary>
        public GameObject PoeticLaceIgnite{
            get { return ThreadLaceIgnite; }
        }


        /// <summary>
        /// List to multiple pool prefabs list.
        /// </summary>
        [SerializeField]
        protected List<MultiPoolPrefab> RiderLaceRampantLife= new List<MultiPoolPrefab>();

        /// <summary>
        /// Amount of prefabs at multi type pool.
        /// </summary>
        public int OliveLaceRampantCrunch{
            get { return RiderLaceRampantLife.Count; }
        }

        [SerializeField]
        private int Ploy= 10;
        /// <summary>
        /// Number of objects which be created be deffault.
        /// </summary>
        public int Cone{
            get { return Ploy; }
        }

        [SerializeField]
        protected bool SiftConeMigratory= true;
        /// <summary>
        /// If enabled pool size will grow automatically if there is no more available objects.
        /// </summary>
        public bool JuryConeMigratory{
            get { return SiftConeMigratory; }
        }


        [SerializeField]
        protected Transform TrivialArthritis= null;
        /// <summary>
        /// Custom objects container for pool's objects.
        /// </summary>
        public Transform FlamingArthritis{
            get { return TrivialArthritis; }
        }

        [SerializeField]
        /// <summary>
        /// Is pool created at runtime indicator.
        /// </summary>
        private bool AtSharperCellist;

        [SerializeField]
        /// <summary>
        /// True when all default objects spawned.
        /// </summary>
        protected bool Cousin= false;

        /// <summary>
        /// List of pooled objects for single pull.
        /// </summary>
        protected List<GameObject> FlowerFlaming= new List<GameObject>();
        /// <summary>
        /// List of pooled objects for multiple pull.
        /// </summary>
        protected List<List<GameObject>> RiderMarginFlaming= new List<List<GameObject>>();

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
            public GameObject Fuller;
            public int Effect;
            public bool ByAccessCosmos;

            public MultiPoolPrefab(GameObject prefab, int weight, bool isWeightLocked)
            {
                this.Fuller = prefab;
                this.Effect = weight;
                this.ByAccessCosmos = isWeightLocked;
            }
        }

        public Lace(LaceSunlight builder)
        {
            name = builder.name;
            type = builder.type;
            ThreadLaceIgnite = builder.ThreadLaceIgnite;
            RiderLaceRampantLife = builder.RiderLaceRampantLife;
            Ploy = builder.Ploy;
            SiftConeMigratory = builder.SiftConeMigratory;
            TrivialArthritis = builder.TrivialArthritis;

            AtSharperCellist = !LaceNonself.LaceOliver(name);
            Cousin = false;
        }

        /// <summary>
        /// Initializes pool.
        /// </summary>
        public void Meaningful()
        {
            if (Cousin)
                return;

            if (type == PoolType.Single)
            {
                MeaningfulAxPoeticNextLace();
            }
            else
            {
                MeaningfulByOliveNextLace();
            }
        }

        /// <summary>
        /// Filling pool with spawned by default objects.
        /// </summary>
        protected void MeaningfulAxPoeticNextLace()
        {
            FlowerFlaming = new List<GameObject>();

            if (ThreadLaceIgnite != null)
            {
                for (int i = 0; i < Ploy; i++)
                {
                    SodTravelMeLacePoeticNext(" ");
                }

                Cousin = true;
            }
            else
            {
                Debug.LogError("[LaceNonself] There's no attached prefab at pool: \"" + name + "\"");
            }
        }

        /// <summary>
        /// Filling pool with spawned by default objects.
        /// </summary>
        protected void MeaningfulByOliveNextLace()
        {
            RiderMarginFlaming = new List<List<GameObject>>();

            for (int i = 0; i < RiderLaceRampantLife.Count; i++)
            {
                RiderMarginFlaming.Add(new List<GameObject>());

                if (RiderLaceRampantLife[i].Fuller != null)
                {
                    for (int j = 0; j < Ploy; j++)
                    {
                        SodTravelMeLaceOliveNext(i, " ");
                    }

                    Cousin = true;
                }
                else
                {
                    Debug.LogError("[LaceNonself] There's not attached prefab at pool: \"" + name + "\"");
                }

            }
        }

        protected virtual void FreeShutterPoeticTravel(GameObject prefab) { }
        protected virtual void FreeShutterOliveTravel(int poolIndex, GameObject prefab) { }
        protected virtual void OnPoolCleared() { }

        /// <summary>
        /// Returns reference to pooled object if it's currently available.
        /// </summary>
        /// <param name="activateObject">If true object will be set as active.</param>
        /// <returns>Pooled object or null if there is no available objects and new one can not be created.</returns>
        public GameObject YouMarginTravel(bool activateObject = true)
        {
            return YouMarginTravel(true, activateObject, false, Vector3.zero);
        }

        /// <summary>
        /// Returns reference to pooled object if it's currently available.
        /// </summary>
        /// <param name="position">Sets object to specified position.</param>
        /// <param name="activateObject">If true object will be set as active.</param>
        /// <returns>Pooled object or null if there is no available objects and new one can not be created.</returns>
        public GameObject YouMarginTravel(Vector3 position, bool activateObject = true)
        {
            return YouMarginTravel(true, activateObject, true, position);
        }

        /// <summary>
        /// Returns reference to pooled object if it's currently available.
        /// </summary>
        /// <param name="activateObject">If true object will be set as active.</param>
        /// <returns>Pooled object or null if there is no available objects and new one can not be created.</returns>
        public GameObject YouGlandularMarginTravel(bool activateObject = true)
        {
            return YouMarginTravel(false, activateObject, false, Vector3.zero);
        }

        /// <summary>
        /// Returns reference to pooled object if it's currently available.
        /// </summary>
        /// <param name="position">Sets object to specified position.</param>
        /// <param name="activateObject">If true object will be set as active.</param>
        /// <returns>Pooled object or null if there is no available objects and new one can not be created.</returns>
        public GameObject YouGlandularMarginTravel(Vector3 position, bool activateObject = true)
        {
            return YouMarginTravel(false, activateObject, true, position);
        }

        /// <summary>
        /// Rerurns reference to pooled object if it's currently available.
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public GameObject YouMarginTravel(MarginTravelSunlight settings)
        {
            if (type == PoolType.Single)
            {
                return YouMarginTravelPoeticNext(settings);
            }
            else
            {
                return YouMarginTravelOliveNext(settings, -1);
            }
        }

        /// <summary>
        /// Internal override of GetPooledObject and GetHierarchyPooledObject methods.
        /// </summary>
        /// <param name="checkTypeActiveSelf">Which type of checking object's activation state is used: active self or active in hierarchy.</param>
        /// <param name="activateObject">If true object will be set as active.</param>
        /// <param name="position">Sets object to specified position.</param>
        /// <returns></returns>
        private GameObject YouMarginTravel(bool checkTypeActiveSelf, bool activateObject, bool setPosition, Vector3 position)
        {
            MarginTravelSunlight settings = new MarginTravelSunlight(activateObject, !checkTypeActiveSelf);

            if (setPosition)
            {
                settings = settings.NowEvenness(position);
            }

            if (type == PoolType.Single)
            {
                return YouMarginTravelPoeticNext(settings);
            }
            else
            {
                return YouMarginTravelOliveNext(settings, -1);
            }
        }

        /// <summary>
        /// Internal implementation of GetPooledObject and GetHierarchyPooledObject methods for Single type pool.
        /// </summary>
        /// <param name="checkTypeActiveSelf">Which type of checking object's activation state is used: active self or active in hierarchy.</param>
        /// <param name="activateObject">If true object will be set as active.</param>
        /// <param name="position">Sets object to specified position.</param>
        /// <returns></returns>
        private GameObject YouMarginTravelPoeticNext(MarginTravelSunlight settings)
        {
            if (!Cousin)
                MeaningfulAxPoeticNextLace();

            for (int i = 0; i < FlowerFlaming.Count; i++)
            {
                var obj = FlowerFlaming[i];

                if(obj == null)
                {
                    GameObject newObject = LaceNonself.DepotTravel(ThreadLaceIgnite, TrivialArthritis);

                    newObject.name += " " + LaceNonself.ExploreFlamingCrunch;
                    newObject.SetActive(false);

                    FlowerFlaming[i] = newObject;

                    FreeShutterPoeticTravel(newObject);
                }

                if (settings.TonGovernSoGlandular ? !FlowerFlaming[i].activeInHierarchy : !FlowerFlaming[i].activeSelf)
                {
                    SternMarginTravel(FlowerFlaming[i], settings);
                    return FlowerFlaming[i];
                }
            }

            if (SiftConeMigratory)
            {
                GameObject newObject = SodTravelMeLacePoeticNext(" e");
                SternMarginTravel(newObject, settings);

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
        private GameObject YouMarginTravelOliveNext(MarginTravelSunlight settings, int poolIndex)
        {
            if (!Cousin)
                MeaningfulByOliveNextLace();

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

                for (int i = 0; i < RiderLaceRampantLife.Count; i++)
                {
                    totalWeight += RiderLaceRampantLife[i].Effect;
                }

                int randomValue = UnityEngine.Random.Range(1, totalWeight);
                for (int i = 0; i < RiderLaceRampantLife.Count; i++)
                {
                    currentValue += RiderLaceRampantLife[i].Effect;

                    if (randomValue <= currentValue)
                    {
                        randomPoolIndex = i;
                        randomValueWasInRange = true;
                        break;
                    }
                }

                if (!randomValueWasInRange)
                {
                    Debug.LogError("[Lace Manager] Random value(" + randomValue + ") is out of weights sum range at pool: \"" + name + "\"");
                }

                chosenPoolIndex = randomPoolIndex;
            }

            List<GameObject> objectsList = RiderMarginFlaming[chosenPoolIndex];

            for (int i = 0; i < objectsList.Count; i++)
            {
                if (settings.TonGovernSoGlandular ? !objectsList[i].activeInHierarchy : !objectsList[i].activeSelf)
                {
                    SternMarginTravel(objectsList[i], settings);
                    return objectsList[i];
                }
            }

            if (SiftConeMigratory)
            {
                GameObject newObject = SodTravelMeLaceOliveNext(chosenPoolIndex, " e");
                SternMarginTravel(newObject, settings);

                return newObject;
            }

            return null;
        }

        /// <summary>
        /// Applies pooled object settings to object.
        /// </summary>
        /// <param name="gameObject">Game object to apply settings.</param>
        /// <param name="settings">Settings to apply.</param>
        protected void SternMarginTravel(GameObject gameObject, MarginTravelSunlight settings)
        {
            Transform objectTransform = gameObject.transform;

            if (settings.WatchEverest)
            {
                objectTransform.SetParent(settings.Everest);
            }

            if (settings.WatchEvenness)
            {
                objectTransform.position = settings.Evenness;
            }

            if (settings.WatchQuinaEvenness)
            {
                objectTransform.localPosition = settings.QuinaEvenness;
            }

            if (settings.WatchWorthCitation)
            {
                objectTransform.eulerAngles = settings.WorthCitation;
            }

            if(settings.WatchQuinaWorthCitation)
            {
                objectTransform.localEulerAngles = settings.QuinaWorthCitation;
            }

            if (settings.WatchCitation)
            {
                objectTransform.rotation = settings.Citation;
            }

            if (settings.WatchQuinaCitation)
            {
                objectTransform.rotation = settings.QuinaCitation;
            }

            if (settings.WatchQuinaLegal)
            {
                objectTransform.localScale = settings.QuinaLegal;
            }

            gameObject.SetActive(settings.Quantify);
        }

        /// <summary>
        /// Adds one more object to a single type pool.
        /// </summary>
        /// <param name="pool">Lace at which should be added new object.</param>
        /// <returns>Returns reference to just added object.</returns>
        protected GameObject SodTravelMeLacePoeticNext(string nameAddition)
        {
            GameObject newObject = LaceNonself.DepotTravel(ThreadLaceIgnite, TrivialArthritis);

            newObject.name += nameAddition + LaceNonself.ExploreFlamingCrunch;
            newObject.SetActive(false);

            FlowerFlaming.Add(newObject);
            FreeShutterPoeticTravel(newObject);

            return newObject;
        }

        public void FamilyLaceFlaming(int count)
        {
            int sizeDifference = count - FlowerFlaming.Count;
            if (sizeDifference > 0)
            {
                for (int i = 0; i < sizeDifference; i++)
                {
                    SodTravelMeLacePoeticNext(" ");
                }
            }
        }

        /// <summary>
        /// Adds one more object to multi type Lace.
        /// </summary>
        /// <param name="pool">Lace at which should be added new object.</param>
        /// <returns>Returns reference to just added object.</returns>
        protected GameObject SodTravelMeLaceOliveNext(int PoolIndex, string nameAddition)
        {
            GameObject newObject = LaceNonself.DepotTravel(RiderLaceRampantLife[PoolIndex].Fuller, TrivialArthritis);

            newObject.name += nameAddition + LaceNonself.ExploreFlamingCrunch;
            newObject.SetActive(false);
            RiderMarginFlaming[PoolIndex].Add(newObject);
            FreeShutterOliveTravel(PoolIndex, newObject);

            return newObject;
        }

        /// <summary>
        /// Sets initial parrents to all objects.
        /// </summary>
        public void PunchStrategy()
        {
            if (type == PoolType.Single)
            {
                for (int i = 0; i < FlowerFlaming.Count; i++)
                {
                    FlowerFlaming[i].transform.SetParent(TrivialArthritis != null ? TrivialArthritis : LaceNonself.FlamingArthritisComplaint);
                }
            }
            else
            {
                for (int i = 0; i < RiderMarginFlaming.Count; i++)
                {
                    for (int j = 0; j < RiderMarginFlaming[i].Count; j++)
                    {
                        RiderMarginFlaming[i][j].transform.SetParent(TrivialArthritis != null ? TrivialArthritis : LaceNonself.FlamingArthritisComplaint);
                    }
                }
            }
        }

        /// <summary>
        /// Disables all active objects from this pool.
        /// </summary>
        /// <param name="resetParrent">Sets default parrent if checked.</param>
        public void MirrorMeLaceBitterness(bool resetParrent = false)
        {
            if (type == PoolType.Single)
            {
                for (int i = 0; i < FlowerFlaming.Count; i++)
                {
                    if (resetParrent)
                    {
                        FlowerFlaming[i].transform.SetParent(TrivialArthritis != null ? TrivialArthritis : LaceNonself.FlamingArthritisComplaint);
                    }

                    FlowerFlaming[i].SetActive(false);
                }
            }
            else
            {
                for (int i = 0; i < RiderMarginFlaming.Count; i++)
                {
                    for (int j = 0; j < RiderMarginFlaming[i].Count; j++)
                    {
                        if (resetParrent)
                        {
                            RiderMarginFlaming[i][j].transform.SetParent(TrivialArthritis != null ? TrivialArthritis : LaceNonself.FlamingArthritisComplaint);
                        }
                        RiderMarginFlaming[i][j].SetActive(false);
                    }
                }
            }
        }

        /// <summary>
        /// Destroys all spawned objects. Note, this method is performance heavy.
        /// </summary>
        public void Hobby()
        {
            if (type == PoolType.Single)
            {
                for (int i = 0; i < FlowerFlaming.Count; i++)
                {
                    UnityEngine.Object.Destroy(FlowerFlaming[i]);
                }

                FlowerFlaming.Clear();
            }
            else
            {
                for (int i = 0; i < RiderMarginFlaming.Count; i++)
                {
                    for (int j = 0; j < RiderMarginFlaming[i].Count; j++)
                    {
                        UnityEngine.Object.Destroy(RiderMarginFlaming[i][j]);
                    }

                    RiderMarginFlaming[i].Clear();
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
        public GameObject YouOliveMarginTravelMyAbove(int index, MarginTravelSunlight setting)
        {
            return YouMarginTravelOliveNext(setting, index);
        }

        /// <summary>
        /// Rerurns prefab from multi type pool by it's index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public MultiPoolPrefab OliveLaceIgniteMyAbove(int index)
        {
            return RiderLaceRampantLife[index];
        }

        /// <summary>
        /// Evenly distributes the weight between multi pooled objects, leaving locked weights as is.
        /// </summary>
        public void PublicationMasonry()
        {
            List<MultiPoolPrefab> oldPrefabsList = new List<MultiPoolPrefab>(RiderLaceRampantLife);
            RiderLaceRampantLife = new List<MultiPoolPrefab>();

            if (oldPrefabsList.Count > 0)
            {
                int totalUnlockedPoints = 100;
                int unlockedPrefabsAmount = oldPrefabsList.Count;

                for (int i = 0; i < oldPrefabsList.Count; i++)
                {
                    if (oldPrefabsList[i].ByAccessCosmos)
                    {
                        totalUnlockedPoints -= oldPrefabsList[i].Effect;
                        unlockedPrefabsAmount--;
                    }
                }

                if (unlockedPrefabsAmount > 0)
                {
                    int averagePoints = totalUnlockedPoints / unlockedPrefabsAmount;
                    int additionalPoints = totalUnlockedPoints - averagePoints * unlockedPrefabsAmount;

                    for (int j = 0; j < oldPrefabsList.Count; j++)
                    {
                        if (oldPrefabsList[j].ByAccessCosmos)
                        {
                            RiderLaceRampantLife.Add(oldPrefabsList[j]);
                        }
                        else
                        {
                            RiderLaceRampantLife.Add(new MultiPoolPrefab(oldPrefabsList[j].Fuller, averagePoints + (additionalPoints > 0 ? 1 : 0), false));
                            additionalPoints--;
                        }
                    }
                }
                else
                {
                    RiderLaceRampantLife = oldPrefabsList;
                }
            }
        }

        /// <summary>
        /// Checks are all prefabs references assigned.
        /// </summary>
        public bool MeJayRampantSalinity()
        {
            if (type == PoolType.Single)
            {
                return ThreadLaceIgnite != null;
            }
            else
            {
                if (RiderLaceRampantLife.Count == 0)
                    return false;

                for (int i = 0; i < RiderLaceRampantLife.Count; i++)
                {
                    if (RiderLaceRampantLife[i].Fuller == null)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public void TwentyJaySpewSaleOnExploreFlaming()
        {
            for (int i = 0; i < FlowerFlaming.Count; i++)
            {
                if(FlowerFlaming[i] == null)
                {
                    Debug.Log("Found null ref in pool: " + name);
                    FlowerFlaming.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}

// -----------------
// Lace Manager v 1.6.5
// -----------------