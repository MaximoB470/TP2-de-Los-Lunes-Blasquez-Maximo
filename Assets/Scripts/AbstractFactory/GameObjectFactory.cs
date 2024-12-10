using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameObjectFactory<T>
{
    public abstract T Create(Vector3 position, Transform parent = null);
}