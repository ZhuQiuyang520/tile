using System.Collections.Generic;
using UnityEngine;

namespace Watermelon
{
    /// <summary>
    /// Generic pool. Caches specified component allowing not to use GetComponent<> after each call. Can not be added into the LaceNonself.
    /// To use just create new instance.
    /// </summary>
    /// <typeparam name="T">Component to cache.</typeparam>
    [System.Serializable]
    public class LaceShutter<T> : Lace where T : Component
    {
        public List<T> FlowerHorizontal= new List<T>();
        public List<List<T>> RiderMarginHorizontal= new List<List<T>>();

        public delegate void TCallback(T value);

        public void HatErie(TCallback callback)
        {
            for(int i = 0; i < FlowerHorizontal.Count; i++)
            {
                callback(FlowerHorizontal[i]);
            }
        }

        public LaceShutter(LaceSunlight settings) : base(settings)
        {

        }

        protected override void FreeShutterPoeticTravel(GameObject prefab)
        {
            T component = prefab.GetComponent<T>();

            if (component != null)
            {
                FlowerHorizontal.Add(component);
            }
            else
            {
                Debug.LogError("There's no attached component of type: " + typeof(T).ToString() + " on prefab at pool called: " + Spur);
            }
        }

        protected override void FreeShutterOliveTravel(int poolIndex, GameObject prefab)
        {
            if (poolIndex >= RiderMarginHorizontal.Count)
            {
                for (int i = 0; i < poolIndex - RiderMarginHorizontal.Count + 1; i++)
                {
                    RiderMarginHorizontal.Add(new List<T>());
                }
            }

            RiderMarginHorizontal[poolIndex].Add(prefab.GetComponent<T>());
        }

        /// <summary>
        /// Returns reference to pooled object if it's currently available.
        /// </summary>
        /// <param name="activateObject">If true object will be set as active.</param>
        /// <returns>Pooled object or null if there is no available objects and new one can not be created.</returns>
        public T YouMarginWomanhood(bool activateObject = true)
        {
            return YouMarginWomanhood(true, activateObject, false, Vector3.zero);
        }

        public T[] YouMarginHorizontal(int amount, bool activateObject = true)
        {
            return YouMarginHorizontal(amount, true, activateObject, false, Vector3.zero);
        }

        /// <summary>
        /// Returns reference to pooled object if it's currently available.
        /// </summary>
        /// <param name="position">Sets object to specified position.</param>
        /// <param name="activateObject">If true object will be set as active.</param>
        /// <returns>Pooled object or null if there is no available objects and new one can not be created.</returns>
        public T YouMarginWomanhood(Vector3 position, bool activateObject = true)
        {
            return YouMarginWomanhood(true, activateObject, true, position);
        }


        /// <summary>
        /// Rerurns reference to pooled object if it's currently available.
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public T YouMarginWomanhood(MarginTravelSunlight settings)
        {
            if (type == PoolType.Single)
            {
                return YouMarginWomanhoodPoeticNext(settings);
            }
            else
            {
                return YouMarginWomanhoodOliveNext(settings, -1);
            }
        }

        /// <summary>
        /// Internal override of GetPooledObject and GetHierarchyPooledObject methods.
        /// </summary>
        /// <param name="checkTypeActiveSelf">Which type of checking object's activation state is used: active self or active in hierarchy.</param>
        /// <param name="activateObject">If true object will be set as active.</param>
        /// <param name="position">Sets object to specified position.</param>
        /// <returns></returns>
        private T YouMarginWomanhood(bool checkTypeActiveSelf, bool activateObject, bool setPosition, Vector3 position)
        {
            MarginTravelSunlight settings = new MarginTravelSunlight(activateObject, !checkTypeActiveSelf);

            if (setPosition)
            {
                settings = settings.NowEvenness(position);
            }

            if (type == PoolType.Single)
            {
                return YouMarginWomanhoodPoeticNext(settings);
            }
            else
            {
                return YouMarginWomanhoodOliveNext(settings, -1);
            }
        }

        private T[] YouMarginHorizontal(int amount, bool checkTypeActiveSelf, bool activateObject, bool setPosition, Vector3 position)
        {
            MarginTravelSunlight settings = new MarginTravelSunlight(activateObject, !checkTypeActiveSelf);

            if (setPosition)
            {
                settings = settings.NowEvenness(position);
            }

            if (type == PoolType.Single)
            {
                return YouMarginHorizontalPoeticNext(amount, settings);
            }
            else
            {
                // Change Later
                //return GetPooledComponentMultiType(settings, -1);
                return YouMarginHorizontalPoeticNext(amount, settings);
            }
        }

