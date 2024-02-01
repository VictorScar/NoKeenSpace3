using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMonster : NPC_Character, ICanShoot
{
    [SerializeField] protected float _shootDistance = 10f;

    [SerializeField] protected MonsterAnimationController _animController;

    private IAimComponent _aimingComponent;
    private QuadWeapon _weaponSource;

    public IAimComponent AimingComponent => _aimingComponent;

    public Weapon EquipedWeapon => _weaponSource;

    public override void Init()
    {
        base.Init();
        _aimingComponent = GetComponent<IAimComponent>();

        _inventory?.Init(this);
        _animController?.Init(this);

    }

    public bool Shoot()
    {
        if (AimingComponent == null)
        {
            return false;
        }

        var equipedWeapon = _inventory.EquipedWeapon;

        if (equipedWeapon == null)
        {
            return false;
        }

        equipedWeapon.Fire();
        OnAttacking();
        return true;
    }
}
