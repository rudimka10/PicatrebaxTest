using Core;
using System.Collections;
using UnityEngine;

namespace Platform
{
    public class PlatformMover : MonoBehaviour
    {

        public void Construct(float posX, float scaleX)
        {
            gameObject.transform.localScale = new Vector3(scaleX, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            gameObject.transform.localPosition = new Vector3(posX, 0, 0);
            GameController.Instance.GameState.ValueChanged += OnLose;
        }

        public void StartMove()
        {
            StartCoroutine(Move());
        }

        private IEnumerator Move()
        {

            while (true)
            {
                if (GameController.Instance.GameState.Value == GameStateEnum.Play)
                {
                    gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x - GameController.Instance.GameSpeed * Time.deltaTime, 0, 0);

                    if (gameObject.transform.localPosition.x <= -0.52)
                    {
                        Destroy(gameObject);
                    }
                    yield return new WaitForSeconds(0.01f);

                }
                else
                    yield return null;
            }
        }

        private void OnLose()
        {
            if (GameController.Instance.GameState.Value == GameStateEnum.Lose)
            Destroy(gameObject);

        }

        private void OnDestroy()
        {
            GameController.Instance.GameState.ValueChanged -= OnLose;

            StopAllCoroutines();
        }

    }
}