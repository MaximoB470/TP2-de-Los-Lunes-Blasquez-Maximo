using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingState : GameState
{
    public PlayingState(GameManager manager) : base(manager) { } 
    public override void Enter()
    {
        Debug.Log("Entering Playing State");
        Time.timeScale = 1f;
        gameManager.HideAllMenus();
    }
    public override void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.ChangeState(new PausedState(gameManager));
        }
    }
    public override void Exit()
    {
        Debug.Log("Exiting Playing State");
    }
}