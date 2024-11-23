using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Commands/SkipRound")]


public class SkipRound : Command
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
            manager.ForceWave = true;

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
            manager.ForceWave = true;

        }
    }

}
