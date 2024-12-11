using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerService : MonoBehaviour
{
    public static ManagerService Instance { get; private set; }
    public GameManager GameManager { get; private set; }
    public UIManager UIManager { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            InitializeManagers();
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    private void InitializeManagers()
    {
        GameManager = FindObjectOfType<GameManager>();
        UIManager = FindObjectOfType<UIManager>();
    }
}