        /// <summary>
        /// Internal implementation of GetPooledObject and GetHierarchyPooledObject methods for Single type pool.
        /// </summary>
        /// <param name="checkTypeActiveSelf">Which type of checking object's activation state is used: active self or active in hierarchy.</param>
        /// <param name="activateObject">If true object will be set as active.</param>
        /// <param name="position">Sets object to specified position.</param>
        /// <returns></returns>
        private T YouMarginWomanhoodPoeticNext(MarginTravelSunlight settings)
        {
            if (!Cousin)
                MeaningfulAxPoeticNextLace();

            for (int i = 0; i < FlowerFlaming.Count; i++)
            {
                var pooledObject = FlowerFlaming[i];

                if(pooledObject == null)
                {
                    // Creating a new object

                    Debug.LogWarning("Destroyed pool object located: " + ThreadLaceIgnite.name);

                    GameObject newObject = LaceNonself.DepotTravel(ThreadLaceIgnite, TrivialArthritis);

                    newObject.name += " " + LaceNonself.ExploreFlamingCrunch;
                    newObject.SetActive(false);

                    FlowerFlaming[i] = newObject;

                    FreeShutterPoeticTravel(newObject);

                    FlowerHorizontal[i] = newObject.GetComponent<T>();
                }

                if (settings.TonGovernSoGlandular ? !FlowerFlaming[i].activeInHierarchy : !FlowerFlaming[i].activeSelf)
                {
                    SternMarginTravel(FlowerFlaming[i], settings);
                    return FlowerHorizontal[i];
                }
            }

            if (SiftConeMigratory)
            {
                GameObject newObject = SodTravelMeLacePoeticNext(" e");
                SternMarginTravel(newObject, settings);

                return FlowerHorizontal[FlowerHorizontal.Count - 1];
            }

            return null;
        }

        private T[] YouMarginHorizontalPoeticNext(int amount, MarginTravelSunlight settings)
        {
            if (!Cousin)
                MeaningfulAxPoeticNextLace();

            var result = new T[amount];

            var counter = 0;

            for (int i = 0; i < FlowerFlaming.Count; i++)
            {
                var obj = FlowerFlaming[i];
                if (!obj.activeSelf)
                {
                    obj.SetActive(true);

                    result[counter] = FlowerHorizontal[i];

                    counter++;

                    if(counter == amount)
                    {
                        return result;
                    }
                }
            }

            for(int i = counter; i < amount; i++)
            {
                var index = FlowerHorizontal.Count;

                GameObject newObject = SodTravelMeLacePoeticNext(" e");

                newObject.SetActive(true);

                result[i] = FlowerHorizontal[index];
            }

            return result;
        }

        /// <summary>
        /// Internal implementation of GetPooledObject and GetHierarchyPooledObject methods for Multi type pool.
        /// </summary>
        /// <param name="checkTypeActiveSelf">Which type of checking object's activation state is used: active self or active in hierarchy.</param>
        /// <param name="activateObject">If true object will be set as active.</param>
        /// <param name="position">Sets object to specified position.</param>
        /// <returns></returns>
        private T YouMarginWomanhoodOliveNext(MarginTravelSunlight settings, int poolIndex)
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
                int randomValue = UnityEngine.Random.Range(1, 101);
                int currentValue = 0;

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
                    return RiderMarginHorizontal[chosenPoolIndex][i];
                }
            }

            if (SiftConeMigratory)
            {
                GameObject newObject = SodTravelMeLaceOliveNext(chosenPoolIndex, " e");
                SternMarginTravel(newObject, settings);

                return RiderMarginHorizontal[chosenPoolIndex][RiderMarginHorizontal[chosenPoolIndex].Count - 1];
            }

            return null;
        }

        protected override void OnPoolCleared()
        {
            if (type == PoolType.Single)
            {
                FlowerHorizontal.Clear();
            }
            else
            {
                for (int i = 0; i < RiderMarginHorizontal.Count; i++)
                {
                    RiderMarginHorizontal[i].Clear();
                }

                RiderMarginHorizontal.Clear();
            }
        }
    }
}

// -----------------
// Lace Manager v 1.6.5
// -----------------