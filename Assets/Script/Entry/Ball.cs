using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pong.Entry
{
    public class Ball : MonoBehaviour
    {
        private float speed;
        private Vector3 direction;

        private void Awake()
        {
            speed = 1.0f;
            direction = new Vector3(Random.Range(0f, 1), Random.Range(0f, 1), 0).normalized;
        }

        private void Update()
        {
            transform.position += Time.deltaTime * speed * direction;
        }
    }
}
