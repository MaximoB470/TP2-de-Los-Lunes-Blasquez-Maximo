using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Commands/Logs Seconds From Start")]
public class LogSecondsFromStartCmd : Command
{
    private PlayerController controller;
    public override void execute()
    {
        Debug.Log(Time.realtimeSinceStartup);
    }
    public override void execute(string[] args)
    {
        Debug.Log(Time.realtimeSinceStartup);
    }
}

    

