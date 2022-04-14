using Static.Constants;
using System;
using System.Collections;
using UI.Lose;
using Unils;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Constants _constants;
        [SerializeField] private LosePanel _losePanel;
        [SerializeField] private int _gameSpeed;

        public static GameController Instance = null;

        public ReactiveProperty<int> CurrentPoints = new ReactiveProperty<int>();
        public ReactiveProperty<GameStateEnum> GameState = new ReactiveProperty<GameStateEnum>();


        public delegate void UnityAction();
        public event UnityAction? GameStartEvent;
        public event UnityAction? InGameClickEvent;

        private void OnEnable()
        {
            Instance = this;
        }


        public int GameSpeed => _gameSpeed;

        public void StartGame()
        {
            if (!PlayerPrefs.HasKey(_constants.GetConstant(ConstantsKeysEnum.HighScore)))
            {
                PlayerPrefs.SetInt(_constants.GetConstant(ConstantsKeysEnum.HighScore), 0);
                PlayerPrefs.Save();
            }

            GameState.Value = GameStateEnum.Play;
            _losePanel.Hide();
            _losePanel.gameObject.SetActive(false);

            GameStartEvent.Invoke();
            StartCoroutine(PointsAdd());
        }

        public void LoseGame()
        {
            StopCoroutine(PointsAdd());
            if (PlayerPrefs.GetInt(_constants.GetConstant(ConstantsKeysEnum.HighScore)) < CurrentPoints.Value)
            {
                PlayerPrefs.SetInt(_constants.GetConstant(ConstantsKeysEnum.HighScore), CurrentPoints.Value);
                PlayerPrefs.Save();
            }

            GameState.Value = GameStateEnum.Lose;
            CurrentPoints.Value = 0;
            _losePanel.gameObject.SetActive(true);
            _losePanel.Show(PlayerPrefs.GetInt(_constants.GetConstant(ConstantsKeysEnum.HighScore)));
        }

        private IEnumerator PointsAdd()
        {
            yield return new WaitForEndOfFrame();

            while (true)
            {
                if (GameState.Value == GameStateEnum.Play)
                {
                    CurrentPoints.Value += GameSpeed * 10;
                    yield return new WaitForSeconds(1f);
                }
                else
                    yield return null;
            }
        }

        public void SwitchPauseMode()
        {
            if (GameState.Value == GameStateEnum.Play)
                GameState.Value = GameStateEnum.Pause;
            else if (GameState.Value == GameStateEnum.Pause)
                GameState.Value = GameStateEnum.Play;
        }

        public void OnGravityClick()
        {
            InGameClickEvent?.Invoke();
        }

    }

}
