using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{
    protected GameManager gameManager;

    public GameState(GameManager manager)
    {
        gameManager = manager;
    }
    public abstract void Enter();   
    public abstract void Execute(); 
    public abstract void Exit();    
}