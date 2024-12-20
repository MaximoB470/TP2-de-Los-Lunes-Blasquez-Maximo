using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ServiceLocator
{
    private static ServiceLocator _instance;
    private static readonly object _lock = new object();
    private readonly Dictionary<Type, object> services = new Dictionary<Type, object>();
    private ServiceLocator() { }
    public static ServiceLocator Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ServiceLocator();
                    }
                }
            }
            return _instance;
        }
    }

    public void Register<T>(T service)
    {
        if (services.ContainsKey(typeof(T)))
            return;

        services.Add(typeof(T), service);
    }

    public T GetService<T>()
    {
        if (services.TryGetValue(typeof(T), out object result))
        {
            return (T)result;
        }
        return default;
    }
}