using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Controller
{
    public class MouseHandler : InputHandler
    {
        private string axisName;

        public MouseHandler(InputStyle style, string axisName) : base(style)
        {
            this.axisName = axisName;
        }
        public override InputEvent GetInput()
        {
            float axisValue = Input.GetAxis(axisName);

            if (axisValue > 0)
            {
                return InputEvent.UP;
            }
            else if (axisValue < 0)
            {
                return InputEvent.DOWN;
            }

            return InputEvent.NONE;
        }
    }
}
