using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Commands/ApplyDash")]
public class ApplyDash : Command
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
            controller.UnlockDash();
            Debug.Log("Applied Dash");
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
            controller.UnlockDash();
            Debug.Log("Applied Dash");
        }
    }
}
