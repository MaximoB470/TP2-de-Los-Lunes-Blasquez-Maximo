using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<EnemySpawn> spawners; 
    private int currentWave = 1; 
    private int enemiesToSpawn; 
    private int enemiesRemaining; 
    public float waveRestTime = 60f; 
    public GameObject Bench;
    public GameObject CommandList;

    private GameState currentState;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject victoryMenu;
    [SerializeField] private GameObject defeatMenu;

    private void Start()
    {
        if (spawners == null || spawners.Count == 0)
        {
            return;
        }
        ChangeState(new PlayingState(this));
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
        if (currentState != null)
        {
            currentState.Execute();
        }
    }

    private void StartWave()
    {
        Debug.Log("Iniciando oleada " + currentWave);

        enemiesToSpawn = 5 * currentWave;
        enemiesRemaining = enemiesToSpawn;
        Bench.SetActive(false);

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            EnemySpawn selectedSpawner = spawners[Random.Range(0, spawners.Count)];
            selectedSpawner.SpawnEnemy();
            yield return new WaitForSeconds(Random.Range(selectedSpawner.MinimumSpawnTime, selectedSpawner.MaximumSpawnTime));
        }
    }

    public void EnemyDefeated()
    {
        enemiesRemaining--;

        if (enemiesRemaining <= 0)
        {
            Bench.SetActive(true);
            Debug.Log("Oleada " + currentWave + " completada.");
            StartCoroutine(WaitBeforeNextWave());
        }
    }

    private IEnumerator WaitBeforeNextWave()
    {
        Debug.Log("Tiempo de descanso antes de la siguiente oleada: " + waveRestTime + " segundos.");
        yield return new WaitForSeconds(waveRestTime);
        currentWave++;
        Bench.SetActive(true);
        Debug.Log("Banco activado.");
        StartWave();
    }

    public void ChangeState(GameState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;

        if (currentState != null)
        {
            currentState.Enter();
        }
    }

    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
    }
    public void ShowVictoryMenu()
    {
        victoryMenu.SetActive(true);
    }
    public void ShowDefeatMenu()
    {
        defeatMenu.SetActive(true);
    }
    public void HideAllMenus()
    {
        pauseMenu.SetActive(false);
        victoryMenu.SetActive(false);
        defeatMenu.SetActive(false);
    }
}