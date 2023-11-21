using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class WeaponBase : MonoBehaviour
{

    [Header("Weapon Base Stats")]
    [SerializeField] protected float timeBetweenAttacks, chargeUpTime;
    [SerializeField, Range(0,1)] protected float mineChargePercent;
    [SerializeField] private bool isFullyAuto;
    private Coroutine _currentFireTimer;
    private bool _isOnCooldown;
    private WaitForSeconds _coolDownWait;
    private WaitUntil _coolDownEnforce;
    private float _currentChargeTime;
    public GameObject shootAudio;
    public Transform audioPos;
    public float audioDuration;
    public WaitForSeconds audioCoolDownWFS;
    public GameObject projectile, muzzleFlash;
    public int ammoCapacity, remainingAmmo, reserveAmmo, burstFired, burstSize;
    [SerializeField] private TextMeshProUGUI ammoTracker;
    [SerializeField] public EFireMode fireMode;

    public enum EFireMode
    {
        Single,
        Burst,
        Automatic
    }

    private void Start()
    {
        _coolDownWait = new WaitForSeconds(timeBetweenAttacks);
        _coolDownEnforce = new WaitUntil(() => !_isOnCooldown);
        audioCoolDownWFS = new WaitForSeconds(audioDuration);
        remainingAmmo = ammoCapacity;
        burstFired = 0;
    }

    public void StartShooting()
    {
        //Debug.Log("InitiatingTimer");
        _currentFireTimer = StartCoroutine(ReFireTimer());
    }

    public void StopShooting()
    {
        StopCoroutine(_currentFireTimer);
        float percent = _currentChargeTime / chargeUpTime;
        if(percent != 0)
        {
            TryAttack(percent);
        }
    }

    protected abstract void Attack(float percent);

    private IEnumerator CoolDownTimer()
    {
        _isOnCooldown = true;
        yield return _coolDownWait;
        _isOnCooldown = false;
    }

    private IEnumerator ReFireTimer()
    {
        yield return _coolDownEnforce;
        while(_currentChargeTime < chargeUpTime)
        {
            _currentChargeTime += Time.deltaTime;
            yield return null;
        }
        //Debug.Log("TryAttack Called");
        TryAttack(1);
        yield return null;
    }

    private void TryAttack(float percent)
    {
        _currentChargeTime = 0;
        if(!CanAttack(percent)) return;
        //Debug.Log("Attacking");
        if(remainingAmmo > 0)
        {
            Attack(percent);
            remainingAmmo -= 1;
            ammoTracker.text = ("Ammo: " + remainingAmmo.ToString() + "/" + reserveAmmo.ToString());
            StartCoroutine(CoolDownTimer());
            if(fireMode == EFireMode.Automatic && percent >= 1)
            {
                _currentFireTimer = StartCoroutine(ReFireTimer());
            }
        }
    }

    protected virtual bool CanAttack(float percent)
    {
        return !_isOnCooldown && percent >= mineChargePercent;
    }
}
