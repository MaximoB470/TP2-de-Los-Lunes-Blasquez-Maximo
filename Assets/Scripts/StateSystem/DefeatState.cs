using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatState : GameState
{
    public DefeatState(StateMachine manager) : base(manager) { }
    private StateMachine state;
    public override void Enter()
    {
        state = new StateMachine();
        var uiManager = ServiceLocator.Instance.GetService<IUImanager>();
        uiManager.ShowDefeatMenu();
        Time.timeScale = 0f; 
        
        Debug.Log("Entering Defeat State");
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