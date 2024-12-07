using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Commands/ApplyDash")]
public class ApplyDash : Command
{
 
    public override void execute()
    {
        var playerController = ServiceLocator.GetService<PlayerController>();
        playerController.UnlockDash();
        Debug.Log("Applied Dash");
    }
    public override void execute(string[] args)
    {
       var playerController = ServiceLocator.GetService<PlayerController>();
       playerController.UnlockDash();
       Debug.Log("Applied Dash");
    }
}
