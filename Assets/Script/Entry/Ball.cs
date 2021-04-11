using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pong.Util;

namespace Pong.Entry
{
    public class Ball : MonoBehaviour
    {
        private float speed;
        private Vector3 direction;
        private float multiplySpeed;
        private void Awake()
        {
            speed = 5.0f;
            multiplySpeed = 1.0f;
            direction = new Vector3(Random.Range(0.2f, 1) * Utilities.RandomSide(), Random.Range(-1f, 1), 0).normalized;
        }

        private void Update()
        {
            transform.position += Time.deltaTime * speed * multiplySpeed * direction;
        }

        public void BounchWithPaddle()
        {
            float xDireciton = -1 * direction.x;
            direction = new Vector3(xDireciton, direction.y, 0);
        }
        public void BounchWithWall()
        {
            float yDireciton = -1 * direction.y;
            direction = new Vector3(direction.x, yDireciton, 0);
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }

        public void SetMultiplySpeed(float multiply)
        {
            multiplySpeed = multiply;
        }
    }
}
