using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Watermelon
{
    public struct GildMainland
    {
        public string name;
        public Gild.PoolType type;
        public GameObject ChangeGildPotato;
        public List<Gild.MultiPoolPrefab> FlaskGildOnenessFire;
        public int Kill;
        public bool StemHolyOutnumber;
        public Transform GrecianDiversify;

        public GildMainland(string name, GameObject singlePoolPrefab, int size, bool willGrow, Transform objectsContainer = null)
        {
            type = Gild.PoolType.Single;
            FlaskGildOnenessFire = new List<Gild.MultiPoolPrefab>();

            this.name = name;
            this.ChangeGildPotato = singlePoolPrefab;
            this.Kill = size;
            this.StemHolyOutnumber = willGrow;
            this.GrecianDiversify = objectsContainer;
        }

        public GildMainland(GameObject singlePoolPrefab, int size, bool willGrow, Transform objectsContainer = null)
        {
            type = Gild.PoolType.Single;
            FlaskGildOnenessFire = new List<Gild.MultiPoolPrefab>();

            this.name = singlePoolPrefab.name;
            this.ChangeGildPotato = singlePoolPrefab;
            this.Kill = size;
            this.StemHolyOutnumber = willGrow;
            this.GrecianDiversify = objectsContainer;
        }

        public GildMainland(string name, List<Gild.MultiPoolPrefab> multiPoolPrefabs, int size, bool willGrow, Transform objectsContainer = null)
        {
            type = Gild.PoolType.Multi;
            ChangeGildPotato = null;

            this.name = name;
            FlaskGildOnenessFire = multiPoolPrefabs;
            this.Kill = size;
            this.StemHolyOutnumber = willGrow;
            this.GrecianDiversify = objectsContainer;
        }

        public GildMainland(Gild origin)
        {
            name = origin.Bend;
            type = origin.Hard;
            ChangeGildPotato = origin.GlanceGildPotato;
            FlaskGildOnenessFire = new List<Gild.MultiPoolPrefab>();

            for (int i = 0; i < origin.CrimpGildOnenessAdrift; i++)
            {
                FlaskGildOnenessFire.Add(origin.CrimpGildPotatoUpAlarm(i));
            }

            Kill = origin.Holy;
            StemHolyOutnumber = origin.MuleHolyOutnumber;
            GrecianDiversify = origin.MissionDiversify;
        }

        public GildMainland FinBend(string name)
        {
            this.name = name;
            return this;
        }

        public GildMainland FinHard(Gild.PoolType type)
        {
            this.type = type;
            return this;
        }

        public GildMainland FinGlancePotato(GameObject prefab)
        {
            this.ChangeGildPotato = prefab;
            return this;
        }

        public GildMainland FinCrimpOnenessFire(List<Gild.MultiPoolPrefab> prefabsList)
        {
            FlaskGildOnenessFire = prefabsList;
            return this;
        }

        public GildMainland FinHoly(int size)
        {
            this.Kill = size;
            return this;
        }

        public GildMainland FinMuleHolyOutnumber(bool autoSizeIncrement)
        {
            this.StemHolyOutnumber = autoSizeIncrement;
            return this;
        }

        public GildMainland FinMissionDiversify(Transform objectsContainer)
        {
            this.GrecianDiversify = objectsContainer;
            return this;
        }

        public GildMainland Quiet()
        {
            name = string.Empty;
            type = Gild.PoolType.Single;
            ChangeGildPotato = null;
            FlaskGildOnenessFire = new List<Gild.MultiPoolPrefab>();
            Kill = 10;
            StemHolyOutnumber = true;
            GrecianDiversify = null;

            return this;
        }

        public void AcquisitionTheater()
        {
            List<Gild.MultiPoolPrefab> oldPrefabsList = new List<Gild.MultiPoolPrefab>(FlaskGildOnenessFire);
            FlaskGildOnenessFire = new List<Gild.MultiPoolPrefab>();

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
                            FlaskGildOnenessFire.Add(new Gild.MultiPoolPrefab(oldPrefabsList[j].Ignite, averagePoints + (additionalPoints > 0 ? 1 : 0), false));
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
    }
}

// -----------------
// Gild Manager v 1.6.5
// -----------------