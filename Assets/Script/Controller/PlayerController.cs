using Pong.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Controller
{
    public enum InputStyle
    {
        WASD,
        Arrow,
        Mouse
    }

    public class PlayerController : BaseController
    {
        private Dictionary<InputStyle, bool> inputEnableDicts;
        private List<InputHandler> handlerList;

        public PlayerController(GameStateManager manager) : base(manager)
        {
            inputEnableDicts = new Dictionary<InputStyle, bool>();
            handlerList = new List<InputHandler>();
        }

        public override InputEvent GetInputEvent()
        {
            foreach (var handler in handlerList)
            {
                if (inputEnableDicts[handler.InputStyle])
                {
                    InputEvent input = handler.GetInput();
                    if (input != InputEvent.NONE)
                    {
                        return input;
                    }
                }
            }
            return InputEvent.NONE;
        }

        public void RegisterKeyInput(InputStyle style, KeyCode up, KeyCode down)
        {
            KeyHandler handler = new KeyHandler(style, up, down);
            inputEnableDicts[style] = true;
            handlerList.Add(handler);
        }

        public void RegisterMouseInput(InputStyle style, string axis)
        {
            MouseHandler handler = new MouseHandler(style, axis);
            inputEnableDicts[style] = true;
            handlerList.Add(handler);
        }

        public void EnableInputStyle(InputStyle style, bool enable)
        {
            if (inputEnableDicts.ContainsKey(style))
            {
                inputEnableDicts[style] = enable;
            }

            Debug.LogWarning("No Input Style: " + style + "in this controller");
        }

        public bool GetEnableInputStyle(InputStyle style)
        {
            if (inputEnableDicts.ContainsKey(style))
            {
                return inputEnableDicts[style];
            }

            Debug.LogWarning("No Input Style: " + style + "in this controller");
            return false;
        }
    }
}
