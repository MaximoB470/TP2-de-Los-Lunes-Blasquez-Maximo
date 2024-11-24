using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatState : GameState
{
    public DefeatState(GameManager manager) : base(manager) { }
    public override void Enter()
    {
        Debug.Log("Entering Defeat State");
        Time.timeScale = 0f; 
        gameManager.ShowDefeatMenu();
        var audioService = ServiceLocator.GetAudioService();
        audioService.StopBackgroundMusic();
    }
    public override void Execute()
    {
        Debug.Log("Not Used");
    }
    public override void Exit()
    {
        Debug.Log("Exiting Defeat State");
    }
}