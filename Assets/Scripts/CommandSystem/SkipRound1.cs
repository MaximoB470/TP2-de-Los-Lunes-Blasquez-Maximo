using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Commands/ForceSkipRound")]


public class ForceSkipRound : Command
{
    private GameManager manager;

    public override void execute()
    {
        if (manager == null)
        {
            manager = FindObjectOfType<GameManager>();
        }
        if (manager != null)
        {
            manager.StartWave();
            manager.currentWave++;
        }
    }
    public override void execute(string[] args)
    {
        if (manager == null)
        {
            manager = FindObjectOfType<GameManager>();
        }
        if (manager != null)
        {
            manager.StartWave();
            manager.currentWave++;
        }
    }
}
