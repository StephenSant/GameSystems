using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public int pellets;

    public override void Attack()
    {
        //Store  forward direction of player
        Vector3 direction = transform.forward;
        //Calculate speaad by using range
        Vector3 spead = Vector3.zero;
        //Offset on local y
        spead += transform.up * Random.Range(-accuracy, accuracy);
        //Offset on local x
        spead += transform.right * Random.Range(-accuracy, accuracy);

        GameObject clone = Instantiate(projectile, firepoint.position,firepoint.rotation);
        Bullet newBullet = clone.GetComponent<Bullet>();
        newBullet.Fire(direction + spead);
    }
}
