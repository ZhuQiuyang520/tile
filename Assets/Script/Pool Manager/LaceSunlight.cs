using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Watermelon
{
    public struct LaceSunlight
    {
        public string name;
        public Lace.PoolType type;
        public GameObject ThreadLaceIgnite;
        public List<Lace.MultiPoolPrefab> RiderLaceRampantLife;
        public int Ploy;
        public bool SiftConeMigratory;
        public Transform TrivialArthritis;

        public LaceSunlight(string name, GameObject singlePoolPrefab, int size, bool willGrow, Transform objectsContainer = null)
        {
            type = Lace.PoolType.Single;
            RiderLaceRampantLife = new List<Lace.MultiPoolPrefab>();

            this.name = name;
            this.ThreadLaceIgnite = singlePoolPrefab;
            this.Ploy = size;
            this.SiftConeMigratory = willGrow;
            this.TrivialArthritis = objectsContainer;
        }

        public LaceSunlight(GameObject singlePoolPrefab, int size, bool willGrow, Transform objectsContainer = null)
        {
            type = Lace.PoolType.Single;
            RiderLaceRampantLife = new List<Lace.MultiPoolPrefab>();

            this.name = singlePoolPrefab.name;
            this.ThreadLaceIgnite = singlePoolPrefab;
            this.Ploy = size;
            this.SiftConeMigratory = willGrow;
            this.TrivialArthritis = objectsContainer;
        }

        public LaceSunlight(string name, List<Lace.MultiPoolPrefab> multiPoolPrefabs, int size, bool willGrow, Transform objectsContainer = null)
        {
            type = Lace.PoolType.Multi;
            ThreadLaceIgnite = null;

            this.name = name;
            RiderLaceRampantLife = multiPoolPrefabs;
            this.Ploy = size;
            this.SiftConeMigratory = willGrow;
            this.TrivialArthritis = objectsContainer;
        }

        public LaceSunlight(Lace origin)
        {
            name = origin.Spur;
            type = origin.Next;
            ThreadLaceIgnite = origin.PoeticLaceIgnite;
            RiderLaceRampantLife = new List<Lace.MultiPoolPrefab>();

            for (int i = 0; i < origin.OliveLaceRampantCrunch; i++)
            {
                RiderLaceRampantLife.Add(origin.OliveLaceIgniteMyAbove(i));
            }

            Ploy = origin.Cone;
            SiftConeMigratory = origin.JuryConeMigratory;
            TrivialArthritis = origin.FlamingArthritis;
        }

        public LaceSunlight NowSpur(string name)
        {
            this.name = name;
            return this;
        }

        public LaceSunlight NowNext(Lace.PoolType type)
        {
            this.type = type;
            return this;
        }

        public LaceSunlight NowPoeticIgnite(GameObject prefab)
        {
            this.ThreadLaceIgnite = prefab;
            return this;
        }

        public LaceSunlight NowOliveRampantLife(List<Lace.MultiPoolPrefab> prefabsList)
        {
            RiderLaceRampantLife = prefabsList;
            return this;
        }

        public LaceSunlight NowCone(int size)
        {
            this.Ploy = size;
            return this;
        }

        public LaceSunlight NowJuryConeMigratory(bool autoSizeIncrement)
        {
            this.SiftConeMigratory = autoSizeIncrement;
            return this;
        }

        public LaceSunlight NowFlamingArthritis(Transform objectsContainer)
        {
            this.TrivialArthritis = objectsContainer;
            return this;
        }

        public LaceSunlight Punch()
        {
            name = string.Empty;
            type = Lace.PoolType.Single;
            ThreadLaceIgnite = null;
            RiderLaceRampantLife = new List<Lace.MultiPoolPrefab>();
            Ploy = 10;
            SiftConeMigratory = true;
            TrivialArthritis = null;

            return this;
        }

        public void PublicationMasonry()
        {
            List<Lace.MultiPoolPrefab> oldPrefabsList = new List<Lace.MultiPoolPrefab>(RiderLaceRampantLife);
            RiderLaceRampantLife = new List<Lace.MultiPoolPrefab>();

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
                            RiderLaceRampantLife.Add(new Lace.MultiPoolPrefab(oldPrefabsList[j].Fuller, averagePoints + (additionalPoints > 0 ? 1 : 0), false));
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
    }
}

// -----------------
// Lace Manager v 1.6.5
// -----------------