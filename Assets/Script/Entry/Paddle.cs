using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Entry
{
    public class Paddle : MonoBehaviour
    {
        [SerializeField]
        private float speed = 5.0f;

        private const float maxHeight = 5.45f;

        private IController controller;

        private void Awake()
        {

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

            float yPos = transform.position.y + direction * speed * Time.deltaTime;
            yPos = Mathf.Clamp(yPos, -maxHeight, maxHeight);
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }

        public void SetController(IController controller)
        {
            this.controller = controller;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 1 >> 8)
            {
                
            }
        }
    }
}
