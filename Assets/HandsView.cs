using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class HandsView : MonoBehaviour
{
    [SerializeField] RotationConstraint _rotateConstraint;

    private IAimComponent _aimComponent;
    //private CharacterInventory _playerInventory;
    private Character _pawn;

    public void Init(Character pawn, IAimComponent aimComponent)
    {
        _pawn = pawn;
        _aimComponent = aimComponent;
        Orient();
       // _pawn.onDied += DisableConstraint;
    }

    private void Orient()
    {

        IDirectedTool equipedItem = _pawn.Inventory.EquipedWeapon;

        if (equipedItem == null)
        {
            equipedItem = _pawn.Inventory.EquipedTool;

            if (equipedItem == null)
            {
                return;
            }
        }

        var aimDistance = equipedItem.ShootingDistance;
        var aimPoint = _aimComponent.AimPoint + _aimComponent.AimDirection * aimDistance;

        var aimDirection = (aimPoint - transform.position).normalized;

        transform.forward = aimDirection;
    }

    //private void DisableConstraint()
    //{
    //    _rotateConstraint.enabled = false;
    //}

    //private void OnDestroy()
    //{
    //    //_pawn.onDied -= DisableConstraint;
    //}
}
