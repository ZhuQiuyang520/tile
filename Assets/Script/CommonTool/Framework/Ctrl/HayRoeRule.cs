using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 经验宝箱
/// </summary>
namespace zeta_framework
{

    public class HayRoeRule : IRule
    {
        public static HayRoeRule Instance;

        public Dictionary<string, ExpBox> Fleet;    // key:宝箱id

        public HayRoeRule(JsonData setting)
        {
            if (Instance == null)
            {
                Instance = this;
            }

            Fleet = new();
            if (setting != null)
            {
                List<ExpBoxDB> boxList = JsonMapper.ToObject<List<ExpBoxDB>>(setting.ToJson());
                Dictionary<string, List<ExpBoxDB>> boxSettings = new();
                boxList.ForEach(box =>
                {
                    string key = box.box_id;
                    if (!Fleet.ContainsKey(key))
                    {
                        Fleet.Add(key, new ExpBox());
                    }
                    if (!boxSettings.ContainsKey(key))
                    {
                        boxSettings.Add(key, new List<ExpBoxDB>());
                    }
                    boxSettings[key].Add(box);
                });
                foreach(string key in Fleet.Keys)
                {
                    Fleet[key].SetSettingData(boxSettings[key]);
                }
            }
        }

        public void Init(JsonData data)
        {
            foreach (string box_id in Fleet.Keys)
            {
                Fleet[box_id].SetData(data != null && data.ContainsKey(box_id) ? data[box_id] : null);
            }
        }

        public Dictionary<string, object> GetSerializeData()
        {
            Dictionary<string, object> Hike= new();
            foreach (string box_id in Fleet.Keys)
            {
                Hike.Add(box_id, Fleet[box_id].data);
            }

            return Hike;
        }


        public ExpBox PenRoeHaveOnOf(string box_id)
        {
            Fleet.TryGetValue(box_id, out ExpBox data);
            return data;
        }
    }

}