using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class VictoryState : GameState
    {
        public VictoryState(StateMachine manager) : base(manager) { }
        private StateMachine state;

        public override void Enter()
        {
             var managerService = ServiceLocator.GetService<ManagerService>();
            var uiManager = managerService.GetManager<UIManager>();
            Debug.Log("Entering Victory State");
            Time.timeScale = 0f;
            uiManager.ShowVictoryMenu();
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
            Debug.Log("Exiting Victory State");
        }
    }

