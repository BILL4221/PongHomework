using Pong.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.GameState
{
    public abstract class State
    {
        public GameStateManager manager;

        public State(GameStateManager manager)
        {
            this.manager = manager;
        }

        public virtual void Start()
        { 

        }

        public virtual void Update()
        {
            
        }

        public virtual void Exit()
        {

        }
    }
}
