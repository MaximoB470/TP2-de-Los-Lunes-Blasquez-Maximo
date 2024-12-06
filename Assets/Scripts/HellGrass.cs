using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HellGrass : MonoBehaviour
{
     private int damageAmount = 2; 
    private bool isPlayerInside = false; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            isPlayerInside = true;
            ApplyDamage(collision.gameObject);
        }
    }
    private void ApplyDamage(GameObject player)
    {
        HealthHandler healthHandler = player.GetComponent<HealthHandler>();
        if (healthHandler != null)
        {
            healthHandler.GetDamage(damageAmount);
        }
    }
}