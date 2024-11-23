using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private int dashCost = 300;                 
    [SerializeField] private int medkitCost = 150;               
    [SerializeField] private int escapeCost = 2000;              

    public void BuyDash()
    {
        if (playerController.points >= dashCost)
        {
            playerController.points -= dashCost;
            playerController.UnlockDash();
        }
    }
    public void BuyMedkit()
    {
        //if (playerController.points >= medkitCost)
        //{
        //    playerController.points -= medkitCost;
        //    playerController.Heal(1); // Asume que este método cura al jugador (por ejemplo, +1 vida).
        //    Debug.Log("Botiquín comprado");
        //}
        //else
        //{
        //    Debug.Log("No tienes suficientes puntos para el Botiquín.");
        //}
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