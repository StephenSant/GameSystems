using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace FlappyBird
{
    public class FlappyScore : MonoBehaviour
    {
        public Sprite[] numbers;
        public GameObject scoreTextPrefab;  
        public Vector3 standbyPos = new Vector3(-15, 15); 
        public int maxDigits = 5;           

        private GameObject[] scoreTextPool;
        private int[] digits;

        // Use this for initialization
        void Start()
        {
            SpawnPool();
            GameManager.Instance.scoreAdded += RefreshScore;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void RefreshScore(int score)
        {
            
            int[] digits = GetDigits(score);

            for (int i = 0; i < digits.Length; i++)
            {
                int value = digits[i];
                GameObject textElement = scoreTextPool[i];
                Image img = textElement.GetComponent<Image>();
                img.sprite = numbers[value];
                textElement.SetActive(true);
            }

            for (int i = digits.Length; i < scoreTextPool.Length; i++)
            {
                scoreTextPool[i].SetActive(false);
            }
        }

        void SpawnPool()
        {
            scoreTextPool = new GameObject[maxDigits];

            for (int i = 0; i < maxDigits; i++)
            {
                GameObject clone = Instantiate(scoreTextPrefab, standbyPos, Quaternion.identity);
                Image img = clone.GetComponent<Image>();
                img.sprite = numbers[i];
                clone.transform.SetParent(transform);
                clone.name = i.ToString();
                scoreTextPool[i] = clone;
            }
        }
        int[] GetDigits(int number)
        {
            List<int> digits = new List<int>();
            while (number >= 10)
            {
                digits.Add(number % 10);
                number /= 10;
            }
            digits.Add(number);
            digits.Reverse();
            return digits.ToArray();
        }
    }
}