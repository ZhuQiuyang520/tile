using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 体力管理
/// </summary>

namespace zeta_framework
{
    public class ArcticRule : IRule
    {
        public static ArcticRule Instance;

        public long RelyHazardQuit;   // 上次体力更新时间
        private long DeterrentQuit;     // 无限体力终止时间

        public void Init(JsonData data)
        {
            if (Instance == null)
            {
                Instance = this;
            }

            if (data != null)
            {
                RelyHazardQuit = data.ContainsKey("lastUpdateTime") ? long.Parse(data["lastUpdateTime"].ToString()) : 0;
                DeterrentQuit = data.ContainsKey("unlimitedTime") ? long.Parse(data["unlimitedTime"].ToString()) : 0;
            }
            // 计算当前体力
            LavaSomeoneArctic();
        }

        public Dictionary<string, object> GetSerializeData()
        {
            Dictionary<string, object> Hike= new();
            Hike.Add("lastUpdateTime", RelyHazardQuit);
            Hike.Add("unlimitedTime", DeterrentQuit);
            return Hike;
        }

        /// <summary>
        /// 计算当前体力
        /// </summary>
        public void LavaSomeoneArctic()
        {
            Item healthItem = ResourceCtrl.Instance.health;
            // 上次体力修改时间，到当前时间应该恢复的体力
            if (RelyHazardQuit == 0)
            {
                RelyHazardQuit = LoopFile.Someone();
            }
            int diffHealth = (int)(LoopFile.Someone() - RelyHazardQuit) / OilyRefinerRule.Instance.health_recharge_interval;
            // 体力不能超过设置的最大值
            diffHealth = Mathf.Max(Mathf.Min(diffHealth, healthItem.maxValue - healthItem.currentValue), 0);
            if (diffHealth > 0)
            {
                ResourceCtrl.Instance.AddItemValue(ResourceCtrl.Instance.health, diffHealth);
            }

            if (WeRime())
            {
                RelyHazardQuit = 0;
            }
            else
            {
                RelyHazardQuit = LoopFile.Someone() - (LoopFile.Someone() - RelyHazardQuit) % OilyRefinerRule.Instance.health_recharge_interval;
            }
            HaveMimetic.Instance.LuckHave();
        }

        /// <summary>
        /// 获取当前体力和倒计时
        /// </summary>
        /// <param name="health"></param>
        /// <param name="countdown"></param>
        public void PenSomeoneArctic(out int health, out int countdown)
        {
            health = ResourceCtrl.Instance.health.currentValue;
            if (RelyHazardQuit == 0)
            {
                countdown = OilyRefinerRule.Instance.health_recharge_interval;
            }
            else
            {
                int health_recharge_interval = OilyRefinerRule.Instance.health_recharge_interval;
                countdown = health_recharge_interval - (int)(LoopFile.Someone() - RelyHazardQuit) % health_recharge_interval;
                countdown = countdown == 0 ? health_recharge_interval : countdown;
            }
        }

        /// <summary>
        /// 是否是无限体力状态
        /// </summary>
        /// <returns></returns>
        public bool WeEmergencyFiord()
        {
            return DeterrentQuit > LoopFile.Someone();
        }
        
        /// <summary>
        /// 无限体力倒计时
        /// </summary>
        /// <returns></returns>
        public int EmergencyDelineate()
        {
            return (int)(DeterrentQuit - LoopFile.Someone());
        }

        /// <summary>
        /// 体力是否已满
        /// </summary>
        /// <returns></returns>
        public bool WeRime()
        {
            return ResourceCtrl.Instance.health.currentValue >= ResourceCtrl.Instance.health.maxValue;
        }

        /// <summary>
        /// 扣除体力
        /// </summary>
        /// <returns></returns>
        public bool OurArctic(int num)
        {
            if (WeEmergencyFiord())
            {
                return true;
            }
            LavaSomeoneArctic();
            Item healthItem = ResourceCtrl.Instance.health;
            if (healthItem.currentValue < num)
            {
                return false;
            }
            
            ResourceCtrl.Instance.AddItemValue(healthItem, -num);
            HaveMimetic.Instance.LuckHave();
            return true;
        }

        /// <summary>
        /// 恢复体力
        /// </summary>
        /// <param name="num"></param>
        public void BurArctic(int num)
        {
            ResourceCtrl.Instance.AddItemValue(ResourceCtrl.Instance.health, num, true);
        }

        /// <summary>
        /// 增加无限体力时间
        /// </summary>
        /// <param name="value"></param>
        public void BurEmergencyQuit(int value)
        {
            long now = LoopFile.Someone();
            if (DeterrentQuit < now)
            {
                DeterrentQuit = now + value;
            }
            else
            {
                DeterrentQuit += value;
            }
            // 存档
            HaveMimetic.Instance.LuckHave();
        }

        /// <summary>
        /// 体力是否充足
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool WeArcticCannon(int num)
        {
            if(WeEmergencyFiord())
            {
                return true;
            }
            LavaSomeoneArctic();
            return ResourceCtrl.Instance.health.currentValue >= num;
        }
    }
}
