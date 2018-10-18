using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class Repeat : MonoBehaviour
    {
        public float moveSpeed;
        public bool isRepeating = true;
        public SpriteRenderer rend;
        private float width;

        // Use this for initialization
        void Start()
        {
            if (rend)
            {
                rend = GetComponent<SpriteRenderer>();
                width = rend.bounds.size.x;
            }
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 pos = transform.position;
            pos += Vector3.left * moveSpeed * Time.deltaTime;
            if (pos.x < -width && isRepeating)
            {
                float offset = width * 2;
                Vector3 newPosition = new Vector3(offset, 0, 0);
                pos += newPosition;
            }
            transform.position = pos;
        }
    }
}