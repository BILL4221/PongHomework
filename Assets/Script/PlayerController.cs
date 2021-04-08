using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : IController
{
    private const KeyCode moveUp = KeyCode.W;
    private const KeyCode moveDown = KeyCode.S;
    public InputEvent GetInputEvent()
    {
        if (Input.GetKey(moveUp))
        {
            return InputEvent.UP;
        }
        else if (Input.GetKey(moveDown))
        {
            return InputEvent.DOWN;
        }

        return InputEvent.NONE;
    }
}
