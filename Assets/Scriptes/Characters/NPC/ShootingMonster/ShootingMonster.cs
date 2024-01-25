using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMonster : NPC_Character, ICanUseDistanceTools
{
    [SerializeField] protected float _shootDistance = 10f;

    private IAimComponent _aimingComponent;
    private QuadWeapon _weaponSource;

    public IAimComponent AimingComponent => _aimingComponent;

    public override void Init()
    {
        base.Init();
        _aimingComponent = GetComponent<IAimComponent>();

    }

    public void UseEquipedTool()
    {
        if (AimingComponent == null)
        {
            return;
        }

        var equipedWeapon = _inventory.EquipedItem;

        if (equipedWeapon == null)
        {
            return;
        }

        equipedWeapon.Use();
    }
}
