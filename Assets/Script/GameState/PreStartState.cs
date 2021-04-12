using Pong.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.GameState
{
    public class PreStartState : State
    {
        private const float ShowTextTime = 3.0f;
        private float timer = 0.0f;
        public PreStartState(GameStateManager manager) : base(manager)
        {

        }

        public override void Start()
        {
            manager.uiManager.ShowEndRoundScoreText(true);
        }

        public override void Update()
        {
            timer += Time.deltaTime;
            if (timer > ShowTextTime)
            {
                manager.ChangeState(new PlayState(manager));
            }
        }

        public override void Exit()
        {
            manager.uiManager.ShowEndRoundScoreText(false);
        }
    }
}
