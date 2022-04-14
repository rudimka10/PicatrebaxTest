using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Vector3 _startPos;

        private void OnEnable()
        {
            GameController.Instance.GameStartEvent += OnGameStart;
            GameController.Instance.InGameClickEvent += ChangeGravity;
        }

        private void OnDisable()
        {
            GameController.Instance.GameStartEvent -= OnGameStart;
            GameController.Instance.InGameClickEvent -= ChangeGravity;

        }

        private void OnGameStart()
        {
            gameObject.transform.position = _startPos;
            gameObject.GetComponent<Rigidbody2D>().simulated = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("словили вниз!");
            GameController.Instance.LoseGame();
            gameObject.GetComponent<Rigidbody2D>().simulated = false;

        }

        private void ChangeGravity()
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale *= -1;

        }

    }
}