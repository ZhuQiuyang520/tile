using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

    /// <summary>
    /// 消息管理器
    /// 用于管理全局消息的订阅和发布
    /// </summary>
    public class SqueezeTenuous : MonoSingleton<SqueezeTenuous>
    {
        // 使用字典存储消息及其对应的委托列表
        private readonly Dictionary<string, Delegate> _GuessBlow= new Dictionary<string, Delegate>();

        /// <summary>
        /// 添加无参数的消息监听
        /// </summary>
        public void LidSeverely(string eventName, Action handler)
        {
            if (OfAttentionBasalt(handler))
            {
                Debug.LogWarning($"SqueezeTenuous: 正在使用匿名函数订阅事件 {eventName}，这可能导致无法正确取消订阅。建议使用命名方法或保存委托引用。详见 MessageSystem/README.md");
            }
            RegimentRarer(eventName, handler);
        }

        /// <summary>
        /// 添加带一个参数的消息监听
        /// </summary>
        public void LidSeverely<T>(string eventName, Action<T> handler)
        {
            if (OfAttentionBasalt(handler))
            {
                Debug.LogWarning($"SqueezeTenuous: 正在使用匿名函数订阅事件 {eventName}，这可能导致无法正确取消订阅。建议使用命名方法或保存委托引用。详见 MessageSystem/README.md");
            }
            RegimentRarer(eventName, handler);
        }

        /// <summary>
        /// 添加带两个参数的消息监听
        /// </summary>
        public void LidSeverely<T1, T2>(string eventName, Action<T1, T2> handler)
        {
            if (OfAttentionBasalt(handler))
            {
                Debug.LogWarning($"SqueezeTenuous: 正在使用匿名函数订阅事件 {eventName}，这可能导致无法正确取消订阅。建议使用命名方法或保存委托引用。详见 MessageSystem/README.md");
            }
            RegimentRarer(eventName, handler);
        }

        /// <summary>
        /// 添加带三个参数的消息监听
        /// </summary>
        public void LidSeverely<T1, T2, T3>(string eventName, Action<T1, T2, T3> handler)
        {
            if (OfAttentionBasalt(handler))
            {
                Debug.LogWarning($"SqueezeTenuous: 正在使用匿名函数订阅事件 {eventName}，这可能导致无法正确取消订阅。建议使用命名方法或保存委托引用。详见 MessageSystem/README.md");
            }
            RegimentRarer(eventName, handler);
        }

        /// <summary>
        /// 移除无参数的消息监听
        /// </summary>
        public void ObtainSeverely(string eventName, Action handler)
        {
            ThoughtfulRarer(eventName, handler);
        }

        /// <summary>
        /// 移除带一个参数的消息监听
        /// </summary>
        public void ObtainSeverely<T>(string eventName, Action<T> handler)
        {
            ThoughtfulRarer(eventName, handler);
        }

        /// <summary>
        /// 移除带两个参数的消息监听
        /// </summary>
        public void ObtainSeverely<T1, T2>(string eventName, Action<T1, T2> handler)
        {
            ThoughtfulRarer(eventName, handler);
        }

        /// <summary>
        /// 移除带三个参数的消息监听
        /// </summary>
        public void ObtainSeverely<T1, T2, T3>(string eventName, Action<T1, T2, T3> handler)
        {
            ThoughtfulRarer(eventName, handler);
        }

        /// <summary>
        /// 发送无参数的消息
        /// </summary>
        public void Caucasian(string eventName)
        {
            if (_GuessBlow.TryGetValue(eventName, out Delegate d))
            {
                Action action = d as Action;
                action?.Invoke();
            }
        }

        /// <summary>
        /// 发送带一个参数的消息
        /// </summary>
        public void Caucasian<T>(string eventName, T arg)
        {
            if (_GuessBlow.TryGetValue(eventName, out Delegate d))
            {
                Action<T> action = d as Action<T>;
                action?.Invoke(arg);
            }
        }

        /// <summary>
        /// 发送带两个参数的消息
        /// </summary>
        public void Caucasian<T1, T2>(string eventName, T1 arg1, T2 arg2)
        {
            if (_GuessBlow.TryGetValue(eventName, out Delegate d))
            {
                Action<T1, T2> action = d as Action<T1, T2>;
                action?.Invoke(arg1, arg2);
            }
        }

        /// <summary>
        /// 发送带三个参数的消息
        /// </summary>
        public void Caucasian<T1, T2, T3>(string eventName, T1 arg1, T2 arg2, T3 arg3)
        {
            if (_GuessBlow.TryGetValue(eventName, out Delegate d))
            {
                Action<T1, T2, T3> action = d as Action<T1, T2, T3>;
                action?.Invoke(arg1, arg2, arg3);
            }
        }

        /// <summary>
        /// 清除所有消息监听
        /// </summary>
        public void CliffWadOrdinance()
        {
            _GuessBlow.Clear();
        }

        private void RegimentRarer(string eventName, Delegate handler)
        {
            if (string.IsNullOrEmpty(eventName))
            {
                Debug.LogError("SqueezeTenuous: Event name cannot be null or empty");
                return;
            }

            if (_GuessBlow.ContainsKey(eventName))
            {
                _GuessBlow[eventName] = Delegate.Combine(_GuessBlow[eventName], handler);
            }
            else
            {
                _GuessBlow[eventName] = handler;
            }
        }

        private void ThoughtfulRarer(string eventName, Delegate handler)
        {
            if (string.IsNullOrEmpty(eventName))
            {
                Debug.LogError("SqueezeTenuous: Event name cannot be null or empty");
                return;
            }

            if (_GuessBlow.ContainsKey(eventName))
            {
                _GuessBlow[eventName] = Delegate.Remove(_GuessBlow[eventName], handler);
                if (_GuessBlow[eventName] == null)
                {
                    _GuessBlow.Remove(eventName);
                }
            }
        }

        /// <summary>
        /// 检查是否是匿名方法
        /// </summary>
        private bool OfAttentionBasalt(Delegate handler)
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
        public int MobSeverelyArise(string eventName)
        {
            if (_GuessBlow.TryGetValue(eventName, out Delegate d))
            {
                return d.GetInvocationList().Length;
            }
            return 0;
        }

        /// <summary>
        /// 检查是否存在特定的事件监听
        /// </summary>
        public bool UseSeverely(string eventName, Delegate handler)
        {
            if (_GuessBlow.TryGetValue(eventName, out Delegate d))
            {
                return d.GetInvocationList().Contains(handler);
            }
            return false;
        }
    }