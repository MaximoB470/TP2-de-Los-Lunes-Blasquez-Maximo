using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Commands/LotsOfPoints")]
public class LotsOfPoints : Command
{
    public override void execute()
    {
       var playerController = ServiceLocator.GetService<PlayerController>();
       playerController.points = 99999999;
       Debug.Log("Applying points");
    }
    public override void execute(string[] args)
    {
        var playerController = ServiceLocator.GetService<PlayerController>();
        playerController.points = 99999999;
        Debug.Log("Applying points");
    }
}