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
            Debug.Log("Victory State Working Correctly");
            var gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.ChangeState(new VictoryState(gameManager));
                gameManager.isActive = false;
            }
        }
    }
}