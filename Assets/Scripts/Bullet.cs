using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 20f;
    public Rigidbody2D rb;
    public int damageAmount = 1;
    private PlayerController playerController;

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
                enemyHealth.getDamage(damageAmount);
                Destroy(gameObject);
              
                playerController.points += 10;
            }
        }
    }
}