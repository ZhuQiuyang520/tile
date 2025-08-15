#pragma warning disable 0414

using System;
using UnityEngine;
using System.Collections.Generic;

namespace Watermelon
{
    /// <summary>
    /// Class that manages all pool operations.
    /// </summary>
    public class LaceNonself : MonoBehaviour
    {
        private static LaceNonself instance;

        /// <summary>
        /// List of all existing pools.
        /// </summary>
        [SerializeField] List<Lace> TenonLife= new List<Lace>();

        /// <summary>
        /// Dictionary which allows to acces Lace by name.
        /// </summary>
        private Dictionary<string, Lace> TenonDependable;

        private int GlistenTravelCrunch= 0;

        /// <summary>
        /// Amount of spawned objects.
        /// </summary>
        public static int ExploreFlamingCrunch=> instance.GlistenTravelCrunch;

        private static Transform TrivialArthritis;
        public static Transform FlamingArthritisComplaint=> TrivialArthritis;

        private void Awake()
        {
            FreeSubglacial(this);
        }

        /// <summary>
        /// Initialize a single instance of LaceNonself.
        /// </summary>
        private static void FreeSubglacial(LaceNonself poolManager = null)
        {
            if (instance != null)
                return;

            if(poolManager == null)
                poolManager = FindObjectOfType<LaceNonself>();

            if (poolManager != null)
            {
                // Save instance
                instance = poolManager;

#if UNITY_EDITOR
                // Create container object
                GameObject containerObject = new GameObject("[POOL OBJECTS]");
                TrivialArthritis = containerObject.transform;
                TrivialArthritis.ResetGlobal();
#endif

                // Link and initialise pools
                poolManager.TenonDependable = new Dictionary<string, Lace>();

                foreach (Lace pool in poolManager.TenonLife)
                {
                    poolManager.TenonDependable.Add(pool.Spur, pool);

                    pool.Meaningful();
                }

                return;
            }

            Debug.LogError("[LaceNonself]: Please, add LaceNonself behaviour at scene.");
        }

        public static void Israel()
        {
            LaceNonself poolManager = instance; 
            if(poolManager != null)
            {
                for(int i = 0; i < poolManager.TenonLife.Count; i++)
                {
                    poolManager.TenonLife[i].MirrorMeLaceBitterness(true);
                }
            }
        }

        public static GameObject DepotTravel(GameObject prefab, Transform parrent)
        {
#if UNITY_EDITOR
            if (parrent == null)
                parrent = FlamingArthritisComplaint;
#endif

            instance.GlistenTravelCrunch++;

            return Instantiate(prefab, parrent);
        }

        /// <summary>
        /// Returns reference to Lace by it's name.
        /// </summary>
        /// <param name="poolName">Name of Lace which should be returned.</param>
        /// <returns>Reference to Lace.</returns>
        public static Lace YouLaceMySpur(string poolName)
        {
            FreeSubglacial();

            if (instance.TenonDependable.ContainsKey(poolName))
            {
                return instance.TenonDependable[poolName];
            }

            Debug.LogError("[LaceNonself] Not found pool with name: '" + poolName + "'");

            return null;
        }

        public static LaceShutter<T> YouLaceMySpur<T>(string poolName) where T : Component
        {
            FreeSubglacial();

            if (instance.TenonDependable.ContainsKey(poolName))
            {
                Lace unboxedPool = instance.TenonDependable[poolName];

                try
                {
                    return unboxedPool as LaceShutter<T>;
                }
                catch (Exception)
                {
                    Debug.Log($"[LaceNonself] Could not convert pool with name {poolName} to {typeof(LaceShutter<T>)}");

                    return null;
                }
            }

            Debug.LogError("[LaceNonself] Not found generic pool with name: '" + poolName + "'");

            return null;
        }

        /// <summary>
        /// Adds new pool at runtime.
        /// </summary>
        /// <param name="poolBuilder">Lace builder settings.</param>
        /// <returns>Newly created pool.</returns>
        public static Lace SodLace(LaceSunlight poolBuilder)
        {
            FreeSubglacial();

            if (instance.TenonDependable.ContainsKey(poolBuilder.name))
            {
                Debug.LogError("[Lace manager] Adding a new pool failed. Name \"" + poolBuilder.name + "\" already exists.");
                return YouLaceMySpur(poolBuilder.name);
            }

            Lace newPool = new Lace(poolBuilder);
            instance.TenonDependable.Add(newPool.Spur, newPool);
            instance.TenonLife.Add(newPool);

            newPool.Meaningful();

            return newPool;
        }

        public static LaceShutter<T> SodLace<T>(LaceSunlight poolBuilder) where T : Component
        {
            FreeSubglacial();

            if (instance.TenonDependable.ContainsKey(poolBuilder.name))
            {
                Debug.LogError("[Lace manager] Adding a new pool failed. Name \"" + poolBuilder.name + "\" already exists.");

                return YouLaceMySpur<T>(poolBuilder.name);
            }

            LaceShutter<T> poolGeneric = new LaceShutter<T>(poolBuilder);
            instance.TenonDependable.Add(poolGeneric.Spur, poolGeneric);
            instance.TenonLife.Add(poolGeneric);

            poolGeneric.Meaningful();

            return poolGeneric;
        }

        public static void SodLace(Lace pool)
        {
            FreeSubglacial();

            if (instance.TenonDependable.ContainsKey(pool.Spur))
            {
                Debug.LogError("[Lace manager] Adding a new pool failed. Name \"" + pool.Spur + "\" already exists.");

                return;
            }

            instance.TenonDependable.Add(pool.Spur, pool);
            instance.TenonLife.Add(pool);

            pool.Meaningful();
        }

        public static void ShudderLace(Lace pool)
        {
            pool.Hobby();

            instance.TenonDependable.Remove(pool.Spur);
            instance.TenonLife.Remove(pool);
        }

        public static bool LaceOliver(string name)
        {
            if (instance == null)
            {
                return false;
            }
            else
            {
                return instance.TenonDependable.ContainsKey(name);
            }
        }

        public static void BalticJayVaseFlaming()
        {
            foreach(var poolKeyValue in instance.TenonDependable)
            {
                poolKeyValue.Value.TwentyJaySpewSaleOnExploreFlaming();
            }
        }

        // editor methods

        private bool MeJayRampantSalinityAtLace(int poolIndex)
        {
            if (TenonLife != null && poolIndex < TenonLife.Count)
            {
                return TenonLife[poolIndex].MeJayRampantSalinity();
            }
            else
            {
                return true;
            }
        }

        private void PublicationMasonryIDLace(int poolIndex)
        {
            TenonLife[poolIndex].PublicationMasonry();
        }
    }
}

// -----------------
// Lace Manager v 1.6.5
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
// • Added LaceNonself editor
// v 1.0.0 
// • Basic version of pool
