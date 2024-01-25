using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _muzzle;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _rateOfTime = 0.5f;
    [SerializeField] private float _shootingDistance = 20f;

    private float _lastShootTime = 0f;

    private IShooter _shooter;

    public bool IsActive { get; private set; } = true;
    public float ShootingDistance { get => _shootingDistance; }

    public void Init(IShooter shooter)
    {
        _shooter = shooter;
        IsActive = true;
    }

    public void Fire()
    {
        if (_shooter == null || !IsActive)
        {
            return;
        }

        var remainingTime = Time.time - _lastShootTime;

        if (remainingTime < _rateOfTime)
        {
            return;
        }

        var targetPoint = _shooter.AimingComponent.ThrowBeam(_shootingDistance);

        var shoorDirection = (targetPoint - _muzzle.position).normalized;
        Shoot(shoorDirection);
        _lastShootTime = Time.time;
    }

    private void Shoot(Vector3 shoorDirection)
    {
        var bulletDirection = Quaternion.Euler(shoorDirection);
        var bulletInstance = Instantiate(_bulletPrefab, _muzzle.position, Quaternion.identity);
        bulletInstance.transform.forward = shoorDirection;
    }

    private void OnEnable()
    {
        IsActive = true;
    }

    private void OnDisable()
    {
        IsActive = false;
    }

}
