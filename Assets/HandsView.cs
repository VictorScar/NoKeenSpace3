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
        var equipedTool = _playerInventory.EquipedWeapon;

        if (equipedTool == null)
        {
            return;
        }

        var aimDistance = equipedTool.ShootingDistance;
        var aimPoint = _aimComponent.AimPoint + _aimComponent.AimDirection * aimDistance;

        var aimDirection = (aimPoint - transform.position).normalized;

        transform.forward = aimDirection;
    }
}
