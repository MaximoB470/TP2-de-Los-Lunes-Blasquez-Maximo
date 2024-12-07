using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Commands/ForceSkipRound")]
public class ForceSkipRound : Command
{
    public override void execute()
    {
        var gameManager = ServiceLocator.GetService<GameManager>();
        gameManager.StartWave();
        gameManager.currentWave++;
    }
    public override void execute(string[] args)
    {
        var gameManager = ServiceLocator.GetService<GameManager>();
        gameManager.StartWave();
        gameManager.currentWave++;
    }
}
