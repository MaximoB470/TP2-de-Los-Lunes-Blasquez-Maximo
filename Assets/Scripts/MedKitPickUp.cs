using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MedKitPickUp : MonoBehaviour, Iinteractable
{
    [SerializeField] private int healAmount = 2;
    public GameObject MedKit;
    public void interaction()
    {
        var player = ServiceLocator.Instance.GetService<PlayerController>();
        HealthHandler wrapper = player.GetComponent<HealthHandler>();
        wrapper.Heal(healAmount);
        MedKit.SetActive(false); 
    }
}