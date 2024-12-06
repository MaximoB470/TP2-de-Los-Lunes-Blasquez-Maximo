using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerService : MonoBehaviour, IManager
{
    public void RegisterManagers()
    {
        ServiceLocator.Register<GameManager>(FindObjectOfType<GameManager>());
        ServiceLocator.Register<UIManager>(FindObjectOfType<UIManager>());
        ServiceLocator.Register<ShopManager>(FindObjectOfType<ShopManager>());
    }
    public T GetManager<T>() where T : class
    {
        RegisterManagers();
        return ServiceLocator.GetService<T>();
    }
}