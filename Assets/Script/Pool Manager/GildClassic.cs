using System.Collections.Generic;
using UnityEngine;

namespace Watermelon
{
    /// <summary>
    /// Generic pool. Caches specified component allowing not to use GetComponent<> after each call. Can not be added into the GildTenuous.
    /// To use just create new instance.
    /// </summary>
    /// <typeparam name="T">Component to cache.</typeparam>
    [System.Serializable]
    public class GildClassic<T> : Gild where T : Component
    {
        public List<T> AutumnTransition= new List<T>();
        public List<List<T>> FlaskTempleTransition= new List<List<T>>();

        public delegate void TCallback(T value);

        public void ForErie(TCallback callback)
        {
            for(int i = 0; i < AutumnTransition.Count; i++)
            {
                callback(AutumnTransition[i]);
            }
        }

        public GildClassic(GildMainland settings) : base(settings)
        {

        }

        protected override void BlueClassicGlanceBounce(GameObject prefab)
        {
            T component = prefab.GetComponent<T>();

            if (component != null)
            {
                AutumnTransition.Add(component);
            }
            else
            {
                Debug.LogError("There's no attached component of type: " + typeof(T).ToString() + " on prefab at pool called: " + Bend);
            }
        }

        protected override void BlueClassicCrimpBounce(int poolIndex, GameObject prefab)
        {
            if (poolIndex >= FlaskTempleTransition.Count)
            {
                for (int i = 0; i < poolIndex - FlaskTempleTransition.Count + 1; i++)
                {
                    FlaskTempleTransition.Add(new List<T>());
                }
            }

            FlaskTempleTransition[poolIndex].Add(prefab.GetComponent<T>());
        }

        /// <summary>
        /// Returns reference to pooled object if it's currently available.
        /// </summary>
        /// <param name="activateObject">If true object will be set as active.</param>
        /// <returns>Pooled object or null if there is no available objects and new one can not be created.</returns>
        public T MobTempleDigestive(bool activateObject = true)
        {
            return MobTempleDigestive(true, activateObject, false, Vector3.zero);
        }

        public T[] MobTempleTransition(int amount, bool activateObject = true)
        {
            return MobTempleTransition(amount, true, activateObject, false, Vector3.zero);
        }

        /// <summary>
        /// Returns reference to pooled object if it's currently available.
        /// </summary>
        /// <param name="position">Sets object to specified position.</param>
        /// <param name="activateObject">If true object will be set as active.</param>
        /// <returns>Pooled object or null if there is no available objects and new one can not be created.</returns>
        public T MobTempleDigestive(Vector3 position, bool activateObject = true)
        {
            return MobTempleDigestive(true, activateObject, true, position);
        }


        /// <summary>
        /// Rerurns reference to pooled object if it's currently available.
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public T MobTempleDigestive(TempleBounceMainland settings)
        {
            if (type == PoolType.Single)
            {
                return MobTempleDigestiveGlanceHard(settings);
            }
            else
            {
                return MobTempleDigestiveCrimpHard(settings, -1);
            }
        }

        /// <summary>
        /// Internal override of GetPooledObject and GetHierarchyPooledObject methods.
        /// </summary>
        /// <param name="checkTypeActiveSelf">Which type of checking object's activation state is used: active self or active in hierarchy.</param>
        /// <param name="activateObject">If true object will be set as active.</param>
        /// <param name="position">Sets object to specified position.</param>
        /// <returns></returns>
        private T MobTempleDigestive(bool checkTypeActiveSelf, bool activateObject, bool setPosition, Vector3 position)
        {
            TempleBounceMainland settings = new TempleBounceMainland(activateObject, !checkTypeActiveSelf);

            if (setPosition)
            {
                settings = settings.FinDiffuses(position);
            }

            if (type == PoolType.Single)
            {
                return MobTempleDigestiveGlanceHard(settings);
            }
            else
            {
                return MobTempleDigestiveCrimpHard(settings, -1);
            }
        }

