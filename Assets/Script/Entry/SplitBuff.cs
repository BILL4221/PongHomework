using Pong.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Entry
{
    public class SplitBuff : Buff
    { 
        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer(Utilities.BallLayer))
            {
                Vector3 ballPos = transform.position;
                manager.AddBall(transform.position);
                manager.DestroyEntry(gameObject);
            }
        }
    }
}

