using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private int WaitAmount = 3;
    public bool grasssActive = false;

    [SerializeField] private GameObject healthTextObject;
    [SerializeField] private GameObject pointsTextObject;
    [SerializeField] private GameObject roundTextObject;
    [SerializeField] private GameObject roundTextObject2;
    [SerializeField] private GameObject waitTextObject;
    [SerializeField] private GameObject warningTextObject;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject victoryMenu;
    [SerializeField] private GameObject defeatMenu;

    private TextMeshProUGUI healthText;
    private TextMeshProUGUI pointsText;
    private TextMeshProUGUI roundText;
    private TextMeshProUGUI waitText;
    private TextMeshProUGUI warningText;

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
        if (warningTextObject != null)
        {
            warningText = warningTextObject.GetComponent<TextMeshProUGUI>();
        }
        UpdateHealth(playerController.HPTracker);
        UpdatePoints(playerController.points);
        UpdateRound(gameManager.currentWave);
    }

    private void Update()
    {
        UpdateHealth(playerController.HPTracker);
        UpdatePoints(playerController.points);
        UpdateRound(gameManager.currentWave);


        if (gameManager.isActive == true)
        {
            waitTextObject.SetActive(true);
            roundTextObject.SetActive(false);
            roundTextObject2.SetActive(false);
        }
        else
        {
            waitTextObject.SetActive(false);
            roundTextObject.SetActive(true);
            roundTextObject2.SetActive(true);
            ShopMenu.SetActive(false);
        }

        if(grasssActive == true)
        {
            if (grasssActive)
            {
                grasssActive = false; 
                StartCoroutine(Deactivate());
            }
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

    private IEnumerator Deactivate() 
    {
        if (warningTextObject != null)
        {
            warningTextObject.SetActive(true); 
            yield return new WaitForSeconds(WaitAmount); 
            warningTextObject.SetActive(false); 
        }
    }

    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);

    }
    public void ShowVictoryMenu()
    {
        victoryMenu.SetActive(true);
    }
    public void ShowDefeatMenu()
    {
        defeatMenu.SetActive(true);
    }
    public void HideAllMenus()
    {
        pauseMenu.SetActive(false);
        victoryMenu.SetActive(false);
        defeatMenu.SetActive(false);
    }
}