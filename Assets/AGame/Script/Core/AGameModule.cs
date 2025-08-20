
public class AGameModule
{
    #region 框架模块

    /// <summary>
    /// 获取游戏基础模块。
    /// </summary>
    public static ARootModule Base
    {
        get => _base ??= ARootModule.Instance;
        private set => _base = value;
    }

    private static ARootModule _base;

    /// <summary>
    /// 获取调试模块。
    /// </summary>
    // public static IDebuggerModule Debugger
    // {
    //     get => _debugger ??= Get<IDebuggerModule>();
    //     private set => _debugger = value;
    // }


    // private static IDebuggerModule _debugger;

    /// <summary>
    /// 获取有限状态机模块。
    /// </summary>
    // public static IFsmModule Fsm => _fsm ??= Get<IFsmModule>();
    //
    // private static IFsmModule _fsm;

    /// <summary>
    /// 获取音频模块。
    /// </summary>
    public static A_AudioManager Audio => _audio ??= A_AudioManager.Instance;

    private static A_AudioManager _audio;

    /// <summary>
    /// 获取UI模块。
    /// </summary>
    public static AUIModule UI => _ui ??= AUIModule.Instance;

    private static AUIModule _ui;

    /// <summary>
    /// 获取场景模块。
    /// </summary>
    // public static ISceneModule Scene => _scene ??= Get<ISceneModule>();
    //
    // private static ISceneModule _scene;

    /// <summary>
    /// 获取计时器模块。
    /// </summary>
    public static IATimerModule Timer => _timer ??= ATimerModule.Instance;

    private static IATimerModule _timer;
    
    #endregion
    
    public static void Shutdown()
    {
        ADebug.Log("GameModule Shutdown");
            
        _base = null;
        _audio = null;
        _ui = null;
        _timer = null;
    }
}