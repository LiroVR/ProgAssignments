using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoCrate : MonoBehaviour
{
    [SerializeField] private ProjectileWeapon pWeapon;
    [SerializeField] private int ammoInBox;
    [SerializeField] private TextMeshProUGUI ammoTracker;

    private void OnCollisionEnter(Collision collision) //This will run upon collision
    {
        if (collision.gameObject.tag == "Player")
        {
            pWeapon.reserveAmmo += ammoInBox;
            ammoTracker.text = ("Ammo: " + pWeapon.remainingAmmo.ToString() + "/" + pWeapon.reserveAmmo.ToString());
            Destroy(gameObject);
        }
    }
}
