using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class VictoryState : GameState
    {
        public VictoryState(GameManager manager) : base(manager) { }
        public override void Enter()
        {
            Debug.Log("Entering Victory State");
            Time.timeScale = 0f;
            gameManager.ShowVictoryMenu();
        }
        public override void Execute()
        {
            //Meter Logica
        }

        public override void Exit()
        {
            Debug.Log("Exiting Victory State");
        }
    }

