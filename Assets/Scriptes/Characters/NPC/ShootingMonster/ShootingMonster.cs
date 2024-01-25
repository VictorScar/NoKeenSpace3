using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMonster : NPC_Character, IShooter
{
    [SerializeField] protected float _shootDistance = 10f;

    private IAimComponent _aimingComponent;
    private Weapon _weaponSource;

    public IAimComponent AimingComponent => _aimingComponent;

    public override void Init()
    {
        base.Init();
        _aimingComponent = GetComponent<IAimComponent>();

    }

    public void Shoot()
    {
        if (AimingComponent == null)
        {
            return;
        }

        var equipedWeapon = _inventory.EquipedWeapon;

        if (equipedWeapon == null)
        {
            return;
        }
               
        equipedWeapon.Fire();
    }
}