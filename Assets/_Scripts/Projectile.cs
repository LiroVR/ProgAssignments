using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Weapon
{
    [SerializeField] private ProjectileObject projectileFired;
    [SerializeField] private Transform firepoint;

    protected override void Attack(float chargePercent)
    {
        ProjectileObject current = Instantiate(projectileFired, firepoint.position, owner.transform.rotation);
    }
}
