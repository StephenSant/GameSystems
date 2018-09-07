using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Attack()
    {
        GameObject clone = Instantiate(projectile, firepoint.position, firepoint.rotation);
        Bullet newBullet = clone.GetComponent<Bullet>();
        newBullet.Fire(transform.forward);
    }
}