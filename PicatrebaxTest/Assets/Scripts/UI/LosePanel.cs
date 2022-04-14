using Core;
using TMPro;
using UnityEngine;

namespace UI.Lose
{
    public class LosePanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _highScore;



        public void Show(int highScore)
        {
            gameObject.GetComponent<CanvasGroup>().alpha = 1;
            _highScore.text = $"High score: {highScore}";
        }

        public void Hide()
        {
            gameObject.GetComponent<CanvasGroup>().alpha = 0;
        }

        public void OnRetryClick()
        {
            GameController.Instance.StartGame();
            Hide();
        }

    }
}