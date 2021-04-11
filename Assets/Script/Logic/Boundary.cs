using Pong.Entry;
using Pong.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Logic
{
    public class Boundary : MonoBehaviour
    {
        public Action<Collider2D> OnBallBounceOff;
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer(Utilities.BallLayer))
            {
                OnBallBounceOff?.Invoke(collision);
            }
        }

        private void OnDestroy()
        {
            OnBallBounceOff = null;
        }
    }
}
