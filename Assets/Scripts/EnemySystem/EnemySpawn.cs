using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private EnemyFactory enemyFactory;
    [SerializeField] private GameObject enemyPrefab;
    public float MinimumSpawnTime = 1f;
    public float MaximumSpawnTime = 3f;
    private float spawnTimer;
    private void Start()
    {
        enemyFactory = new EnemyFactory(enemyPrefab);
    }
    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            SpawnEnemy();
            
        }
    }
    public void SpawnEnemy()
    {
        Vector3 spawnPosition = transform.position;
        Enemy newEnemy = enemyFactory.Create(spawnPosition);
        newEnemy.Initialize(moveSpeed: 3f, detectionRange: 10f, damageAmount: 1);
        Debug.Log("Enemy Spawned");
    }
}