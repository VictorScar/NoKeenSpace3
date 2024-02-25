using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerHandsView : HandsView
{
    [SerializeField] RotationConstraint _rotateConstraint;

    //private IAimComponent _aimComponent;
   // private CharacterInventory _inventory;

    //public override void Init(ICanAiming aimAgent)
    //{
    //    base.Init(aimAgent);

    //    //_inventory = _owner.Inventory as CharacterInventory;

    //    //_inventory.onNewItemEqiuped += ShowEquipedTool;
    //}

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


}
