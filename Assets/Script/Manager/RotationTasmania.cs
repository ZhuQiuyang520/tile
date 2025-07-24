using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTasmania : MonoSingleton<RotationTasmania>
{
    private Action AC;
    //给帧动画插入函数，并拿到结束回调参数
    public void OnAnimationEvent(string eventName)
    {
        AC();
    }

    public void LidBasalt(Action ac)
    {
        AC = ac;
    }
}
