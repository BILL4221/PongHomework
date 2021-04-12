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
            manager.AddBall(manager.Config.SpawnBallStartPosition);
            Vector3 spawnBuffPos = new Vector3(Random.Range(manager.Config.minSpawnBuffXPos, manager.Config.maxSpawnBuffXPos) * Utilities.RandomSide(), Random.Range(manager.Config.minSpawnBuffYPos, manager.Config.maxSpawnBuffYPos), 0);
            manager.AddBuff(spawnBuffPos);
            manager.ResetPaddle();
            manager.SetupBoundary();
        }
    }
}
