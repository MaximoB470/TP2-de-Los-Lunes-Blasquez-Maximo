using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject healthTextObject;
    [SerializeField] private GameObject pointsTextObject;
    [SerializeField] private GameObject roundTextObject;
    [SerializeField] private GameObject waitTextObject;

    private TextMeshProUGUI healthText;
    private TextMeshProUGUI pointsText;
    private TextMeshProUGUI roundText;
    private TextMeshProUGUI waitText;

    private PlayerController playerController;
    private GameManager gameManager;

    public GameObject ShopMenu;

    private void Start()
    {
        if (playerController == null)
        {
            playerController = FindObjectOfType<PlayerController>();
        }
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
        if (healthTextObject != null)
        {
            healthText = healthTextObject.GetComponent<TextMeshProUGUI>();
        }
        if (pointsTextObject != null)
        {
            pointsText = pointsTextObject.GetComponent<TextMeshProUGUI>();
        }

        if (roundTextObject != null)
        {
            roundText = roundTextObject.GetComponent<TextMeshProUGUI>();
        }
        if (waitTextObject != null)
        {
            waitText = waitTextObject.GetComponent<TextMeshProUGUI>();
        }
        UpdateHealth(playerController.HPTracker);
        UpdatePoints(playerController.points);
        UpdateRound(gameManager.currentWave);
        UpdateWait(gameManager.waveRestTime);
    }

    private void Update()
    {
        UpdateHealth(playerController.HPTracker);
        UpdatePoints(playerController.points);
        UpdateRound(gameManager.currentWave);
        UpdateWait(gameManager.waveRestTime);

        if (gameManager.isActive == true) 
        { 
            waitTextObject.SetActive(true);
            roundTextObject.SetActive(false);
        }
        else
        {
            waitTextObject.SetActive(false);
            roundTextObject.SetActive(true);
            ShopMenu.SetActive(false);
        }

    }

    public void ExitShop()
    {
        ShopMenu.SetActive(false);
    }

    public void UpdateHealth(int health)
    {
        if (healthText != null)
        {
            healthText.text = $"{health}";
        }
    }
    public void UpdatePoints(int points)
    {
        if (pointsText != null)
        {
            pointsText.text = $"{points}";
        }
    }
    public void UpdateRound(int round)
    {
        if (roundText != null)
        {
            roundText.text = $"{round}";
        }
    }
    public void UpdateWait(float waitTime)
    {
        if (waitText != null)
        {
            waitText.text = $"{waitTime:F1}"; 
        }
    }
}