using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Attack()
    {
        GameObject clone = Instantiate(projectile, firepoint.position, firepoint.rotation);
        Projectile newBullet = clone.GetComponent<Bullet>();
        newBullet.Direction();

    }

}