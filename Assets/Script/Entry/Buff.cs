using Pong.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Entry
{
    public abstract class Buff : MonoBehaviour
    {
        protected GameStateManager manager;
        protected abstract void OnTriggerEnter2D(Collider2D collision);

        public void SetManager(GameStateManager manager)
        {
            this.manager = manager;
        }
    }
}
