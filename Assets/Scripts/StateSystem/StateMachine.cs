using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public GameState currentState;

    public void Start()
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
