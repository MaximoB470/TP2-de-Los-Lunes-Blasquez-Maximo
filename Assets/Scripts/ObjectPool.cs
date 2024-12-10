using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private Queue<T> pool = new Queue<T>();
    private GameObjectFactory<T> factory;
    private int initialSize;

    public ObjectPool(GameObjectFactory<T> factory, int initialSize = 10)
    {
        this.factory = factory;
        this.initialSize = initialSize;
        InitializePool();
    }
    private void InitializePool()
    {
        for (int i = 0; i < initialSize; i++)
        {
            T obj = factory.Create(Vector3.zero);
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }
    }
    public T GetObject(Transform spawnPoint)
    {
        T obj;
        if (pool.Count > 0)
        {
            obj = pool.Dequeue();
        }
        else
        {
            obj = factory.Create(spawnPoint.position, spawnPoint);
        }
        obj.gameObject.SetActive(true);
        obj.transform.position = spawnPoint.position;
        obj.transform.rotation = spawnPoint.rotation;
        return obj;
    }
    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false); 
        pool.Enqueue(obj); 
    }
}