using Pong.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.GameState
{
    public class EndRoundState : State
    {
        public EndRoundState(GameStateManager manager) : base(manager)
        {

        }

        public override void Start()
        {
            manager.ClearAllEntry();
            manager.ChangeState(new PreStartState(manager));
        }
    }
}