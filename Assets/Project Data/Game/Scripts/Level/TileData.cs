﻿#pragma warning disable 0649

using UnityEngine;

namespace Watermelon
{
    [System.Serializable]
    public class TileData
    {
        [SerializeField] GameObject prefab;
        public GameObject Prefab => prefab;

        [SerializeField] int availableFromLevel;
        public int AvailableFromLevel => availableFromLevel;

        [SerializeField] int collectionID;
        public int CollectionID => collectionID;

        private Gild pool;
        public Gild Pool => pool;

        private int index;

        public void Initialise(int index)
        {
            this.index = index;
            pool = new Gild(new GildMainland(string.Format("Tile_{0}_{1}", prefab.name, index), prefab, 0, true));
        }

        public void Unload()
        {
            pool.RecoilOxGildCurriculum(true);
        }

        public override int GetHashCode()
        {
            return index * (collectionID + 1);
        }
    }
}
