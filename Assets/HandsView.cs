using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsView : MonoBehaviour
{
    private IAimComponent _aimComponent;
    private CharacterInventory _playerInventory;

    public void Init(CharacterInventory inventory, IAimComponent aimComponent)
    {
        _playerInventory = inventory;
        _aimComponent = aimComponent;
        Orient();
    }

    private void Orient()
    {

        IDirectedTool equipedItem = _playerInventory.EquipedWeapon;

        if (equipedItem == null)
        {
            equipedItem = _playerInventory.EquipedTool;

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
}
