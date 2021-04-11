using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pong.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private Text leftScoreText;

        [SerializeField]
        private Text rightScoreText;

        [SerializeField]
        private Text startText;

        [SerializeField]
        private Text endText;

        public Button ToggleWASDButton;

        public Button ToggleArrowButton;

        public Button ToggleMouseButton;

        public void SetLeftPlayerScore(int score)
        {
            leftScoreText.text = score.ToString();
        }

        public void SetRightPlayerScore(int score)
        {
            rightScoreText.text = score.ToString();
        }

        public void ShowStartText(bool show)
        {
            startText.gameObject.SetActive(show);
        }

        public void ShowScoreText(bool show)
        {
            leftScoreText.gameObject.SetActive(show);
            rightScoreText.gameObject.SetActive(show);
        }

        public void ShowEndText(bool show)
        {
            endText.gameObject.SetActive(show);
        }

        public void ShowInputButton(bool show)
        {
            ToggleMouseButton.gameObject.SetActive(show);
            ToggleWASDButton.gameObject.SetActive(show);
            ToggleArrowButton.gameObject.SetActive(show);
        }
    }
}
