using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatState : GameState
{
    public DefeatState(StateMachine manager) : base(manager) { }
    private StateMachine state;
    public override void Enter()
    {
        var managerService = ServiceLocator.GetService<ManagerService>();
        var uiManager = managerService.GetManager<UIManager>();
        state = new StateMachine();
        Debug.Log("Entering Defeat State");
        Time.timeScale = 0f; 
        uiManager.ShowDefeatMenu();
        var audioService = new AudioService();
        ServiceLocator.Register<IAudioService>(audioService);
        audioService.StopBackgroundMusic();
    }
    public override void Execute()
    {
        Debug.Log("Not Used");
    }
    public override void Exit()
    {
        Debug.Log("Exiting Defeat State");
    }
}