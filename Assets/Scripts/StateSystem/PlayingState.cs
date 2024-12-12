using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayingState : GameState
{
    private StateMachine state;

    public PlayingState(StateMachine manager) : base(manager)
    {
        state = manager; 
    }
    public override void Enter()
    {
        var uiManager = ServiceLocator.Instance.GetService<IUImanager>();
        uiManager.HideAllMenus(); 
        Time.timeScale = 1f; 
        Debug.Log("Entering Playing State");
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