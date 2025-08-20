using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 去广告活动
/// </summary>

namespace zeta_framework
{
    public class SkillfulHyksosToRule: Activity
    {
        public static SkillfulHyksosToRule Instance;

        public const string PageOf= "s_remove_ad"; // 去广告在商店中的配置(Shop)

        public SkillfulHyksosToRule()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }


        /// <summary>
        /// 去广告功能是否已经生效
        /// </summary>
        /// <returns></returns>
        public bool WeOxygen()
        {
            return ResourceCtrl.Instance.remove_ad.currentValue > 0;
        }

        /// <summary>
        /// 购买去广告
        /// </summary>
        /// <param name="cb"></param>
        public void Mud(System.Action<ShaftDime> cb)
        {
            if (WeOxygen())
            {
                cb?.Invoke(ShaftDime.Success);
            }

            Shop shopItem = PageRule.Instance.PenPageOnOf(PageOf);
            PageRule.Instance.Mud(shopItem, (errorCode) => { 
                if (errorCode == ShaftDime.Success)
                {
                    // 购买成功，给奖励
                    ResourceCtrl.Instance.AddItemGroup(shopItem.gp_pid);
                    // 活动状态改为Finish
                    Settlement();
                    cb?.Invoke(ShaftDime.Success);
                }
                else
                {
                    // 购买失败，直接返回
                    cb?.Invoke(errorCode);
                }
            });
        }

        /// <summary>
        /// 去广告活动的所有奖励
        /// </summary>
        /// <returns></returns>
        public List<ItemGroup> PenTreetop() {
            Shop shopItem = PageRule.Instance.PenPageOnOf(PageOf);
            return shopItem.itemGroup;
        }
    }
}

