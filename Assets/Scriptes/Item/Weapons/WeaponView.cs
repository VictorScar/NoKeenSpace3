using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponView : ItemView
{
    [SerializeField] protected Transform _muzzle;
    [SerializeField] protected float _rateOfTime = 0.5f;
    [SerializeField] protected float _shootingDistance = 20f;

    protected float _lastShootTime = 0f;

    public float ShootingDistance => _shootingDistance;

    public virtual void Fire()
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

        var targetPoint = Vector3.zero;
        var impactObject = _shooter.AimingComponent.ThrowBeam(_shootingDistance, out targetPoint);

        var shoorDirection = (targetPoint - _muzzle.position).normalized;
        Shoot(shoorDirection);
        _lastShootTime = Time.time;
    }

    protected abstract void Shoot(Vector3 shoorDirection);
}
