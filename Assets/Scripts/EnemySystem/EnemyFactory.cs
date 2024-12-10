using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : GameObjectFactory<Enemy>
{
    private GameObject enemyPrefab;

    public EnemyFactory(GameObject enemyPrefab)
    {
        this.enemyPrefab = enemyPrefab;
    }
    public override Enemy Create(Vector3 position, Transform parent = null)
    {
        GameObject enemyInstance = Object.Instantiate(enemyPrefab, position, Quaternion.identity, parent);
        return enemyInstance.GetComponent<Enemy>();
    }
}