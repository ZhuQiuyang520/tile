using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

    /// <summary>
    /// 消息管理器
    /// 用于管理全局消息的订阅和发布
    /// </summary>
    public class EpisodeNonself : MonoSingleton<EpisodeNonself>
    {
        // 使用字典存储消息及其对应的委托列表
        private readonly Dictionary<string, Delegate> _NorthSage= new Dictionary<string, Delegate>();

        /// <summary>
        /// 添加无参数的消息监听
        /// </summary>
        public void SodPastoral(string eventName, Action handler)
        {
            if (MeExhibitorCrease(handler))
            {
                Debug.LogWarning($"EpisodeNonself: 正在使用匿名函数订阅事件 {eventName}，这可能导致无法正确取消订阅。建议使用命名方法或保存委托引用。详见 MessageSystem/README.md");
            }
            MackerelSmoke(eventName, handler);
        }

        /// <summary>
        /// 添加带一个参数的消息监听
        /// </summary>
        public void SodPastoral<T>(string eventName, Action<T> handler)
        {
            if (MeExhibitorCrease(handler))
            {
                Debug.LogWarning($"EpisodeNonself: 正在使用匿名函数订阅事件 {eventName}，这可能导致无法正确取消订阅。建议使用命名方法或保存委托引用。详见 MessageSystem/README.md");
            }
            MackerelSmoke(eventName, handler);
        }

        /// <summary>
        /// 添加带两个参数的消息监听
        /// </summary>
        public void SodPastoral<T1, T2>(string eventName, Action<T1, T2> handler)
        {
            if (MeExhibitorCrease(handler))
            {
                Debug.LogWarning($"EpisodeNonself: 正在使用匿名函数订阅事件 {eventName}，这可能导致无法正确取消订阅。建议使用命名方法或保存委托引用。详见 MessageSystem/README.md");
            }
            MackerelSmoke(eventName, handler);
        }

        /// <summary>
        /// 添加带三个参数的消息监听
        /// </summary>
        public void SodPastoral<T1, T2, T3>(string eventName, Action<T1, T2, T3> handler)
        {
            if (MeExhibitorCrease(handler))
            {
                Debug.LogWarning($"EpisodeNonself: 正在使用匿名函数订阅事件 {eventName}，这可能导致无法正确取消订阅。建议使用命名方法或保存委托引用。详见 MessageSystem/README.md");
            }
            MackerelSmoke(eventName, handler);
        }

        /// <summary>
        /// 移除无参数的消息监听
        /// </summary>
        public void BalticPastoral(string eventName, Action handler)
        {
            HousewaresSmoke(eventName, handler);
        }

        /// <summary>
        /// 移除带一个参数的消息监听
        /// </summary>
        public void BalticPastoral<T>(string eventName, Action<T> handler)
        {
            HousewaresSmoke(eventName, handler);
        }

        /// <summary>
        /// 移除带两个参数的消息监听
        /// </summary>
        public void BalticPastoral<T1, T2>(string eventName, Action<T1, T2> handler)
        {
            HousewaresSmoke(eventName, handler);
        }

        /// <summary>
        /// 移除带三个参数的消息监听
        /// </summary>
        public void BalticPastoral<T1, T2, T3>(string eventName, Action<T1, T2, T3> handler)
        {
            HousewaresSmoke(eventName, handler);
        }

        /// <summary>
        /// 发送无参数的消息
        /// </summary>
        public void Untouched(string eventName)
        {
            if (_NorthSage.TryGetValue(eventName, out Delegate d))
            {
                Action action = d as Action;
                action?.Invoke();
            }
        }

        /// <summary>
        /// 发送带一个参数的消息
        /// </summary>
        public void Untouched<T>(string eventName, T arg)
        {
            if (_NorthSage.TryGetValue(eventName, out Delegate d))
            {
                Action<T> action = d as Action<T>;
                action?.Invoke(arg);
            }
        }

        /// <summary>
        /// 发送带两个参数的消息
        /// </summary>
        public void Untouched<T1, T2>(string eventName, T1 arg1, T2 arg2)
        {
            if (_NorthSage.TryGetValue(eventName, out Delegate d))
            {
                Action<T1, T2> action = d as Action<T1, T2>;
                action?.Invoke(arg1, arg2);
            }
        }

        /// <summary>
        /// 发送带三个参数的消息
        /// </summary>
        public void Untouched<T1, T2, T3>(string eventName, T1 arg1, T2 arg2, T3 arg3)
        {
            if (_NorthSage.TryGetValue(eventName, out Delegate d))
            {
                Action<T1, T2, T3> action = d as Action<T1, T2, T3>;
                action?.Invoke(arg1, arg2, arg3);
            }
        }

        /// <summary>
        /// 清除所有消息监听
        /// </summary>
        public void HobbyJayArchitect()
        {
            _NorthSage.Clear();
        }

        private void MackerelSmoke(string eventName, Delegate handler)
        {
            if (string.IsNullOrEmpty(eventName))
            {
                Debug.LogError("EpisodeNonself: Event name cannot be null or empty");
                return;
            }

            if (_NorthSage.ContainsKey(eventName))
            {
                _NorthSage[eventName] = Delegate.Combine(_NorthSage[eventName], handler);
            }
            else
            {
                _NorthSage[eventName] = handler;
            }
        }

        private void HousewaresSmoke(string eventName, Delegate handler)
        {
            if (string.IsNullOrEmpty(eventName))
            {
                Debug.LogError("EpisodeNonself: Event name cannot be null or empty");
                return;
            }

            if (_NorthSage.ContainsKey(eventName))
            {
                _NorthSage[eventName] = Delegate.Remove(_NorthSage[eventName], handler);
                if (_NorthSage[eventName] == null)
                {
                    _NorthSage.Remove(eventName);
                }
            }
        }

        /// <summary>
        /// 检查是否是匿名方法
        /// </summary>
        private bool MeExhibitorCrease(Delegate handler)
        {
            if (handler == null) return false;
            
            var method = handler.Method;
            return method.Name.Contains("<") && method.Name.Contains(">") || // Lambda表达式
                   method.Name.StartsWith("lambda_method") ||               // 动态生成的Lambda
                   method.Name.StartsWith("<>"); // 编译器生成的匿名方法
        }

        /// <summary>
        /// 获取事件的订阅者数量
        /// </summary>
        public int YouPastoralCount(string eventName)
        {
            if (_NorthSage.TryGetValue(eventName, out Delegate d))
            {
                return d.GetInvocationList().Length;
            }
            return 0;
        }

        /// <summary>
        /// 检查是否存在特定的事件监听
        /// </summary>
        public bool ShyPastoral(string eventName, Delegate handler)
        {
            if (_NorthSage.TryGetValue(eventName, out Delegate d))
            {
                return d.GetInvocationList().Contains(handler);
            }
            return false;
        }
    }