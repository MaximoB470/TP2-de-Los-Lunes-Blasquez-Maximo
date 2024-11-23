using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private string LevelSceneName = "LevelScene";
    public void GoToMainMenu()
    {
        if (!string.IsNullOrEmpty(LevelSceneName))
        {
            SceneManager.LoadScene(LevelSceneName);
        }
    }
}
