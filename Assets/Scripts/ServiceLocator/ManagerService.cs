using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerService : IManager
{
    private GameManager gameManager;
    private UIManager uiManager;
    private ShopManager shopManager;
    public ManagerService() 
    {
        gameManager = new GameManager();  
        uiManager = new UIManager();
        shopManager = new ShopManager();    
    }
    public T GetManager<T>() where T : class
    { 
        return ServiceLocator.GetService<T>();
    }
}