using Pong.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.GameState
{
    public class SetupState : State
    {
        public SetupState(GameStateManager manager) : base(manager)
        {

        }

        public override void Start()
        {
            manager.SetupBoard();          
            manager.ResetScore();
            manager.uiManager.ShowScoreText(true);
            manager.ChangeState(new PreStartState(manager));
        }
    }
}
