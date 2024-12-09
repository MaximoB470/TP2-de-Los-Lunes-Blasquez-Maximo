using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class VictoryState : GameState
    {
        public VictoryState(StateMachine manager) : base(manager) { }
        private StateMachine state;
        public override void Enter()
        {
            state = new StateMachine();
            var uiManager = ServiceLocator.Instance.GetService<UIManager>();
            var audioService = new AudioService();
            ServiceLocator.Instance.Register<IAudioService>(audioService);
            ServiceLocator.Instance.Register<IUImanager>(uiManager);
            uiManager.ShowVictoryMenu();
            audioService.StopBackgroundMusic();
            Time.timeScale = 0f;

            Debug.Log("Entering Victory State");
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

