using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public interface IGameManager
{
    void StartWave();
    void EnemyDefeated();
    IEnumerator WaitBeforeNextWave(); 
}
public class GameManager : MonoBehaviour, IGameManager
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private List<EnemySpawn> spawners; 
    public int currentWave = 1; 
    private int enemiesToSpawn; 
    public int enemiesRemaining; 
    public int waveRestTime = 30; 
    public GameObject Bench;
    public GameObject CommandList;

    private StateMachine state;
    
    public bool isActive = false;
    public bool ForceWave;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
            return; // Salir de Awake si no es la instancia principal
        }
        ServiceLocator.Instance.Register<GameManager>(this);
    }

    private void Start()
    {
        var audioService = new AudioService();
        ServiceLocator.Instance.Register<IAudioService>(audioService);
        audioService.BackgroundMusic();
        Bench.SetActive(false);
        if (spawners == null || spawners.Count == 0)
        {
            return;
        }
        state = new StateMachine();
        state.ChangeState(new PlayingState(state));
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
        if(ForceWave == true) 
        {
            StartCoroutine(WaitBeforeNextWave());
            enemiesRemaining = 0;
        }
        state.Update();
    }
    public void StartWave()
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
        Bench.SetActive(true);
        yield return new WaitForSeconds(waveRestTime);
        currentWave++;
        StartWave();
        ForceWave = false;
    }
}