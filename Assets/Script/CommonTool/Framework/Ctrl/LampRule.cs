using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zeta_framework
{
    public class LampRule : IRule
    {
        public static LampRule Instance;

        private List<Skin> Group;
        private Dictionary<string, Skin> GoodFord;     // 所有皮肤，key:皮肤id
        private Dictionary<string, List<Skin>> GoodVital;  // 所有皮肤分类，key：皮肤分类
        private Dictionary<string, Skin> StrainLamp;    // 当前使用的皮肤, key:皮肤分类

        /// <summary>
        /// 构造函数，初始化Excel中设置的值
        /// </summary>
        /// <param name="setting"></param>
        public LampRule(JsonData setting)
        {
            if (Instance == null)
            {
                Instance = this;
            }
            Group = new();
            GoodFord = new();
            GoodVital = new();
            StrainLamp = new();
            if (setting != null)
            {
                Group = JsonMapper.ToObject<List<Skin>>(setting.ToJson());
                Group.ForEach(skin =>
                {
                    GoodFord.Add(skin.item_id, skin);
                    // 皮肤分类
                    if (!GoodVital.ContainsKey(skin.skin_type))
                    {
                        GoodVital.Add(skin.skin_type, new());
                    }
                    GoodVital[skin.skin_type].Add(skin);
                    // 当前正在使用的皮肤，默认使用第一个
                    if (!StrainLamp.ContainsKey(skin.skin_type))
                    {
                        StrainLamp.Add(skin.skin_type, skin);
                    }
                });
            }

            // 向资源管理器中注册经验变更回调事件
            DeviateCenterChurn.PenMonopoly().Scavenge(CLagoon.Ox_OozeDampen_ + ResourceCtrl.Instance.exp.id, (md) =>
            {
                VirginOnHay();
            });
        }

        /// <summary>
        /// 初始化存档数据
        /// </summary>
        /// <param name="data"></param>
        public void Init(JsonData data)
        {
            foreach (string key in GoodFord.Keys)
            {
                GoodFord[key].SetData(data != null && data.ContainsKey(key) ? data[key] : null);
                // 当前使用中的皮肤
                if (data != null && data.ContainsKey(key) && data[key].ContainsKey("actived") && bool.Parse(data[key]["actived"].ToString()))
                {
                    BattleLamp(GoodFord[key]);
                }
            }
        }

        public Dictionary<string, object> GetSerializeData()
        {
            Dictionary<string, object> Hike= new();
            foreach (string key in GoodFord.Keys)
            {
                Hike.Add(key, GoodFord[key].data);
            }
            return Hike;
        }

        /// <summary>
        /// 获取所有所有分类及分类下的皮肤
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<Skin>> PenIceSkinsToSpur()
        {
            return GoodVital;
        }

        /// <summary>
        /// 获取某个分类下的所有皮肤
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Skin> PenBlackOnSpur(string skin_type)
        {
            if (GoodVital.ContainsKey(skin_type))
            {
                return GoodVital[skin_type];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 解锁/购买皮肤
        /// </summary>
        /// <param name="skin"></param>
        /// <param name="cb"></param>
        public void VirginLamp(Skin skin, System.Action<ShaftDime> cb)
        {
            if (skin.unlock_type == 1)
            {
                // 过关自动解锁
                int exp = ResourceCtrl.Instance.exp.currentValue + 1;
                if (int.Parse(skin.unlock_value) <= exp)
                {
                    ResourceCtrl.Instance.AddItemValue(skin.item_id, 1);
                    // 存档
                    HaveMimetic.Instance.LuckHave();
                    cb?.Invoke(ShaftDime.Success);
                }
                else
                {
                    cb?.Invoke(ShaftDime.ExpNotEnouth);
                }

            }
            else if (skin.unlock_type == 2)
            {
                // 金币解锁
                if (ResourceCtrl.Instance.gold.currentValue < int.Parse(skin.unlock_value))
                {
                    cb.Invoke(ShaftDime.GoldNotEnough);
                }
                else
                {
                    ResourceCtrl.Instance.AddItemValue(ResourceCtrl.Instance.gold, -int.Parse(skin.unlock_value));
                    ResourceCtrl.Instance.AddItemValue(skin.item_id, 1);
                    // 存档
                    HaveMimetic.Instance.LuckHave();
                    cb?.Invoke(ShaftDime.Success);
                }
            }
            else if (skin.unlock_type == 3)
            {
                // 购买解锁
                Shop Lash= PageRule.Instance.PenPageOnOf(skin.unlock_value);
                PageRule.Instance.Mud(Lash, (errorCode) =>
                {
                    cb?.Invoke(errorCode);
                });
            }
            else if (skin.unlock_type == 4)
            {
                ResourceCtrl.Instance.AddItemValue(skin.item_id, 1);
                // 存档
                HaveMimetic.Instance.LuckHave();
                cb?.Invoke(ShaftDime.Success);
            }
        }


        /// <summary>
        /// 使用某个皮肤
        /// </summary>
        /// <param name="skin"></param>
        /// <returns></returns>
        public bool BattleLamp(Skin skin)
        {
            if (!skin.unlocked)
            {
                return false;
            }
            if (StrainLamp != null && StrainLamp.ContainsKey(skin.skin_type))
            {
                StrainLamp[skin.skin_type].SetActive(false);
            }
            skin.SetActive(true);
            StrainLamp[skin.skin_type] = skin;
            // 存档
            HaveMimetic.Instance.LuckHave();

            return true;
        }

        /// <summary>
        /// 用户经验变更后，查看是否有皮肤可以自动解锁
        /// </summary>
        private void VirginOnHay()
        {
            int exp = ResourceCtrl.Instance.exp.currentValue + 1;
            Group.ForEach(skin =>
            {
                if (skin.unlock_type == 1 && skin.unlocked && int.Parse(skin.unlock_value) <= exp)
                {
                    VirginLamp(skin, null);
                }
            });
        }
    }
}