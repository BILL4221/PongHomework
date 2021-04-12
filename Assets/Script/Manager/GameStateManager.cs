using Pong.Entry;
using Pong.GameState;
using Pong.Logic;
using Pong.UI;
using Pong.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pong.Util;

namespace Pong.Manager
{
    [Serializable]
    public struct GameConfig
    {
        public Transform LeftPlayerStartSpot;
        public Transform RightPlayerStartSpot;
        public float PaddleSpeed;
        public float BallSpeed;
        public float BuffSpeed;
        public int ScoreMatchPoint;
        public Vector3 SpawnBallStartPosition;
        public float minSpawnBuffXPos;
        public float maxSpawnBuffXPos;
        public float minSpawnBuffYPos;
        public float maxSpawnBuffYPos;
    }
    public class GameStateManager : MonoBehaviour
    {
        private State currentState;

        public GameConfig Config;

        public Boundary boardPrefab;

        public Ball ballPrefab;

        public Paddle paddlePrefab;

        public Buff[] buffsPrefab;

        private Paddle playerPaddle;

        private Paddle opponentPaddle;

        public UIManager uiManager;

        private int leftPlayerScore;

        private int rightPlayerScore;        

        public Boundary Boundary { get; private set; }

        private List<GameObject> entryList;

        private void Awake()
        {
            ChangeState(new StartState(this));
            entryList = new List<GameObject>();
            uiManager.ToggleArrowButton.onClick.AddListener(() => { ToggleInputStyle(InputStyle.Arrow); });
            uiManager.ToggleWASDButton.onClick.AddListener(() => { ToggleInputStyle(InputStyle.WASD); });
            uiManager.ToggleMouseButton.onClick.AddListener(() => { ToggleInputStyle(InputStyle.Mouse); });
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
            Boundary = Instantiate(boardPrefab, Vector3.zero, Quaternion.identity);           
            playerPaddle = AddPaddle(Config.LeftPlayerStartSpot.position);
            var playerController = SetupPlayerController();
            playerPaddle.SetController(playerController);
            opponentPaddle = AddPaddle(Config.RightPlayerStartSpot.position);
            var opponentController = new AIController(this, opponentPaddle);
            opponentPaddle.SetController(opponentController);
            uiManager.ShowInputButton(true);
        }

        public void ClearBoard()
        {
            Destroy(Boundary.gameObject);
            Boundary = null;
            Destroy(playerPaddle.gameObject);
            playerPaddle = null;
            Destroy(opponentPaddle.gameObject);
            opponentPaddle = null;
            uiManager.ShowInputButton(false);
        }
        public Ball AddBall(Vector3 pos)
        {
            var ball = Instantiate(ballPrefab, pos, Quaternion.identity);
            ball.SetSpeed(Config.BallSpeed);
            entryList.Add(ball.gameObject);
            return ball;
        }

        public Buff AddBuff(Vector3 pos)
        {
            int randIndex = UnityEngine.Random.Range(0, buffsPrefab.Length);
            var buff = Instantiate(buffsPrefab[randIndex], pos, Quaternion.identity);
            buff.SetManager(this);
            entryList.Add(buff.gameObject);
            return buff;
        }

        public Paddle AddPaddle(Vector3 pos)
        {
            var paddle = Instantiate(paddlePrefab, pos, Quaternion.identity);
            paddle.SetPaddleSpeed(Config.PaddleSpeed);
            return paddle;
        }

        public void ResetScore()
        {
            leftPlayerScore = 0;
            uiManager.SetLeftPlayerScore(leftPlayerScore);
            rightPlayerScore = 0;
            uiManager.SetRightPlayerScore(rightPlayerScore);
        }

        private void AddLeftPlayerScore(int score)
        {
            leftPlayerScore += score;
            uiManager.SetLeftPlayerScore(leftPlayerScore);
        }

        private void AddRightPlayerScore(int score)
        {
            rightPlayerScore += score;
            uiManager.SetRightPlayerScore(rightPlayerScore);
        }

        private void BallOutofScene(Collider2D collider)
        {
            Boundary.OnBallBounceOff -= BallOutofScene;
            int winnerScore;

            if (collider.transform.position.x < 0)
            {
                AddRightPlayerScore(1);
                winnerScore = rightPlayerScore;
            }
            else
            {
                AddLeftPlayerScore(1);
                winnerScore = leftPlayerScore;
            }

            if (winnerScore >= Config.ScoreMatchPoint)
            {
                ChangeState(new EndMatchState(this));
            }
            else
            {
                ChangeState(new EndRoundState(this));
            }
        }

        public void DestroyEntry(GameObject entry)
        {
            if (entry != null)
            {
                entryList.Remove(entry);
                Destroy(entry.gameObject);
            }
        }

        public void ClearAllEntry()
        {
            if (entryList.Count == 0)
            {
                return;
            }

            for(int i=0; i< entryList.Count; i++)
            {
                Destroy(entryList[i]);
            }
            entryList.Clear();
        }

        public void ResetPaddle()
        {
            playerPaddle.transform.position = Config.LeftPlayerStartSpot.position;
            opponentPaddle.transform.position = Config.RightPlayerStartSpot.position;
        }

        private PlayerController SetupPlayerController()
        {
            var controller = new PlayerController(this);
            controller.RegisterKeyInput(InputStyle.Arrow, KeyCode.UpArrow, KeyCode.DownArrow);
            controller.RegisterKeyInput(InputStyle.WASD, KeyCode.W, KeyCode.S);
            controller.RegisterMouseInput(InputStyle.Mouse, Utilities.MouseYAxis);
            return controller;
        }

        private void ToggleInputStyle(InputStyle style)
        {
            var controller = (PlayerController)playerPaddle.GetController();
            var enable = controller.GetEnableInputStyle(style);
            controller.EnableInputStyle(style, !enable);
        }

        public void SetupBoundary()
        {
            Boundary.OnBallBounceOff += BallOutofScene;
        }

        public List<Ball> GetBallList()
        {
            List<Ball> listBall = new List<Ball>();
            foreach (var entry in entryList)
            {
                var ball = entry.GetComponent<Ball>();
                if (ball != null)
                {
                    listBall.Add(ball);
                }
            }
            return listBall;
        }
    }
}
