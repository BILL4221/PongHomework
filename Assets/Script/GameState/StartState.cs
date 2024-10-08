﻿using Pong.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.GameState
{
    public class StartState : State
    {
        public StartState(GameStateManager manager) : base(manager)
        {

        }

        public override void Start()
        {
            manager.uiManager.ShowStartText(true);
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                manager.ChangeState(new SetupState(manager));
            }
        }

        public override void Exit()
        {
            manager.uiManager.ShowStartText(false);
        }
    }
}
