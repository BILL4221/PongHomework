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
        }

    }
}
