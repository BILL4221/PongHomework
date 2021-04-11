using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Controller
{
    public abstract class InputHandler
    {
        public InputHandler(InputStyle style)
        {
            InputStyle = style;
        }
        public InputStyle InputStyle { get; private set; }
        public abstract InputEvent GetInput();
    }
}
