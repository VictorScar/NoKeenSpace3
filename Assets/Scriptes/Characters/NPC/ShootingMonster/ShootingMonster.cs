using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMonster : NPC_Character, ICanShoot
{
    [SerializeField] protected float _shootDistance = 10f;
    [SerializeField] protected MonstrHandsView _handsView;
    [SerializeField] private WeaponView[] _naturalWeapons; 

    private IAimComponent _aimingComponent;
    //private WeaponView _weaponSource;

    public IAimComponent AimingComponent => _aimingComponent;

    public WeaponView EquipedWeapon => _handsView.WeaponView;

    public Character Character => this;

    public override void Init()
    {
        base.Init();
        _aimingComponent = GetComponent<IAimComponent>();

        _inventory?.Init(this);
        _animController?.Init(this);
        _handsView.Init(this, _naturalWeapons);

    }

    public bool Shoot()
    {
        if (AimingComponent == null)
        {
            return false;
        }

        //var equipedWeapon = _handView.EquipedWeapon;

        if (EquipedWeapon == null)
        {
            return false;
        }

        EquipedWeapon.Fire();
        OnAttacking();
        return true;
    }
}
