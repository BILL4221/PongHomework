using Pong.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Controller
{
    public class KeyHandler : InputHandler
    {
        private KeyCode upKey;
        private KeyCode downKey;

        public KeyHandler(InputStyle style, KeyCode up, KeyCode down) : base(style)
        {
            upKey = up;
            downKey = down;
        }
        public override InputEvent GetInput()
        {
            if (Input.GetKey(upKey))
            {
                return InputEvent.UP;
            }
            else if (Input.GetKey(downKey))
            {
                return InputEvent.DOWN;
            }

            return InputEvent.NONE;
        }
    }
}
