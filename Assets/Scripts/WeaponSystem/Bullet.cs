using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damageAmount = 1;
    private PlayerController playerController;
    private BulletFactory bulletFactory; 

    public void Initialize(BulletFactory factory)
    {
        bulletFactory = factory; 
    }

    private void Start()
    {
        rb.velocity = transform.up * speed;
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemies"))
        {
            var enemyHealth = collision.GetComponent<HealthHandler>();
            if (enemyHealth != null)
            {
                var audioService = ServiceLocator.GetAudioService();
                audioService.HitSound();
                enemyHealth.getDamage(damageAmount);
                playerController.points += 10;
            }
            bulletFactory.ReturnBulletToPool(rb);
        }
        else if (collision.CompareTag("Walls"))
        {
            bulletFactory.ReturnBulletToPool(rb);
        }
    }
}