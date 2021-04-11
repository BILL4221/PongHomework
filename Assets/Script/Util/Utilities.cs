using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Util
{
    public static class Utilities
    {
        public static string BallLayer = "Collider";
        public static string MouseYAxis = "Mouse Y";
        public static int RandomSide()
        {           
            return Random.Range(0, 2) * 2 - 1;
        }
    }
}
