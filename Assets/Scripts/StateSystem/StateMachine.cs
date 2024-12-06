using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine 
{
    public GameState currentState;

    public void Update()
    {
        if (currentState != null)
        {
            currentState.Execute();
        }
    }
    public void ChangeState(GameState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;

        if (currentState != null)
        {
            currentState.Enter();
        }
    }
}
