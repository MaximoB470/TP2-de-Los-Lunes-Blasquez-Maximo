using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;                      
    public float detectionRange = 10f;
    public int Life;
    private Transform player;
    public int damageAmount = 1;
    private HealthHandler healthHandler;
    private GameManager GameManager;
    public enum EntityType
    {
        Player,
        Enemy,
        Npc,
        Tree,
        House,
        Door
    }
    public interface IEntitiesService
    {
        public T GetEntity<T>(EntityType entityType) where T : MonoBehaviour;
    }
    public class EntityService : IEntitiesService
    {
        private Dictionary<EntityType, List<MonoBehaviour>> entitiesByType;
        public T GetEntity<T>(EntityType entityType) where T : MonoBehaviour
        {
            MonoBehaviour entityFound = null;
            //Find the entity
            return entityFound as T;
        }
    }
    private void Start()
    {

        var playerController = ServiceLocator.GetService<IEntitiesService>().GetEntity<PlayerController>(EntityType.Player);
        healthHandler = gameObject.AddComponent<HealthHandler>();
        healthHandler.maxHp = 1;
        healthHandler.Awake();
        GameManager = FindObjectOfType<GameManager>();

        if (playerController != null)
        {
            player = playerController.transform;
        }
    }
    private void Update()
    {
        MoveTowardsPlayer();

        if (healthHandler.Life <= 0)
        {
            GameManager.EnemyDefeated(); 
            Destroy(gameObject); 
        }
    }
    private void MoveTowardsPlayer()
    {
    
        if (Vector2.Distance(transform.position, player.position) <= detectionRange)
        { 
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            Vector2 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            var playerHealth = collision.gameObject.GetComponent<HealthHandler>();
            if (playerHealth != null)
            {
                GameManager.EnemyDefeated();
                playerHealth.GetDamage(damageAmount);
                var audioService = new AudioService();
                ServiceLocator.Register<IAudioService>(audioService);
                audioService.HitSound();

            }
            Destroy(gameObject);
        }
    }


}

