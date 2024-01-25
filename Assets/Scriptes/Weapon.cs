using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IDirectedTool
{
    [SerializeField] protected Transform _muzzle;
    [SerializeField] protected float _rateOfTime = 0.5f;
    [SerializeField] protected float _shootingDistance = 20f;

    protected float _lastShootTime = 0f;

    protected ICanUseDistanceTools _shooter;

    public ICanUseDistanceTools Shooter { get => _shooter; set => _shooter = value; }

    public float ShootingDistance => _shootingDistance;

    public bool IsEquiped { get; set; }

    public virtual void Init(ICanUseDistanceTools shooter)
    {
        _shooter = shooter;
        IsEquiped = true;
    }

    public virtual void Use()
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

    protected abstract void Shoot(Vector3 shoorDirection);

}
