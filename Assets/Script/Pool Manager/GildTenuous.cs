#pragma warning disable 0414

using System;
using UnityEngine;
using System.Collections.Generic;

namespace Watermelon
{
    /// <summary>
    /// Class that manages all pool operations.
    /// </summary>
    public class GildTenuous : MonoBehaviour
    {
        private static GildTenuous instance;

        /// <summary>
        /// List of all existing pools.
        /// </summary>
        [SerializeField] List<Gild> FluidFire= new List<Gild>();

        /// <summary>
        /// Dictionary which allows to acces Gild by name.
        /// </summary>
        private Dictionary<string, Gild> FluidWorthwhile;

        private int CircuitBounceAdrift= 0;

        /// <summary>
        /// Amount of spawned objects.
        /// </summary>
        public static int OverlieMissionAdrift=> instance.CircuitBounceAdrift;

        private static Transform GrecianDiversify;
        public static Transform MissionDiversifyGenuinely=> GrecianDiversify;

        private void Awake()
        {
            BluePredispose(this);
        }

        /// <summary>
        /// Initialize a single instance of GildTenuous.
        /// </summary>
        private static void BluePredispose(GildTenuous poolManager = null)
        {
            if (instance != null)
                return;

            if(poolManager == null)
                poolManager = FindObjectOfType<GildTenuous>();

            if (poolManager != null)
            {
                // Save instance
                instance = poolManager;

#if UNITY_EDITOR
                // Create container object
                GameObject containerObject = new GameObject("[POOL OBJECTS]");
                GrecianDiversify = containerObject.transform;
                GrecianDiversify.ResetGlobal();
#endif

                // Link and initialise pools
                poolManager.FluidWorthwhile = new Dictionary<string, Gild>();

                foreach (Gild pool in poolManager.FluidFire)
                {
                    poolManager.FluidWorthwhile.Add(pool.Bend, pool);

                    pool.Abundantly();
                }

                return;
            }

            Debug.LogError("[GildTenuous]: Please, add GildTenuous behaviour at scene.");
        }

        public static void Social()
        {
            GildTenuous poolManager = instance; 
            if(poolManager != null)
            {
                for(int i = 0; i < poolManager.FluidFire.Count; i++)
                {
                    poolManager.FluidFire[i].RecoilOxGildCurriculum(true);
                }
            }
        }

        public static GameObject LapisBounce(GameObject prefab, Transform parrent)
        {
#if UNITY_EDITOR
            if (parrent == null)
                parrent = MissionDiversifyGenuinely;
#endif

            instance.CircuitBounceAdrift++;

            return Instantiate(prefab, parrent);
        }

        /// <summary>
        /// Returns reference to Gild by it's name.
        /// </summary>
        /// <param name="poolName">Name of Gild which should be returned.</param>
        /// <returns>Reference to Gild.</returns>
        public static Gild MobGildUpBend(string poolName)
        {
            BluePredispose();

            if (instance.FluidWorthwhile.ContainsKey(poolName))
            {
                return instance.FluidWorthwhile[poolName];
            }

            Debug.LogError("[GildTenuous] Not found pool with name: '" + poolName + "'");

            return null;
        }

        public static GildClassic<T> MobGildUpBend<T>(string poolName) where T : Component
        {
            BluePredispose();

            if (instance.FluidWorthwhile.ContainsKey(poolName))
            {
                Gild unboxedPool = instance.FluidWorthwhile[poolName];

                try
                {
                    return unboxedPool as GildClassic<T>;
                }
                catch (Exception)
                {
                    Debug.Log($"[GildTenuous] Could not convert pool with name {poolName} to {typeof(GildClassic<T>)}");

                    return null;
                }
            }

            Debug.LogError("[GildTenuous] Not found generic pool with name: '" + poolName + "'");

            return null;
        }

