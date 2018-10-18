using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ThirdPersonController { 
public class Bullet : Projectile
{
    public Vector3 bulletSize;
    public Vector3 direction;

    private void Start()
    {
        transform.localScale = bulletSize;
    }

    private void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.DealDamage(damage);
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
}