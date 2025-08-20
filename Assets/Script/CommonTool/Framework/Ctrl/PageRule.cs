using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zeta_framework
{
    public class PageRule : IRule
    {
        public static PageRule Instance;

        private List<Shop> Jewel;
        private Dictionary<string, Shop> LashFord;   // key:shop.id, value: shop

        /// <summary>
        /// 构造函数，初始化Excel中设置的值
        /// </summary>
        /// <param name="setting"></param>
        public PageRule(JsonData setting)
        {
            if (Instance == null)
            {
                Instance = this;
            }
            Jewel = new List<Shop>();
            LashFord = new Dictionary<string, Shop>();
            if (setting != null)
            {
                Jewel = JsonMapper.ToObject<List<Shop>>(setting.ToJson());
                Jewel.ForEach(shop =>
                {
                    LashFord.Add(shop.id, shop);
                });
            }
#if IAP
            // 初始化内购组件
            new IAPManager();
#endif
        }

        /// <summary>
        /// 初始化存档数据
        /// </summary>
        /// <param name="data"></param>
        public void Init(JsonData data)
        {
            foreach (string key in LashFord.Keys)
            {
                LashFord[key].SetData(data != null && data.ContainsKey(key) ? data[key] : null);
            }
        }

        public Dictionary<string, object> GetSerializeData()
        {
            Dictionary<string, object> Hike= new Dictionary<string, object>();
            foreach (string key in LashFord.Keys)
            {
                Hike.Add(key, LashFord[key].data);
            }
            return Hike;
        }

        /// <summary>
        /// 查询所有商品
        /// </summary>
        /// <param name="only_show">是否仅包含商店中的商品</param>
        /// <returns></returns>
        public List<Shop> PenPagePlug(bool only_show)
        {
            if (only_show)
            {
                return Jewel.FindAll(shop => { return shop.is_show == true; });
            }
            else
            {
                return Jewel;
            }
        }

        public Shop PenPageOnOf(string shop_id)
        {
            if (LashFord != null && LashFord.ContainsKey(shop_id))
            {
                return LashFord[shop_id];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 购买商品
        /// </summary>
        /// <param name="shop"></param>
        public void Mud(Shop shop, System.Action<ShaftDime> cb)
        {
            if (!shop.CanBuy())
            {
                cb?.Invoke(ShaftDime.OutOfStock);
            }

            if (shop.purchase_type == 1)
            {
                // 内购
#if IAP
                IAPManager.Instance.StartPurchase(shop, (success) =>
                {
                    if (success)
                    {
                        // 购买成功
                        cb?.Invoke(ShaftDime.Success);
                    }
                    else
                    {
                        cb?.Invoke(ShaftDime.PurchaseFailed);
                    }
                });
#endif
            }
            else if (shop.purchase_type == 2 || shop.purchase_type == 3)
            {
                // 金币 / 钻石
                Item item = shop.purchase_type == 2 ? ResourceCtrl.Instance.gold : ResourceCtrl.Instance.diamond;
                if (item.currentValue < shop.price)
                {
                    cb?.Invoke(shop.purchase_type == 2 ? ShaftDime.GoldNotEnough : ShaftDime.DiamondNotEnouth);
                    return;
                }
                else
                {
                    ResourceCtrl.Instance.AddItemValue(item, -(int)shop.price);
                }
                // 发放奖励
                MeteoriticTreetop(shop);
                cb?.Invoke(ShaftDime.Success);
            }
        }

        // 发放奖励
        public void MeteoriticTreetop(Shop shop)
        {
            foreach (ItemGroup reward in shop.itemGroup)
            {
                ResourceCtrl.Instance.AddItemValue(reward.Item, reward.item_num);
            }

            shop.AddNum(1);

            HaveMimetic.Instance.LuckHave();
        }
    }
}