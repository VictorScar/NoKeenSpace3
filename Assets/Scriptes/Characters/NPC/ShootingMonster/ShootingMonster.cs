using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMonster : NPC_Character, ICanShoot
{
    [SerializeField] protected float _shootDistance = 10f;

    private IAimComponent _aimingComponent;
    private QuadWeapon _weaponSource;

    public IAimComponent AimingComponent => _aimingComponent;

    public override void Init()
    {
        base.Init();
        _aimingComponent = GetComponent<IAimComponent>();

        _inventory.Init(this);

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
        return true;
    }

    //public void UseEquipedTool()
    //{
    //    if (AimingComponent == null)
    //    {
    //        return;
    //    }

    //    var equipedWeapon = _inventory.EquipedWeapon;

    //    if (equipedWeapon == null)
    //    {
    //        return;
    //    }

    //    equipedWeapon.Fire();
    //}
}
