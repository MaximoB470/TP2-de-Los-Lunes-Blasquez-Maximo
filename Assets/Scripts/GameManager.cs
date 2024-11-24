using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<EnemySpawn> spawners; 
    public int currentWave = 1; 
    private int enemiesToSpawn; 
    public int enemiesRemaining; 
    public int waveRestTime = 30; 
    public GameObject Bench;
    public GameObject CommandList;

    private GameState currentState;
    
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject victoryMenu;
    [SerializeField] private GameObject defeatMenu;

    public bool isActive = false;
    public bool ForceWave;

    private void Start()
    {
        var audioService = new AudioService();
        ServiceLocator.RegisterAudioService(audioService);
        audioService.BackgroundMusic();

        Bench.SetActive(false);
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
        if(ForceWave == true) 
        {
            StartCoroutine(WaitBeforeNextWave());
            enemiesRemaining = 0;
        }
    }
    private void StartWave()
    {
        enemiesToSpawn = 5 * currentWave;
        enemiesRemaining = enemiesToSpawn;
        Bench.SetActive(false);

        StartCoroutine(SpawnEnemies());

        isActive = false;
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
            StartCoroutine(WaitBeforeNextWave());
            isActive = true;
        }
    }
    public IEnumerator WaitBeforeNextWave()
    {
        Debug.Log("Rest Time " + waveRestTime);
        Debug.Log("BenchActive");
        Bench.SetActive(true);
        yield return new WaitForSeconds(waveRestTime);
        currentWave++;
        StartWave();
        ForceWave = false;
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