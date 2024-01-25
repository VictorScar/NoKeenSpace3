using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public abstract class Weapon : Item, IEquipped, IDirectedTool
{
    [SerializeField] protected Transform _muzzle;
    [SerializeField] protected float _rateOfTime = 0.5f;
    [SerializeField] protected float _shootingDistance = 20f;

    protected float _lastShootTime = 0f;

    protected ICanAiming _shooter;
    protected Character _owner;

    public ICanAiming AimingAgent { get => _shooter; set => _shooter = value; }

    public float ShootingDistance => _shootingDistance;

    public bool IsEquiped { get; set; }

    public virtual void Equip(Character owner)
    {
        _owner = owner;
        _shooter = _owner as ICanAiming;
        IsEquiped = true;
    }

    //public virtual void Init(Character owner)
    //{
    //    _shooter = owner as ICanAiming;
    //    IsEquiped = true;
    //}

    public virtual void Fire()
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
