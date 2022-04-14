using Core;
using Static.Constants;
using TMPro;
using UnityEngine;

namespace UI.Score
{
    public class ScorePanel : MonoBehaviour
    {
        [SerializeField] private Constants _constants;
        [SerializeField] private TMP_Text _highScore;
        [SerializeField] private TMP_Text _currentScore;

        private void OnEnable()
        {
            GameController.Instance.CurrentPoints.ValueChanged += UpdateCurrentScore;
            GameController.Instance.GameStartEvent += StartNewGame;
        }

        private void OnDisable()
        {
            GameController.Instance.CurrentPoints.ValueChanged -= UpdateCurrentScore;
            GameController.Instance.GameStartEvent -= StartNewGame;
        }

        public void StartNewGame()
        {
            UpdateHighScore();
        }

        private void UpdateHighScore()
        {
            _highScore.text = "High Score: " + PlayerPrefs.GetInt(_constants.GetConstant(ConstantsKeysEnum.HighScore)).ToString();
        }

        private void UpdateCurrentScore()
        {
            _currentScore.text = $"Current Score: {GameController.Instance.CurrentPoints.Value}";
        }
    }
}