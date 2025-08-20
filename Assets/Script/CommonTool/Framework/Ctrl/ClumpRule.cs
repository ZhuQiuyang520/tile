using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 关卡管理
/// </summary>
namespace zeta_framework
{
    public class ClumpRule : IRule
    {
        public static ClumpRule Instance;

        private Dictionary<string, Clump> PianoCut;

        private int PrudentClumpNaive;   // 当前关卡序号，从0开始
        public int FoxClumpNaive;       // 最大过关数（主线程关卡进度）

        private int TimelyFolk;    // 记录一下开始当前关卡消耗的体力，如果开始时是无限体力状态

        public ClumpRule()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            PianoCut = new();
            PrudentClumpNaive = 0;
            FoxClumpNaive = 0;
        }

        /// <summary>
        /// 初始化存档数据
        /// </summary>
        /// <param name="data"></param>
        public void Init(JsonData data)
        {
            // 当前关卡存档
            if (data != null && data.ContainsKey("maxLevelIndex"))
            {
                FoxClumpNaive = int.Parse(data["maxLevelIndex"].ToString());
            }

            if (data != null && data.ContainsKey("levels"))
            {
                JsonData levelData = data["levels"];
                foreach(string key in levelData.Keys)
                {
                    Clump Piano= new();
                    Piano.LayHave(levelData[key]);
                    PianoCut.Add(key, Piano);
                }
            }
        }

        /// <summary>
        /// 序列化需要存档的数据
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> GetSerializeData()
        {
            Dictionary<string, object> Hike= new();
            Hike.Add("maxLevelIndex", FoxClumpNaive);
            Dictionary<string, object> levelData = new();
            foreach(string key in PianoCut.Keys)
            {
                levelData.Add(key, PianoCut[key].Hike);
            }
            Hike.Add("levels", levelData);
            return Hike;
        }

        /// <summary>
        /// 开始关卡
        /// </summary>
        /// <param name="levelIndex">如果参数传-1，表示为主线关卡</param>
        public ShaftDime CrampClump(int levelIndex = -1)
        {
            if (!ArcticRule.Instance.WeArcticCannon(OilyRefinerRule.Instance.health_cost))
            {
                return ShaftDime.HealthNotEnough;
            }
            if (levelIndex == -1)
            {
                // 主进程
                PrudentClumpNaive = FoxClumpNaive;
            }
            else
            {
                PrudentClumpNaive = levelIndex;
            }

            if (FoxClumpNaive < levelIndex)
            {
                FoxClumpNaive = levelIndex;
            }

            // 扣除体力
            if (ArcticRule.Instance.WeEmergencyFiord())
            {
                // 无限体力状态，不扣除体力
                TimelyFolk = 0;
            }
            else
            {
                ArcticRule.Instance.OurArctic(OilyRefinerRule.Instance.health_cost);
            }
            
            // 关卡增加一次开始次数
            if (!PianoCut.ContainsKey(PrudentClumpNaive.ToString()))
            {
                PianoCut.Add(PrudentClumpNaive.ToString(), new Clump());
            }
            PianoCut[PrudentClumpNaive.ToString()].BurCrampVisit();

            return ShaftDime.Success;
        }

        /// <summary>
        /// 过关成功
        /// </summary>
        public virtual void ClumpInclude()
        {
            if (PrudentClumpNaive == FoxClumpNaive)
            {
                // 主线进程，自动增加一点经验值
                FoxClumpNaive++;
                DeviateCenterChurn.PenMonopoly().Jump(CLagoon.Ox_ClumpSetClumpDampen);
                ResourceCtrl.Instance.AddItemValue(ResourceCtrl.Instance.exp, 1);
                // 增加连胜值
                ResourceCtrl.Instance.AddItemValue(ResourceCtrl.Instance.consecutive_wins, 1);
            }
            // 恢复体力
            ArcticRule.Instance.BurArctic(TimelyFolk);
            // 关卡增加一次过关成功次数
            PianoCut[PrudentClumpNaive.ToString()].BurIncludeVisit();
            // 存档
            HaveMimetic.Instance.LuckHave();
        }

        /// <summary>
        /// 过关失败
        /// </summary>
        public virtual void ClumpHone()
        {
            // 连胜数值清零
            ResourceCtrl.Instance.SetItemValue(ResourceCtrl.Instance.consecutive_wins, 0);
        }
    }
}
