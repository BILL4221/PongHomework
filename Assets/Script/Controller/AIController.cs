using Pong.Entry;
using Pong.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Controller
{
    public class AIController : BaseController
    {
        private Paddle paddle;
        private float height;

        public AIController(GameStateManager manager, Paddle paddle) : base(manager)
        {
            this.paddle = paddle;
            var box2D = paddle.GetComponent<BoxCollider2D>();
            height = box2D.size.y * this.paddle.transform.localScale.y;
        }

        public override InputEvent GetInputEvent()
        {
            var ballList = manager.GetBallList();
            float minDistance = float.MaxValue;
            Ball nearestBall = null;
            foreach (var ball in ballList)
            {
                float distance = Vector3.Distance(paddle.transform.position, ball.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestBall = ball;
                }
            }
            if (nearestBall != null)
            {
                float distanceX = paddle.transform.position.x - nearestBall.transform.position.x;
                Vector3 ballDirection = nearestBall.GetBallSpeedVector();
                
                // ball direction go to this paddle
                if (ballDirection.x * distanceX > 0)
                {
                    float xHitTime = distanceX / ballDirection.x;
                    float ballTargetY = nearestBall.transform.position.y + ballDirection.y * xHitTime;
                    if (paddle.transform.position.y < ballTargetY)
                    {
                        return InputEvent.UP;
                    }
                    else
                    {
                        return InputEvent.DOWN;
                    }
                }
                else
                {
                    if (paddle.transform.position.y < 0)
                    {
                        return InputEvent.UP;
                    }
                    else
                    {
                        return InputEvent.DOWN;
                    }
                }
            }
            else
            {
                return InputEvent.NONE;
            }
        }
    }
}