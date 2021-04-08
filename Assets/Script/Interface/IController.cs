using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputEvent
{
    NONE,
    UP,
    DOWN
}

public interface IController
{
    InputEvent GetInputEvent();
}
