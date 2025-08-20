using System;
using System.Collections.Generic;

/// <summary>
/// 游戏事件管理器。
/// </summary>
public class AGameEventMgr
{
    private readonly List<AEventType> _listEventTypes;
    private readonly List<Delegate> _listHandles;
    private readonly bool _isInit = false;

    /// <summary>
    /// 游戏事件管理器构造函数。
    /// </summary>
    public AGameEventMgr()
    {
        if (_isInit)
        {
            return;
        }

        _isInit = true;
        _listEventTypes = new List<AEventType>();
        _listHandles = new List<Delegate>();
    }

    /// <summary>
    /// 清理内存对象回收入池。
    /// </summary>
    public void Clear()
    {
        if (!_isInit)
        {
            return;
        }

        for (int i = 0; i < _listEventTypes.Count; ++i)
        {
            var eventType = _listEventTypes[i];
            var handle = _listHandles[i];
            AEventModule.RemoveEvent(eventType, handle);
        }

        _listEventTypes.Clear();
        _listHandles.Clear();
    }

    private void AddEventImp(AEventType eventType, Delegate handler)
    {
        _listEventTypes.Add(eventType);
        _listHandles.Add(handler);
    }

    #region UIEvent

    public void AddEvent(AEventType eventType, Action handler)
    {
        if (AEventModule.AddEvent(eventType, handler))
        {
            AddEventImp(eventType, handler);
        }
    }

    public void AddEvent<T>(AEventType eventType, Action<T> handler)
    {
        if (AEventModule.AddEvent(eventType, handler))
        {
            AddEventImp(eventType, handler);
        }
    }

    public void AddEvent<T1, T2>(AEventType eventType, Action<T1, T2> handler)
    {
        if (AEventModule.AddEvent(eventType, handler))
        {
            AddEventImp(eventType, handler);
        }
    }

    public void AddEvent<T1, T2, T3>(AEventType eventType, Action<T1, T2, T3> handler)
    {
        if (AEventModule.AddEvent(eventType, handler))
        {
            AddEventImp(eventType, handler);
        }
    }

    public void AddEvent<T1, T2, T3, T4>(AEventType eventType, Action<T1, T2, T3, T4> handler)
    {
        if (AEventModule.AddEvent(eventType, handler))
        {
            AddEventImp(eventType, handler);
        }
    }

    public void AddEvent<T1, T2, T3, T4, T5>(AEventType eventType, Action<T1, T2, T3, T4, T5> handler)
    {
        if (AEventModule.AddEvent(eventType, handler))
        {
            AddEventImp(eventType, handler);
        }
    }

    #endregion
}