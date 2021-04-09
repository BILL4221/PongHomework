using Pong.Entry;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pong.GameState
{
    public class GameStateManager : MonoBehaviour
    {
        private State currentState;

        public Text StartText;

        public GameObject boardPrefab;

        public Ball ballPrefab;

        public Paddle paddlePrefab;


        private Paddle playerPaddle;

        private Paddle opponentPaddle;

        private GameObject board;


        private void Awake()
        {
            ChangeState(new StartState(this));
        }

        public void ChangeState(State newState)
        {
            if (newState == null)
            {
                return;
            }
            currentState?.Exit();
            currentState = newState;
            newState.Start();
        }

        private void Update()
        {
            currentState.Update();
        }

        public void SetupBoard()
        {
            AddBall(Vector3.zero);
            board = Instantiate(boardPrefab, Vector3.zero, Quaternion.identity);
            playerPaddle = Instantiate(paddlePrefab, new Vector3(-12.2f, 0, 0), Quaternion.identity);
            playerPaddle.SetController(new PlayerController());
            opponentPaddle = Instantiate(paddlePrefab, new Vector3(12.2f, 0, 0), Quaternion.identity);
        }

        public Ball AddBall(Vector3 pos)
        {
            var ball = Instantiate(ballPrefab, pos, Quaternion.identity);
            return ball;
        }
    }
}
