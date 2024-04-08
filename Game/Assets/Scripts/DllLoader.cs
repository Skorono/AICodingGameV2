using System;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

namespace AICodingGame
{
    public static class DllLoader
    {
        public static Type? LoadTypeFromDll<T>(string path) where T : MonoBehaviour
        {
            Type? targetType = null;
            var dll = Assembly.LoadFile(path);

            try
            {
                foreach (var type in dll.GetTypesSafely())
                    if (typeof(T).IsAssignableFrom(type)) // Пока работает условно верно
                        targetType = type;
            }
            catch (TypeLoadException e)
            {
                return targetType;
            }

            return targetType;
        }

        public static T InstanceType<T>(Type type) where T : new()
        {
            return (T)Activator.CreateInstance(type);
        }
    }
}