using Pong.Entry;
using Pong.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Wall
{
    public class Wall : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer(Utilities.BallLayer))
            {
                // TODO: shouldn't use getcomponent in run time
                Ball ball = collision.GetComponent<Ball>();
                ball.BounchWithWall();
            }
        }
    }
}
