using UnityEngine;
using UnityEngine.EventSystems;

namespace Core
{
    public class TouchDetector : MonoBehaviour
    {
        private void Start()
        {
            GameController.Instance.GameStartEvent += OnGameStart;
            GameController.Instance.GameState.ValueChanged += OnGameLose;
            gameObject.SetActive(false);

        }
        public void OnClick()
        {
            GameController.Instance.OnGravityClick();
            
        }

        private void OnGameStart()
        {
            gameObject.SetActive(true);
        }

        private void OnGameLose()
        {
            if (GameController.Instance.GameState.Value == GameStateEnum.Lose)
                gameObject.SetActive(false);

        }

        private void OnDestroy()
        {
            GameController.Instance.GameStartEvent -= OnGameStart;
            GameController.Instance.GameState.ValueChanged -= OnGameLose;

        }

    }
}