using Pong.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Entry
{
    public class FastBuff : Buff
    {
        [SerializeField]
        private float multiplySpeed;
        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer(Utilities.BallLayer))
            {
                Ball ball = collision.GetComponent<Ball>();
                ball.SetMultiplySpeed(multiplySpeed);
                manager.DestroyEntry(gameObject);
            }
        }
    }
}
