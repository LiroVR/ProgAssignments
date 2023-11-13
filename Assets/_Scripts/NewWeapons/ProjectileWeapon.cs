using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : WeaponBase
{

    protected override void Attack(float percent)
    {
        //Debug.Log("I attacked");
        var firedAudio = Instantiate(shootAudio, audioPos);
        var mFlash = Instantiate(muzzleFlash, audioPos);
        var bullet = Instantiate(projectile, audioPos.position, audioPos.rotation);
        Rigidbody instantiatedProjectile = bullet.GetComponent<Rigidbody>();
        instantiatedProjectile.AddForce(transform.TransformDirection(new Vector3(0, 0, 1)) * 50,ForceMode.Impulse);
        StartCoroutine(AudioCooldown(firedAudio, bullet, mFlash));
    }

    private IEnumerator AudioCooldown(GameObject audioSource, GameObject bulletObject, GameObject muzFlash)
    {
        yield return audioCoolDownWFS;
        Destroy(audioSource);
        Destroy(bulletObject);
        Destroy(muzFlash);
    }
}
