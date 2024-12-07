using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface IUImanager
{
    void ExitShop();
    void UpdateHealth(int health);
    void UpdatePoints(int points);
    void UpdateRound(int round);
    void ShowPauseMenu();
    void ShowVictoryMenu();
    void ShowDefeatMenu();
    void HideAllMenus();
}
public class UIManager : MonoBehaviour, IUImanager
{ 
    [SerializeField] private GameObject healthTextObject;
    [SerializeField] private GameObject pointsTextObject;
    [SerializeField] private GameObject roundTextObject;
    [SerializeField] private GameObject roundTextObject2;
    [SerializeField] private GameObject waitTextObject;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject victoryMenu;
    [SerializeField] private GameObject defeatMenu;

    private TextMeshProUGUI healthText;
    private TextMeshProUGUI pointsText;
    private TextMeshProUGUI roundText;

    public GameObject ShopMenu;


    private void Start()
    {
        ServiceLocator.Register<IUImanager>(this);
        var playerController = ServiceLocator.GetService<PlayerController>();
        var gameManager = ServiceLocator.GetService<GameManager>();
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
        UpdateHealth(playerController.HPTracker);
        UpdatePoints(playerController.points);
        UpdateRound(gameManager.currentWave);
    }

    private void Update()
    {
        var gameManager = ServiceLocator.GetService<GameManager>();
        var playerController = ServiceLocator.GetService<PlayerController>();
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
        if (pauseMenu != null)
            pauseMenu.SetActive(false);
        if (victoryMenu != null)
            victoryMenu.SetActive(false);
        if (defeatMenu != null)
            defeatMenu.SetActive(false);
    }
}