        /// <summary>
        /// Adds new pool at runtime.
        /// </summary>
        /// <param name="poolBuilder">Gild builder settings.</param>
        /// <returns>Newly created pool.</returns>
        public static Gild LidGild(GildMainland poolBuilder)
        {
            BluePredispose();

            if (instance.FluidWorthwhile.ContainsKey(poolBuilder.name))
            {
                Debug.LogError("[Gild manager] Adding a new pool failed. Name \"" + poolBuilder.name + "\" already exists.");
                return MobGildUpBend(poolBuilder.name);
            }

            Gild newPool = new Gild(poolBuilder);
            instance.FluidWorthwhile.Add(newPool.Bend, newPool);
            instance.FluidFire.Add(newPool);

            newPool.Abundantly();

            return newPool;
        }

        public static GildClassic<T> LidGild<T>(GildMainland poolBuilder) where T : Component
        {
            BluePredispose();

            if (instance.FluidWorthwhile.ContainsKey(poolBuilder.name))
            {
                Debug.LogError("[Gild manager] Adding a new pool failed. Name \"" + poolBuilder.name + "\" already exists.");

                return MobGildUpBend<T>(poolBuilder.name);
            }

            GildClassic<T> poolGeneric = new GildClassic<T>(poolBuilder);
            instance.FluidWorthwhile.Add(poolGeneric.Bend, poolGeneric);
            instance.FluidFire.Add(poolGeneric);

            poolGeneric.Abundantly();

            return poolGeneric;
        }

        public static void LidGild(Gild pool)
        {
            BluePredispose();

            if (instance.FluidWorthwhile.ContainsKey(pool.Bend))
            {
                Debug.LogError("[Gild manager] Adding a new pool failed. Name \"" + pool.Bend + "\" already exists.");

                return;
            }

            instance.FluidWorthwhile.Add(pool.Bend, pool);
            instance.FluidFire.Add(pool);

            pool.Abundantly();
        }

        public static void BushmanGild(Gild pool)
        {
            pool.Cliff();

            instance.FluidWorthwhile.Remove(pool.Bend);
            instance.FluidFire.Remove(pool);
        }

        public static bool GildImpair(string name)
        {
            if (instance == null)
            {
                return false;
            }
            else
            {
                return instance.FluidWorthwhile.ContainsKey(name);
            }
        }

        public static void ObtainWadSpewMission()
        {
            foreach(var poolKeyValue in instance.FluidWorthwhile)
            {
                poolKeyValue.Value.CandidWadSpewCuteGoOverlieMission();
            }
        }

        // editor methods

        private bool OfWadOnenessSuitableAtGild(int poolIndex)
        {
            if (FluidFire != null && poolIndex < FluidFire.Count)
            {
                return FluidFire[poolIndex].OfWadOnenessSuitable();
            }
            else
            {
                return true;
            }
        }

        private void AcquisitionTheaterIDGild(int poolIndex)
        {
            FluidFire[poolIndex].AcquisitionTheater();
        }
    }
}

// -----------------
// Gild Manager v 1.6.5
// -----------------

// Changelog
// v 1.6.5
// • Removed Initialise method
// • Now manager works as Singleton
// • Added generic AddPool method
// v 1.6.4
// • Added pro theme support
// v 1.6 
// • Added runtime pool creation
// • Added extended functions for multi pool
// • Added new pool constructor and GetPooledObject overrides
// • Generic pool upgate
// • Added clear method to pool
// v 1.5.1 
// • Added Multi objects pool type
// • Added drag n drop support
// v 1.4.5  
// • Added editor changes save
// • Updated cache system
// • Added ability to ignore cache for required pools
// • Fixed created object's names
// • Core refactoring
// • Editor UX improvements
// v 1.3.1  
// • Added RandomPools system
// • Added objectsContainer access property
// v 1.2.1 
// • Added cache system
// • Fixed errors on build
// v 1.1.0 
// • Added GildTenuous editor
// v 1.0.0 
// • Basic version of pool
