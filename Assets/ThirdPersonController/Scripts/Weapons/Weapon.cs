using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ThirdPersonController { 
public abstract class Weapon : MonoBehaviour
{
    public int damage;
    public int ammo;
    public float accuracy;
    public float range;
    public float rateOfFire;
    public GameObject projectile;
    public Transform firepoint;

    protected int currentAmmo;

    public abstract void Attack();

    public void Reload()
    {
        currentAmmo = ammo;
    }
}
}