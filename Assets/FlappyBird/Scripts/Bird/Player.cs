using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FlappyBird
{
    public class Player : MonoBehaviour
    {
        public float upForce = 5;
        public bool isDead = false;
        public Rigidbody2D rigid;

        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Flap();
            }
        }

        void Flap()
        {
            if (!isDead)
            {
                rigid.velocity = Vector2.zero;
                rigid.AddForce(new Vector2(0, upForce), ForceMode2D.Impulse);
            }
        }
    }
}
