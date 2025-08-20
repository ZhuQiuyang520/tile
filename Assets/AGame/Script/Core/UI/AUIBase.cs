using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI基类。
/// </summary>
public class AUIBase : MonoBehaviour
{
      /// <summary>
      /// UI类型。
      /// </summary>
      public enum UIType
      {
            /// <summary>
            /// 类型无。
            /// </summary>
            None,

            /// <summary>
            /// 类型Windows。
            /// </summary>
            Window,

            /// <summary>
            /// 类型Widget。
            /// </summary>
            Widget,
      }
      
      /// <summary>
      /// 所属UI父节点。
      /// </summary>
      protected AUIBase _parent = null;

      /// <summary>
      /// UI父节点。
      /// </summary>
      public AUIBase Parent => _parent;
      
      /// <summary>
      /// 自定义数据集。
      /// </summary>
      protected System.Object[] _userDatas;
        
      /// <summary>
      /// 自定义数据。
      /// </summary>
      public System.Object UserData
      {
            get
            {
                  if (_userDatas != null && _userDatas.Length >= 1)
                  {
                        return _userDatas[0];
                  }
                  else
                  {
                        return null;
                  }
            }
      }

      /// <summary>
      /// 自定义数据集。
      /// </summary>
      public System.Object[] UserDatas => _userDatas;
      
      /// <summary>
      /// UI类型。
      /// </summary>
      public virtual UIType Type => UIType.None;
      
      /// <summary>
      /// UI子组件列表。
      /// </summary>
      internal readonly List<AUIWidget> ListChild = new List<AUIWidget>();
      
      /// <summary>
      /// 窗口创建。
      /// </summary>
      public virtual void OnCreate()
      {
            
      }
      
      public virtual void OnClose()
      {
            RemoveAllUIEvent();
      }
      
      /// <summary>
      /// 窗口刷新。
      /// </summary>
      public virtual void OnRefresh()
      {
      }
      
      #region UIEvent
      private AGameEventMgr _eventMgr;

      protected AGameEventMgr EventMgr
      {
            get
            {
                  if (_eventMgr == null)
                  {
                        _eventMgr = new AGameEventMgr();
                  }

                  return _eventMgr;
            }
      }
      
      public void AddUIEvent(AEventType eventType, Action handler)
      {
            EventMgr.AddEvent(eventType, handler);
      }

      protected void AddUIEvent<T>(AEventType eventType, Action<T> handler)
      {
            EventMgr.AddEvent(eventType, handler);
      }

      protected void AddUIEvent<T, U>(AEventType eventType, Action<T, U> handler)
      {
            EventMgr.AddEvent(eventType, handler);
      }

      protected void AddUIEvent<T, U, V>(AEventType eventType, Action<T, U, V> handler)
      {
            EventMgr.AddEvent(eventType, handler);
      }

      protected void AddUIEvent<T, U, V, W>(AEventType eventType, Action<T, U, V, W> handler)
      {
            EventMgr.AddEvent(eventType, handler);
      }

      protected void RemoveAllUIEvent()
      {
            if (_eventMgr != null)
            {
                  _eventMgr.Clear();
            }
      }
      #endregion
}