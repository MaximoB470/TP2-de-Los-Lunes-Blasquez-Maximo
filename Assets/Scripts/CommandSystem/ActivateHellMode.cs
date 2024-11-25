using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Commands/HellGrass")]

public class ActivateHellMode : Command
{
    private UIManager controller;
    private GameObject hellGrass;

    public override void execute()
    {
        controller = FindObjectOfType<UIManager>();
        hellGrass = GameObject.Find("Grids/HellGrass");
        controller.grasssActive = true;
        hellGrass.SetActive(true);
    }
    public override void execute(string[] args)
    {
        execute(); 
    }
}