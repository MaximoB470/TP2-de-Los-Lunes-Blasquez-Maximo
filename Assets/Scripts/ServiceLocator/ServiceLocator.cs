using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{
    private static Dictionary<Type, object> services = new Dictionary<Type, object>();

    public static void Register<T>(T service)
    {
        if (services.ContainsKey(typeof(T)))
            return;

        services.Add(typeof(T), service);
    }

    public static T GetService<T>()
    {
        if (services.TryGetValue(typeof(T), out object result))
        {
            return (T)result;
        }
        return default;
    }
}