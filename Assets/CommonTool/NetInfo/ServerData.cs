using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//登录服务器返回数据
public class RootData 
{
    public int code { get; set; }
    public string msg { get; set; }
    public ServerData data { get; set; }
}
//用户登录信息
public class ServerUserData
{
    public int code { get; set; }
    public string msg { get; set; }
    public int data { get; set; }
}

public class UserRootData
{
    public int code { get; set; }
    public string msg { get; set; }
    public string data { get; set; }
}

public class LocationData
{
    public double X;
    public double Y;
    public double Radius;
}

public class UserInfoData
{
    public double lat;
    public double lon;
    public string query; //ip地址
    public string regionName; //地区名称
    public string city; //城市名称
    public bool IsHaveApple; //是否有苹果
}

public class BlockRuleData //屏蔽规则
{
    public LocationData[] LocationList; //屏蔽位置列表
    public string[] CityList; //屏蔽城市列表
    public string[] IPList; //屏蔽IP列表
    public string fall_down; //自然量
    public bool BlockVPN; //屏蔽VPN
    public bool BlockSimulator; //屏蔽模拟器
    public bool BlockRoot; //屏蔽root
    public bool BlockDeveloper; //屏蔽开发者模式
    public bool BlockUsb; //屏蔽USB调试
    public bool BlockSimCard; //屏蔽SIM卡
}

//服务器的数据
public class ServerData
{
    public string BlockRule { get; set; } //屏蔽规则
    public string fall_down { get; set; }
    public string HeiNameList { get; set; } //IP黑名单列表
    public string LocationList { get; set; } //黑位置列表
    public string HeiCity { get; set; } //城市黑名单列表

    public string init { get; set; }
    public string init_ru { get; set; }
    public string init_br { get; set; }
    public string init_jp { get; set; }
    public string init_us { get; set; }
    public string version { get; set; }

    public string apple_pie { get; set; }
    public string inter_b2f_count { get; set; }
    public string inter_freq { get; set; }
    public string relax_interval { get; set; }
    public string trial_MaxNum { get; set; }
    public string nextlevel_interval { get; set; }
    public string adjust_init_rate_act { get; set; }
    public string adjust_init_act_position { get; set; }
    public string adjust_init_adrevenue { get; set; }
    public string soho_shop { get; set; }
    public string soho_shop_jp { get; set; }
    public string soho_shop_br { get; set; }
    public string soho_shop_ru { get; set; }
    public string soho_shop_us { get; set; }
    public string game_data { get; set; }

    public string task_data { get; set; }
    public string task_data_jp { get; set; }
    public string task_data_br { get; set; }
    public string task_data_ru { get; set; }
    public string task_data_us { get; set; }

    public string CashOut_MoneyName { get; set; } //货币名称
    public string CashOut_Description { get; set; } //玩法描述
    public string convert_goal { get; set; } //兑换目标

}
public class Init
{
    public List<SlotItem> slot_group { get; set; }

    public double[] cash_random { get; set; }
    public MultiGroup[] cash_group { get; set; }
    public MultiGroup[] gold_group { get; set; }
    public MultiGroup[] amazon_group { get; set; }
}

public class SlotItem
{
    public double multi { get; set; }
    public int weight { get; set; }
}

public class MultiGroup
{
    public int max { get; set; }
    public int multi { get; set; }
    public double weight_multi { get; set; }
}

public class TaskItemData
{
    public string type { get; set; }
    public int num { get; set; }
    public string des { get; set; }
    public string reward_type { get; set; }
    public double rewad_num { get; set; }

}

public class Task_Data
{
    public List<List<TaskItemData>> task_list { get; set; }
    public List<int> reset_time_list { get; set; }
    public List<int> reset_now_ad_list { get; set; }
}

public class Game_Data
{
    //存钱罐数量
    public double piggybank_limit;
    //存钱罐奖励金额
    public double piggybank_cash_num;
    //小球消除现金金额
    public double ball_reward_cash_num;

    private double _level_complete_cash_num;
    //过关奖励现金金额
    public double level_complete_cash_num
    {
        get
        {
            return _level_complete_cash_num * GameUtil.GetCashMulti();
        }
        set
        {
            _level_complete_cash_num = value;
        }
    }

    public List<RewardData> hole_data_group;
    public List<RewardData> wheel_reward_weight_group;
    public WheelMultiGroup wheel_reward_multi;
    public int scratch_win_max_count;
    public int fly_box_limit;
    public int fly_box_cash_num;
    public List<RewardData> scratch_data_list;
    public string piggybank_open;// open close
    public string bonustask_open;
    public int slots_count;
    public int bigwin_time;
    public List<RewardData> slots_data_list;
    public List<WheelMultiItem> slots_multi;

    public int win_coins;
    public int Undo_nums;
    public int Wand_nums;
    public int Shuffle_nums;
    public int Undo_ad_nums;
    public int Wand_ad_nums;
    public int Shuffle_ad_nums;
    public int Undo_price;
    public int Wand_price;
    public int Auto_Complete;
    public int Shuffle_price;
    public int Cash_Config;
    public int Wheel_Switch;
    public int Wheel_Config;
    public int Daily_Challenge;
    public int Daily_Challengetime;
    public string Combo_Cash;
    public int Undo_Cash;
    public int Wand_Cash;
    public int Shuffle_Cash;
    public int Win_Cash;
    public int RateUs_config;
    public int Quickplay_Config;
    public int Challenge_Initial;
    public int Challenge_Item;
    public int Challenge_Revive;
    public string Privacy_Policy;
    public string Challenge_Reward;
}

public class WheelMultiGroup
{
    public WheelMultiItem[] cash;
    public WheelMultiItem[] gold;
    public WheelMultiItem[] shuffle;
    public WheelMultiItem[] undo;
    public WheelMultiItem[] wand;
}

public class WheelMultiItem
{
    public double weight;
    public double multi;
    public int num;
}
