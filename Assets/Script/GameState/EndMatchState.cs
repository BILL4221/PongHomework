using Pong.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.GameState
{
    public class EndMatchState : State
    {
        public EndMatchState(GameStateManager manager) : base(manager)
        {

        }

        public override void Start()
        {
            manager.ClearAllEntry();
            manager.uiManager.ShowEndText(true);
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                manager.ChangeState(new StartState(manager));
            }
        }

        public override void Exit()
        {
            manager.uiManager.ShowEndText(false);
            manager.uiManager.ShowScoreText(false);
            manager.ClearBoard();
        }
    }
}
