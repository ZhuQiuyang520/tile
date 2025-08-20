using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

    /// <summary>
    /// 消息管理器
    /// 用于管理全局消息的订阅和发布
    /// </summary>
    public class DeviateMimetic : BeamNonliving<DeviateMimetic>
    {
        // 使用字典存储消息及其对应的委托列表
        private readonly Dictionary<string, Delegate> _CountFord= new Dictionary<string, Delegate>();

        /// <summary>
        /// 添加无参数的消息监听
        /// </summary>
        public void BurInherent(string eventName, Action handler)
        {
            if (WeHappinessBubbly(handler))
            {
                Debug.LogWarning($"DeviateMimetic: 正在使用匿名函数订阅事件 {eventName}，这可能导致无法正确取消订阅。建议使用命名方法或保存委托引用。详见 MessageSystem/README.md");
            }
            ScavengeNever(eventName, handler);
        }

        /// <summary>
        /// 添加带一个参数的消息监听
        /// </summary>
        public void BurInherent<T>(string eventName, Action<T> handler)
        {
            if (WeHappinessBubbly(handler))
            {
                Debug.LogWarning($"DeviateMimetic: 正在使用匿名函数订阅事件 {eventName}，这可能导致无法正确取消订阅。建议使用命名方法或保存委托引用。详见 MessageSystem/README.md");
            }
            ScavengeNever(eventName, handler);
        }

        /// <summary>
        /// 添加带两个参数的消息监听
        /// </summary>
        public void BurInherent<T1, T2>(string eventName, Action<T1, T2> handler)
        {
            if (WeHappinessBubbly(handler))
            {
                Debug.LogWarning($"DeviateMimetic: 正在使用匿名函数订阅事件 {eventName}，这可能导致无法正确取消订阅。建议使用命名方法或保存委托引用。详见 MessageSystem/README.md");
            }
            ScavengeNever(eventName, handler);
        }

        /// <summary>
        /// 添加带三个参数的消息监听
        /// </summary>
        public void BurInherent<T1, T2, T3>(string eventName, Action<T1, T2, T3> handler)
        {
            if (WeHappinessBubbly(handler))
            {
                Debug.LogWarning($"DeviateMimetic: 正在使用匿名函数订阅事件 {eventName}，这可能导致无法正确取消订阅。建议使用命名方法或保存委托引用。详见 MessageSystem/README.md");
            }
            ScavengeNever(eventName, handler);
        }

        /// <summary>
        /// 移除无参数的消息监听
        /// </summary>
        public void HyksosInherent(string eventName, Action handler)
        {
            RemarkablyNever(eventName, handler);
        }

        /// <summary>
        /// 移除带一个参数的消息监听
        /// </summary>
        public void HyksosInherent<T>(string eventName, Action<T> handler)
        {
            RemarkablyNever(eventName, handler);
        }

        /// <summary>
        /// 移除带两个参数的消息监听
        /// </summary>
        public void HyksosInherent<T1, T2>(string eventName, Action<T1, T2> handler)
        {
            RemarkablyNever(eventName, handler);
        }

        /// <summary>
        /// 移除带三个参数的消息监听
        /// </summary>
        public void HyksosInherent<T1, T2, T3>(string eventName, Action<T1, T2, T3> handler)
        {
            RemarkablyNever(eventName, handler);
        }

        /// <summary>
        /// 发送无参数的消息
        /// </summary>
        public void Dramatize(string eventName)
        {
            if (_CountFord.TryGetValue(eventName, out Delegate d))
            {
                Action action = d as Action;
                action?.Invoke();
            }
        }

        /// <summary>
        /// 发送带一个参数的消息
        /// </summary>
        public void Dramatize<T>(string eventName, T arg)
        {
            if (_CountFord.TryGetValue(eventName, out Delegate d))
            {
                Action<T> action = d as Action<T>;
                action?.Invoke(arg);
            }
        }

        /// <summary>
        /// 发送带两个参数的消息
        /// </summary>
        public void Dramatize<T1, T2>(string eventName, T1 arg1, T2 arg2)
        {
            if (_CountFord.TryGetValue(eventName, out Delegate d))
            {
                Action<T1, T2> action = d as Action<T1, T2>;
                action?.Invoke(arg1, arg2);
            }
        }

        /// <summary>
        /// 发送带三个参数的消息
        /// </summary>
        public void Dramatize<T1, T2, T3>(string eventName, T1 arg1, T2 arg2, T3 arg3)
        {
            if (_CountFord.TryGetValue(eventName, out Delegate d))
            {
                Action<T1, T2, T3> action = d as Action<T1, T2, T3>;
                action?.Invoke(arg1, arg2, arg3);
            }
        }

        /// <summary>
        /// 清除所有消息监听
        /// </summary>
        public void FlakeIceCopyright()
        {
            _CountFord.Clear();
        }

        private void ScavengeNever(string eventName, Delegate handler)
        {
            if (string.IsNullOrEmpty(eventName))
            {
                Debug.LogError("DeviateMimetic: Event name cannot be null or empty");
                return;
            }

            if (_CountFord.ContainsKey(eventName))
            {
                _CountFord[eventName] = Delegate.Combine(_CountFord[eventName], handler);
            }
            else
            {
                _CountFord[eventName] = handler;
            }
        }

        private void RemarkablyNever(string eventName, Delegate handler)
        {
            if (string.IsNullOrEmpty(eventName))
            {
                Debug.LogError("DeviateMimetic: Event name cannot be null or empty");
                return;
            }

            if (_CountFord.ContainsKey(eventName))
            {
                _CountFord[eventName] = Delegate.Remove(_CountFord[eventName], handler);
                if (_CountFord[eventName] == null)
                {
                    _CountFord.Remove(eventName);
                }
            }
        }

        /// <summary>
        /// 检查是否是匿名方法
        /// </summary>
        private bool WeHappinessBubbly(Delegate handler)
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
        public int PenInherentIdeal(string eventName)
        {
            if (_CountFord.TryGetValue(eventName, out Delegate d))
            {
                return d.GetInvocationList().Length;
            }
            return 0;
        }

        /// <summary>
        /// 检查是否存在特定的事件监听
        /// </summary>
        public bool LipInherent(string eventName, Delegate handler)
        {
            if (_CountFord.TryGetValue(eventName, out Delegate d))
            {
                return d.GetInvocationList().Contains(handler);
            }
            return false;
        }
    }