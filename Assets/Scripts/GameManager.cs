using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemySpawn enemySpawn; // Referencia al script de spawn
    private int currentWave = 1; // Número de la oleada actual
    private int enemiesToSpawn; // Enemigos que se generarán en la oleada
    private int enemiesRemaining; // Enemigos restantes en la oleada
    public float waveRestTime = 60f; // Tiempo de descanso entre oleadas en segundos
    public GameObject Bench;
    public GameObject CommandList;
    private void Start()
    {
        StartWave();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (CommandList != null)
            {
                CommandList.SetActive(!CommandList.activeSelf);
            }

        }
    }

    private void StartWave()
    {
        Debug.Log("StartingWave " + currentWave);

        enemiesToSpawn = 5 * currentWave;
        enemiesRemaining = enemiesToSpawn;
        Bench.SetActive(false);

        StartCoroutine(SpawnEnemies()); 
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            enemySpawn.SpawnEnemy(); 
            yield return new WaitForSeconds(Random.Range(enemySpawn.MinimumSpawnTime, enemySpawn.MaximumSpawnTime));
        }
    }

    public void EnemyDefeated()
    {
        enemiesRemaining--;

        if (enemiesRemaining <= 0)
        {
            Bench.SetActive(true);
            Debug.Log("Wave" + currentWave + "complete.");
            StartCoroutine(WaitBeforeNextWave());
        }
    }

    private IEnumerator WaitBeforeNextWave()
    {
        Debug.Log("RestTimeStarts " + waveRestTime + " ToNextWave");
        yield return new WaitForSeconds(waveRestTime); 
        currentWave++;
        Bench.SetActive(true);
        Debug.Log("Bench activated.");
        StartWave();
    }
}