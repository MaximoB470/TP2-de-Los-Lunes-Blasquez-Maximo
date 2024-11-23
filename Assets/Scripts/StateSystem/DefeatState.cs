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
    }
    public override void Execute()
    {
        // A meter Logica
    }
    public override void Exit()
    {
        Debug.Log("Exiting Defeat State");
    }
}