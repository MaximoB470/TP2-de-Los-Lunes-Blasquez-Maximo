using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedState : GameState
{
    public PausedState(GameManager manager) : base(manager) { } 
    public override void Enter()
    {
        Debug.Log("Entering Paused State");
        Time.timeScale = 0f; 
        gameManager.ShowPauseMenu();
    }
    public override void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.ChangeState(new PlayingState(gameManager));
        }
    }
    public override void Exit()
    {
        Debug.Log("Exiting Paused State");
        Time.timeScale = 1f; 
    }
}