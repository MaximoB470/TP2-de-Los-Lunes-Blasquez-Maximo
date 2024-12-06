using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedState : GameState
{
    public PausedState(StateMachine managment) : base(managment) { }
    private StateMachine state;
    public override void Enter()
    {
        var managerService = ServiceLocator.GetService<ManagerService>();
        var uiManager = managerService.GetManager<UIManager>();
        Debug.Log("Entering Paused State");
        Time.timeScale = 0f; 
        uiManager.ShowPauseMenu();
    }
    public override void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            state.ChangeState(new PlayingState(state));
        }
    }
    public override void Exit()
    {
        Debug.Log("Exiting Paused State");
        Time.timeScale = 1f; 
    }
}