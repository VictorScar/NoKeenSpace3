using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : WeaponView
{
    [SerializeField] protected float _damage;
    public override void Fire()
    {
        if (_shooter == null)
        {
            return;
        }

        var remainingTime = Time.time - _lastShootTime;

        if (remainingTime < _rateOfTime)
        {
            return;
        }

        var impactObject = _shooter.AimingComponent.ThrowBeam(_shootingDistance, out var targetPoint) as GameObject;
        var attackedCharacter = impactObject.GetComponent<Character>();

        if (attackedCharacter == null)
        {
            attackedCharacter = impactObject.GetComponentInParent<Character>();
        }

        if (attackedCharacter != null)
        {
            attackedCharacter.GetDamage(_damage, _owner);
            //_lastShootTime = Time.time;
        }

        _lastShootTime = Time.time;
    }

    protected override void Shoot(Vector3 shoorDirection)
    {

    }
}
