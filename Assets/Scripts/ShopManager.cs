using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopManager
{
    void BuyDash();
    void BuyMedKit();
    void BuyEscape();
}
public class ShopManager : MonoBehaviour, IShopManager
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private int dashCost = 300;                               
    [SerializeField] private int escapeCost = 2000;
    [SerializeField] private int MEedkitCost = 300;
    public GameObject MK;
    private StateMachine state;

    public void Awake()
    {
        ServiceLocator.Register<IShopManager>(this);
    }

    public void BuyDash()
    {
        if (playerController.points >= dashCost)
        {
            playerController.points -= dashCost;
            playerController.UnlockDash();
        }
    }
    public void BuyMedKit()
    {
        if (playerController.points >= MEedkitCost)
        {
            playerController.points -= MEedkitCost;
            MK.SetActive(true);
        }
    }
    public void BuyEscape()
    {
        if (playerController.points >= escapeCost)
        {
            state = new StateMachine();
            playerController.points -= escapeCost;
            var gameManager = ServiceLocator.GetService<GameManager>();
            state.ChangeState(new VictoryState(state));
            gameManager.isActive = false;
            
        }
    }
}