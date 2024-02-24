using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : WeaponView
{    
    [SerializeField] protected Bullet _bulletPrefab;

    protected override void Shoot(Vector3 shoorDirection)
    {
        var bulletDirection = Quaternion.Euler(shoorDirection);
        var bulletInstance = Instantiate(_bulletPrefab, _muzzle.position, Quaternion.identity);
        bulletInstance.transform.forward = shoorDirection;
        bulletInstance.Init(_owner);
    }
    
}
