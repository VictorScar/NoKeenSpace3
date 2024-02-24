using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerHandsView : HandsView
{
    [SerializeField] RotationConstraint _rotateConstraint;

    //private IAimComponent _aimComponent;
    private CharacterInventory _inventory;
    //private Character _owner;

    //private WeaponView _weaponView;
    //private ToolView _toolView;

    //public WeaponView WeaponView { get => _weaponView; }
    //public ToolView ToolView { get => _toolView; }

    public override void Init(ICanAiming aimAgent)
    {
        base.Init(aimAgent);

        _inventory = _owner.Inventory;

        _inventory.onNewItemEqiuped += ShowEquipedTool;
    }

    //private void Orient()
    //{
    //    IDirectedTool equipedItem = _pawn.Inventory.EquipedWeapon;

    //    if (equipedItem == null)
    //    {
    //        equipedItem = _pawn.Inventory.EquipedTool;

    //        if (equipedItem == null)
    //        {
    //            return;
    //        }
    //    }

    //    var aimDistance = equipedItem.ShootingDistance;
    //    var aimPoint = _aimComponent.AimPoint + _aimComponent.AimDirection * aimDistance;

    //    var aimDirection = (aimPoint - transform.position).normalized;

    //    transform.forward = aimDirection;
    //}


    public void ShowEquipedTool()
    {
        var viewPrefab = _inventory.EquipedItem.ItemView;

        if (viewPrefab == _weaponView)
        {
            return;
        }

        Destroy(_weaponView);

        if (viewPrefab == null)
        {
            return;
        }

        var view = Instantiate(viewPrefab, transform);

        if (view is WeaponView weaponView)
        {
            _weaponView = view;
            _weaponView.Init(_aimAgent, this);
        }
    }

    private void OnDestroy()
    {
        if (_inventory != null)
        {
            _inventory.onNewItemEqiuped -= ShowEquipedTool;
        }
    }
}
