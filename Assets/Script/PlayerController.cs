using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : IController
{
    public InputEvent GetInputEvent()
    {
        if (Input.GetKey(KeyCode.W))
        {
            return InputEvent.UP;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            return InputEvent.DOWN;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            return InputEvent.UP;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            return InputEvent.DOWN;
        }

        float mouseY = Input.GetAxis("Mouse Y");

        if (mouseY > 0)
        {
            return InputEvent.UP;
        }
        else if (mouseY < 0)
        {
            return InputEvent.DOWN;
        }

        return InputEvent.NONE;
    }
}
