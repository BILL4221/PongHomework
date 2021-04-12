using Pong.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Controller
{
    public enum InputEvent
    {
        NONE,
        UP,
        DOWN
    }

    public abstract class BaseController
    {
        protected GameStateManager manager;
        public BaseController(GameStateManager manager)
        {
            this.manager = manager;
        }
        public abstract InputEvent GetInputEvent();
    }
}
