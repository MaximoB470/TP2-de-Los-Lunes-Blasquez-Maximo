using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Commands/SkipRound")]


public class SkipRound : Command
{
    public override void execute()
    {
        var gameManager = ServiceLocator.GetService<GameManager>();
        gameManager.ForceWave = true;

        
    }
    public override void execute(string[] args)
    {
        var gameManager = ServiceLocator.GetService<GameManager>();
        gameManager.ForceWave = true;
    }
}
