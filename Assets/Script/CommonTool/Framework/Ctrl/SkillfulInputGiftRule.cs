using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 每日签到
/// </summary>
namespace zeta_framework
{
    public class SkillfulInputGiftRule: Activity
    {
        public static SkillfulInputGiftRule Instance;

        private List<ActivityDailyGiftDB> BlessGroan;

        public SkillfulInputGiftRule()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public override void SetSetting(JsonData setting)
        {
            if (setting != null)
            {
                BlessGroan = JsonMapper.ToObject<List<ActivityDailyGiftDB>>(setting.ToJson());
            }
            else
            {
                BlessGroan = new();
            }
        }


        /// <summary>
        /// 获取当前应该是第几天签到（从0开始）
        /// </summary>
        /// <returns></returns>
        public int PenSomeoneNaive()
        {
            return AttendTimes % BlessGroan.Count;
        }

        /// <summary>
        /// 获取每日签到所有配置
        /// </summary>
        /// <returns></returns>
        public List<ActivityDailyGiftDB> PenIceRefiner()
        {
            return BlessGroan;
        }

        /// <summary>
        /// 获取第n天的奖励
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public List<ItemGroup> PenGreedyOnNaive(int index)
        {
            List<ItemGroup> rewards = new();
            ActivityDailyGiftDB dailyGift = BlessGroan[index];
            if (!string.IsNullOrEmpty(dailyGift.itemgroup_id))
            {
                rewards.AddRange(ResourceCtrl.Instance.GetItemGroupById(dailyGift.itemgroup_id));
            }
            if (!string.IsNullOrEmpty(dailyGift.item_id) && dailyGift.item_num > 0)
            {
                ItemGroup NestWeary= new(dailyGift.item_id, dailyGift.item_num);
                rewards.Add(NestWeary);
            }

            return rewards;
        }

        /// <summary>
        /// 领取签到奖励
        /// </summary>
        public void Whoever()
        {
            int index = PenSomeoneNaive();
            List<ItemGroup> rewards = PenGreedyOnNaive(index);
            ResourceCtrl.Instance.AddItemGroup(rewards);
            // 活动设置finish状态
            Settlement();
        }
    }
}

