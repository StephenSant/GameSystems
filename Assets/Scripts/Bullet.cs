using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 5;
    public float speed = 5f;
    public Rigidbody rigid;
    public float delay = 10;

    private void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Method for 'Firing' the bulle
    public void Fire(Vector3 direction)
    {
        rigid.AddForce(direction * speed, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
