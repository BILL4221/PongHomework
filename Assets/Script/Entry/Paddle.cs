using Pong.Controller;
using Pong.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Entry
{
    public class Paddle : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        private BaseController controller;

        public Action<Paddle, Collider2D> OnHitBall;

        private void Awake()
        {
            controller = null;
        }

        private void Update()
        {
            MovePaddle();
        }

        private void MovePaddle()
        {
            if (controller == null)
            {
                return;
            }

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
            yPos = Mathf.Clamp(yPos, -Utilities.MaxBoardHeight, Utilities.MaxBoardHeight);
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer(Utilities.BallLayer))
            {
                // TODO: shouldn't use getcomponent in update loop
                Ball ball = collision.GetComponent<Ball>();
                ball.BounchWithPaddle();
            }
        }

        public void SetPaddleSpeed(float speed)
        {
            this.speed = speed;
        }

        public void SetController(BaseController controller)
        {
            this.controller = controller;
        }

        public BaseController GetController()
        {
            return controller;
        }

    }
}
