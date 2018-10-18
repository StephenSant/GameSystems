using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FlappyBird
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        public static GameManager Instance = null;
        private void Awake()
        {
            Instance = this;
        }
        private void OnDestroy()
        {
            Instance = null;
        }
        #endregion
        public int score = 0;
        public bool isGameOver = false;

        public delegate void IntCallback(int number);
        public IntCallback scoreAdded;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void AddScore(int scoreToAdd)
        {
            if (isGameOver)
            {
                return;
            }
            score += scoreToAdd;
            scoreAdded.Invoke(score);
        }
    }
}