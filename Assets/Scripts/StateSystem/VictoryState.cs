using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VictoryState : GameState
{
    public VictoryState(StateMachine manager) : base(manager) { }

    public override void Enter()
    {
        var uiManager = ServiceLocator.Instance.GetService<IUImanager>();
        var audioService = new AudioService();
        ServiceLocator.Instance.Register<IAudioService>(audioService); 

        if (uiManager != null)
        {
            uiManager.ShowVictoryMenu();
        }
        if (audioService != null)
        {
            audioService.StopBackgroundMusic();
        }
        Time.timeScale = 0f;
    }

    public override void Execute()
    {
        Debug.Log("Not Used");
    }

    public override void Exit()
    {
        Debug.Log("Exiting Victory State");
    }
}