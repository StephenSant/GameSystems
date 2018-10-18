using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public int damage;
    public float delay;
    public float speed;
    public Rigidbody rigid;

    private void Start()
    {
        Direction();
    }
    public virtual void Direction()
    {
        rigid.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
}