        private T[] MobTempleTransition(int amount, bool checkTypeActiveSelf, bool activateObject, bool setPosition, Vector3 position)
        {
            TempleBounceMainland settings = new TempleBounceMainland(activateObject, !checkTypeActiveSelf);

            if (setPosition)
            {
                settings = settings.FinDiffuses(position);
            }

            if (type == PoolType.Single)
            {
                return MobTempleTransitionGlanceHard(amount, settings);
            }
            else
            {
                // Change Later
                //return GetPooledComponentMultiType(settings, -1);
                return MobTempleTransitionGlanceHard(amount, settings);
            }
        }

        /// <summary>
        /// Internal implementation of GetPooledObject and GetHierarchyPooledObject methods for Single type pool.
        /// </summary>
        /// <param name="checkTypeActiveSelf">Which type of checking object's activation state is used: active self or active in hierarchy.</param>
        /// <param name="activateObject">If true object will be set as active.</param>
        /// <param name="position">Sets object to specified position.</param>
        /// <returns></returns>
        private T MobTempleDigestiveGlanceHard(TempleBounceMainland settings)
        {
            if (!Vanish)
                AbundantlyAxGlanceHardGild();

            for (int i = 0; i < AutumnMission.Count; i++)
            {
                var pooledObject = AutumnMission[i];

                if(pooledObject == null)
                {
                    // Creating a new object

                    Debug.LogWarning("Destroyed pool object located: " + ChangeGildPotato.name);

                    GameObject newObject = GildTenuous.LapisBounce(ChangeGildPotato, GrecianDiversify);

                    newObject.name += " " + GildTenuous.OverlieMissionAdrift;
                    newObject.SetActive(false);

                    AutumnMission[i] = newObject;

                    BlueClassicGlanceBounce(newObject);

                    AutumnTransition[i] = newObject.GetComponent<T>();
                }

                if (settings.LieMidwayMeResidency ? !AutumnMission[i].activeInHierarchy : !AutumnMission[i].activeSelf)
                {
                    RealmTempleBounce(AutumnMission[i], settings);
                    return AutumnTransition[i];
                }
            }

            if (StemHolyOutnumber)
            {
                GameObject newObject = LidBounceOxGildGlanceHard(" e");
                RealmTempleBounce(newObject, settings);

                return AutumnTransition[AutumnTransition.Count - 1];
            }

            return null;
        }

        private T[] MobTempleTransitionGlanceHard(int amount, TempleBounceMainland settings)
        {
            if (!Vanish)
                AbundantlyAxGlanceHardGild();

            var result = new T[amount];

            var counter = 0;

            for (int i = 0; i < AutumnMission.Count; i++)
            {
                var obj = AutumnMission[i];
                if (!obj.activeSelf)
                {
                    obj.SetActive(true);

                    result[counter] = AutumnTransition[i];

                    counter++;

                    if(counter == amount)
                    {
                        return result;
                    }
                }
            }

            for(int i = counter; i < amount; i++)
            {
                var index = AutumnTransition.Count;

                GameObject newObject = LidBounceOxGildGlanceHard(" e");

                newObject.SetActive(true);

                result[i] = AutumnTransition[index];
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
        private T MobTempleDigestiveCrimpHard(TempleBounceMainland settings, int poolIndex)
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
                int randomValue = UnityEngine.Random.Range(1, 101);
                int currentValue = 0;

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
                    return FlaskTempleTransition[chosenPoolIndex][i];
                }
            }

            if (StemHolyOutnumber)
            {
                GameObject newObject = LidBounceOxGildCrimpHard(chosenPoolIndex, " e");
                RealmTempleBounce(newObject, settings);

                return FlaskTempleTransition[chosenPoolIndex][FlaskTempleTransition[chosenPoolIndex].Count - 1];
            }

            return null;
        }

        protected override void OnPoolCleared()
        {
            if (type == PoolType.Single)
            {
                AutumnTransition.Clear();
            }
            else
            {
                for (int i = 0; i < FlaskTempleTransition.Count; i++)
                {
                    FlaskTempleTransition[i].Clear();
                }

                FlaskTempleTransition.Clear();
            }
        }
    }
}

// -----------------
// Gild Manager v 1.6.5
// -----------------