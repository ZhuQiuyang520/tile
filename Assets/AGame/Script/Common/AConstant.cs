public static class AConstant
{
    
    #region 常量配置
    //关卡胜利奖励金币
    public const int LEVEL_GOLD_WIN = 50;
    // 最大HP
    public const int MAX_HP = 50000;
    public const int BASE_HP = 10;
    public const int AUTO_ADD_HP = 1;
    public const float AUTO_ADD_HP_DELAY = 30f;
    //HP价格
    public const int HP_PRICE = 100;
    //关卡消耗HP
    public const int LEVEL_HP = 1;
    
    public const int LEVEL_DEVOUR_BALL = 100;
    public const int LEVEL_CLICK_BALL = 30;
    public const int LEVEL_USE_TIME = 180;
    public const int SKILL_PRICE = 100;
    public const int MAX_NUMBER_Gold = 5;
    public const int BASE_ORDER = 1800;          // 基础顺序
    public const int SETTLEMENT_GOLD = 100;     
    public const int MIN_REVIVE_GOLD = 200;     
    public const int MAX_REVIVE_GOLD = 1000;     
    public const int BG_PRICE = 1000;     
    public const int FOOD_SCORE = 10;  
    public const int COMBO_SCORE_0_2 = 10;
    public const int COMBO_SCORE_3_10 = 12;
    public const int COMBO_SCORE_11_20  = 15;
    public const int COMBO_SCORE_21_MORE = 20;
    // public const int MaxBulletCount = 30;
    public const float SPEED_BASE = 5f;//基础速度
    public const float LAUNCHER_DELAY = 5f;//发射食物间隔
    public const int LAUNCHER_BASE_COUNT = 3;
    public const int LAUNCHER_MAX_COUNT = 10;
    
    #endregion
    
    public static class ArchiveKey
    {
        public const string CurrGold = "CurrGold";
        public const string LastOutLineTime = "LastOutLineTime";

        public static string HighScore { get; set; }
    }
    
    public static class TipsContent
    {
        public const string GoldInsufficient = "Not enough gold";
    }
    
    
}