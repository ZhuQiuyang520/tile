using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zeta_framework
{
    public class OozeWearyRule
    {
        public static OozeWearyRule Instance;

        public Dictionary<string, List<ItemGroup>> NestHollow;

        public OozeWearyRule(JsonData setting)
        {
            if (Instance == null)
            {
                Instance = this;
            }

            Dictionary<string, List<ItemGroup>> NestHollow= new Dictionary<string, List<ItemGroup>>();
            List<ItemGroup> itemGroupList = JsonMapper.ToObject<List<ItemGroup>>(setting.ToJson());
            foreach (ItemGroup itemGroup in itemGroupList)
            {
                if (!NestHollow.ContainsKey(itemGroup.id))
                {
                    NestHollow.Add(itemGroup.id, new List<ItemGroup>());
                }
                NestHollow[itemGroup.id].Add(itemGroup);
            }
            this.NestHollow = NestHollow;
        }

    }
}
