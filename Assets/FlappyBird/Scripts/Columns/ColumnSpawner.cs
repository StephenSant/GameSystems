using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FlappyBird
{
    public class ColumnSpawner : MonoBehaviour
    {
        public GameObject prefab;
        public int maxPoolSize = 5;
        public float spawnRate = 3;
        public float minY = -1;
        public float maxY = 3.5f;
        public Vector3 standbyPos = new Vector3(-15,-25);
        public float startX = 10;

        private Transform[] columns;
        private int currentColumn = 0;
        private float spawnTimer = 0;

        // Use this for initialization
        void Start()
        {
            SpawnColumns();
        }

        // Update is called once per frame
        void Update()
        {
            spawnTimer += Time.deltaTime;
            if (!GameManager.Instance.isGameOver && spawnTimer >= spawnRate)
            {
                spawnTimer = 0;
                RepositionColumn();
            }
        }

        void SpawnColumns()
        {
            columns = new Transform[maxPoolSize];
            for (int i = 0; i < columns.Length; i++)
            {
                GameObject clone = Instantiate(prefab, transform);
                Transform column = clone.transform;
                column.position = standbyPos;
                columns[i] = column;
            }
        }
        void RepositionColumn()
        {
            float randomY = Random.Range(minY, maxY);
            Transform column = columns[currentColumn];
            column.position = new Vector3(startX, randomY);
            currentColumn++;
            if (currentColumn >= maxPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}