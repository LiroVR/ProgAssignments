using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileObject : MonoBehaviour
{
    private float curSpeed;
    private float curDamage;
    private Vector3 curDirection;
    private Rigidbody owner;
    public float lifetime = 0;
    public float baseSpeed, contactDamage;

    public void Initialize(float chargePercent, Rigidbody owner)
    {
        this.owner = owner;
        curDirection = transform.right;
        curSpeed = baseSpeed * chargePercent;
        curDamage = contactDamage * chargePercent;
        GetComponent<Rigidbody>().AddForce(transform.forward*curSpeed, ForceMode.Impulse);
    }
}
