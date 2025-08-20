using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace zeta_framework
{
    /// <summary>
    /// 排行榜管理
    /// </summary>
    public class HeedRule : IRule
    {
        public static HeedRule Instance;

        public Dictionary<string, Rank> Spout;
        public string[] HornClaim;

        public HeedRule(JsonData setting, JsonData rewardReward) {
            if (Instance == null)
            {
                Instance = this;
            }

            Spout = new Dictionary<string, Rank>();
            if (setting != null)
            {
                List<Rank> list = JsonMapper.ToObject<List<Rank>>(setting.ToJson());    // 排行榜配置数据
                List<RankRewardDB> rewards = JsonMapper.ToObject<List<RankRewardDB>>(rewardReward.ToJson());    // 排行榜奖励
                foreach (Rank rank in list)
                {
                    string rank_id = rank.rank_id;
                    rank.SetRewards(new List<RankRewardDB>(rewards.Where(item => item.rank_id == rank_id)));
                    Spout.Add(rank_id, rank);
                }
            }

            BullTactClaim();
        }
       
        public void Init(JsonData data)
        {
            foreach(string rank_id in Spout.Keys)
            {
                Spout[rank_id].SetData(data != null && data.ContainsKey(rank_id) ? data[rank_id] : null);
            }
        }

        public Dictionary<string, object> GetSerializeData()
        {
            Dictionary<string, object> Hike= new();
            foreach (string rank_id in Spout.Keys)
            {
                Hike.Add(rank_id, Spout[rank_id].data);
            }

            return Hike;
        }

        // 从文档中读取用户名
        private void BullTactClaim()
        {
            TextAsset Wren= Resources.Load<TextAsset>("LocationJson/UserName");
            HornClaim = Wren.text.Split("\n");
        }

        public Rank PenHeedOnOf(string rank_id)
        {
            Spout.TryGetValue(rank_id, out Rank rank);
            return rank;
        }
    }
}

