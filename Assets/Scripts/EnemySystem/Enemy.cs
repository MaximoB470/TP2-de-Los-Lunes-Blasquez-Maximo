using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float detectionRange = 10f;
    public int damageAmount = 1;
    private ObjectPool<Enemy> enemyPool;

    private Transform player;
    private HealthHandler healthHandler;
    public void Initialize(float moveSpeed, float detectionRange, int damageAmount)
    {
        this.moveSpeed = moveSpeed;
        this.detectionRange = detectionRange;
        this.damageAmount = damageAmount;
    }
    private void Start()
    {
        var playerController = ServiceLocator.Instance.GetService<PlayerController>();
        if (playerController != null)
        {
            player = playerController.transform;
        }
        healthHandler = gameObject.AddComponent<HealthHandler>();
        healthHandler.maxHp = 1;
        healthHandler.Awake();
    }
    private void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
        }
        if (healthHandler.Life <= 0)
        {
            OnDefeated();
        }
    }
    private void MoveTowardsPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            Vector2 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            var playerHealth = collision.gameObject.GetComponent<HealthHandler>();
            playerHealth?.GetDamage(damageAmount);
            var audioService = ServiceLocator.Instance.GetService<IAudioService>();
            audioService?.HitSound();
            enemyPool.ReturnObject(this);
        }
    }
    private void OnDefeated()
    {
        var gameManager = ServiceLocator.Instance.GetService<GameManager>();
        gameManager?.EnemyDefeated();
    }
}