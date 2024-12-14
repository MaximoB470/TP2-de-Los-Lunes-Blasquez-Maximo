using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T prefab;
    [SerializeField] private int poolSize = 10;
    private readonly Queue<T> pool = new Queue<T>();
    protected virtual void Start()
    {
        InitializePool();
    }
    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            T obj = Instantiate(prefab);
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }
    }
    public T GetFromPool()
    {
        T obj;

        if (pool.Count > 0)
        {
            obj = pool.Dequeue();
        }
        else
        {
            obj = Instantiate(prefab);
        }

        obj.gameObject.SetActive(true);
        return obj;
    }
    public void ReturnToPool(T obj)
    {
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
}