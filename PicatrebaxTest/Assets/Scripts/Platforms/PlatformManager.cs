using Core;
using System.Collections;
using UnityEngine;

namespace Platform
{
    public class PlatformManager : MonoBehaviour
    {
        [SerializeField] private PlatformMover _platformPrefab;

        private void OnEnable()
        {
            GameController.Instance.GameStartEvent += OnGameStart;
        }

        private void OnDisable()
        {
            GameController.Instance.GameStartEvent -= OnGameStart;

        }


        public void OnGameStart()
        {
            StartGeneration();
        }


        private void StartGeneration()
        {
            var firstPos = Random.Range(-0.33f, -0.2f);
            GenerateWithRandomValues(firstPos);
            var secondPos = Random.Range(0f, 0.2f);
            GenerateWithRandomValues(secondPos);
            StartCoroutine(Generation());
        }

        private IEnumerator Generation()
        {
            while (true)
            {
                if (GameController.Instance.GameState.Value == GameStateEnum.Play)
                {
                    GenerateWithRandomValues();
                    Debug.Log("Generate platform");
                    yield return new WaitForSeconds(GameController.Instance.GameSpeed / Random.Range(1.5f, 1.8f));
                    
                }
                else
                    yield return null;
            }
        }

        private void GenerateWithRandomValues(float posX = 0.5f)
        {
            var scaleX = Random.Range(0.18f, 0.27f);
            var currentPlatform = Instantiate(_platformPrefab, gameObject.transform);
            currentPlatform.Construct(posX, scaleX);
            currentPlatform.StartMove();
        }

    }
}