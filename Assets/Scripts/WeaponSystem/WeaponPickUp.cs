using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour, Iinteractable
{
    public GameObject Weapon; 
    private PlayerController player; 

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerController>();
    }

    public void interaction()
    {
        if (player != null && Weapon != null)
        {
            player.EquipWeapon(Weapon); 
            Destroy(this.gameObject);    
        }
    }
}