using Pong.Entry;
using Pong.Manager;
using Pong.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.GameState
{
    public class PlayState : State
    {
        public PlayState(GameStateManager manager) : base(manager)
        {

        }

        public override void Start()
        {
            manager.AddBall(Vector3.zero);
            Vector3 spawnBuffPos = new Vector3(Random.Range(2.0f, 8.0f) * Utilities.RandomSide(), Random.Range(-5.0f, 5.0f), 0);
            manager.AddBuff(spawnBuffPos);
            manager.ResetPaddle();
            manager.SetupBoundary();
        }
    }
}
