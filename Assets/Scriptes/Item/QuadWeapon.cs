using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadWeapon : Weapon
{
    //[SerializeField] protected Transform _muzzle;
    [SerializeField] protected GameObject _bulletPrefab;
   // [SerializeField] protected float _rateOfTime = 0.5f;
    //[SerializeField] protected float _shootingDistance = 20f;

    //protected float _lastShootTime = 0f;

    //protected ICanUseDistanceTools _shooter;

    //public bool IsEquiped { get; set; }
   // public float ShootingDistance { get => _shootingDistance; }
    //public ICanUseDistanceTools Shooter { get => _shooter; set => _shooter = value; }


    //public void Init(ICanUseDistanceTools shooter)
    //{
    //    _shooter = shooter;
    //    IsEquiped = true;
    //}

    public override void Fire()
    {
        if (_shooter == null || !IsEquiped)
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

    protected override void Shoot(Vector3 shoorDirection)
    {
        var bulletDirection = Quaternion.Euler(shoorDirection);
        var bulletInstance = Instantiate(_bulletPrefab, _muzzle.position, Quaternion.identity);
        bulletInstance.transform.forward = shoorDirection;
    }
    
}
