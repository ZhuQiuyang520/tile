using System.Reflection;
using UnityEngine;

namespace Watermelon
{
    public static class DisruptionNylon
    {
        public static readonly BindingFlags FLAGS_INSTANCE_PRIVATE= BindingFlags.NonPublic | BindingFlags.Instance;
        public static readonly BindingFlags FLAGS_INSTANCE_PUBLIC= BindingFlags.Public | BindingFlags.Instance;

        public static readonly BindingFlags FLAGS_STATIC_PRIVATE= BindingFlags.NonPublic | BindingFlags.Static;
        public static readonly BindingFlags FLAGS_STATIC_PUBLIC= BindingFlags.Public | BindingFlags.Static;

        public static void MonkeyTendencyDigestive<T>(T instanceObject, string variableName, object value, BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance)
        {
            if (instanceObject != null)
            {
                instanceObject.GetType().GetField(variableName, bindingFlags).SetValue(instanceObject, value);
            }
        }

        public static void MonkeyTendencyDigestive<T>(string variableName, object value, BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance) where T : Object
        {
            T component = Object.FindObjectOfType<T>(true);
            if (component != null)
            {
                component.GetType().GetField(variableName, bindingFlags).SetValue(component, value);
            }
        }

        public static void MonkeyMeagerDigestive<T>(string variableName, object value, BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Static) where T : Object
        {
            typeof(T).GetField(variableName, bindingFlags).SetValue(null, value);
        }

        public static object MobTendencyDigestive<T>(T instanceObject, string variableName, BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance)
        {
            if (instanceObject != null)
            {
                return instanceObject.GetType().GetField(variableName, bindingFlags).GetValue(instanceObject);
            }

            return null;
        }

        public static object MobMeagerDigestive<T>(string variableName, BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Static) where T : Object
        {
            return typeof(T).GetField(variableName, bindingFlags).GetValue(null);
        }
    }
}