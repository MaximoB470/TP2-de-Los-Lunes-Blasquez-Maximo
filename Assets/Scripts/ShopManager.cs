using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private int dashCost = 300;                               
    [SerializeField] private int escapeCost = 2000;
    [SerializeField] private int MEedkitCost = 300;
    public GameObject MK;
    private StateMachine state;

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
            playerController.points -= escapeCost;
            var gameManager = FindObjectOfType<GameManager>();
            state.ChangeState(new VictoryState(state));
            gameManager.isActive = false;
            
        }
    }
}