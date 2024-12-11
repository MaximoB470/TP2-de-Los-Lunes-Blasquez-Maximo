using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        services[typeof(T)] = service;
        //services.Add(typeof(T), service);
    }
    public T GetService<T>(params object[] args)
    {
        if (services.TryGetValue(typeof(T), out object result))
        {
            return (T)result;
        }

        var constructor = typeof(T).GetConstructor(args.Select(a => a.GetType()).ToArray());
        if (constructor != null)
        {
            result = constructor.Invoke(args);
            services.Add(typeof(T), result);
            return (T)result;
        }

        return default(T);
    }
}