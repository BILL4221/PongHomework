using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    private IController controller;

    private void Awake()
    {
        controller = new PlayerController();
    }

    private void Update()
    {        
        MovePaddle();
    }

    private void MovePaddle()
    {
        float direction = 0;
        InputEvent input = controller.GetInputEvent();

        switch (input)
        {
            case InputEvent.DOWN:
                direction = -1.0f;
                break;
            case InputEvent.UP:
                direction = 1.0f;
                break;
        }

        transform.position += Vector3.up * direction * Time.deltaTime;
    }

    public void SetController(IController controller)
    {
        this.controller = controller;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
