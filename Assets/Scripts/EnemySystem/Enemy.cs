using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;          
    public Transform player;               
    public float detectionRange = 10f;
    public int Life;
    public int damageAmount = 1;
    private HealthHandler healthHandler;
    private GameManager GameManager;
    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("player").transform;
        }
        healthHandler = gameObject.AddComponent<HealthHandler>();
        healthHandler.maxHp = 1;
        healthHandler.Awake();
        GameManager = FindObjectOfType<GameManager>();
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
                playerHealth.getDamage(damageAmount);
            }
            Destroy(gameObject);
        }
    }


}

