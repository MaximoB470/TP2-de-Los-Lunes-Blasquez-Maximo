using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingState : GameState
{
    public PlayingState(StateMachine manager) : base(manager) { }

    private UIManager uiManager; 
    private StateMachine state;  
    public override void Enter()
    {
        Debug.Log("Entering Playing State");

        if (uiManager == null)
        {
            uiManager = Object.FindObjectOfType<UIManager>();
        }
        Time.timeScale = 1f;
        uiManager.HideAllMenus(); 
    }
    public override void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            state.ChangeState(new PausedState(state)); 
        }
    }
    public override void Exit()
    {
        Debug.Log("Exiting Playing State");
    }
}