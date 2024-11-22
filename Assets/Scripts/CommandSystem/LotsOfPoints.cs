using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Commands/LotsOfPoints")]
public class LotsOfPoints : Command
{
    private PlayerController controller;
    public override void execute()
    {
        if (controller == null)
        {
            controller = FindObjectOfType<PlayerController>();
        }
        if (controller != null)
        {
            controller.points = 99999999;
            Debug.Log("Applying points");
        }
    }
    public override void execute(string[] args)
    {
        if (controller == null)
        {
            controller = FindObjectOfType<PlayerController>();
        }
        if (controller != null)
        {
            controller.points = 99999999;
            Debug.Log("Applying points");
        }
    }
}