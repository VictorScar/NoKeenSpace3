using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private CameraHolder _cameraHolder;
    [SerializeField] private PlayerInventory _inventory;
    [SerializeField] private HandsView _hands;
    
    private IAimComponent _aimComponent;

    private bool _isSprinting = false;

    public override void Init()
    {
        base.Init();
        _aimComponent = _scanner.GetComponent<IAimComponent>();
        _aimComponent.Init();
        _hands.Init(_inventory, _aimComponent);
    }

    public bool IsSprinting
    {
        get
        {
            return _isSprinting;
        }
        set
        {
            _isSprinting = value;

            if (_isSprinting)
            {
                _moveSpeed = _sprintSpeed;
            }
            else
            {
                _moveSpeed = _baseSpeed;
            }
        }
    }

    public CameraHolder CameraHolder { get => _cameraHolder; }

    public void UseEquipedItem()
    {
        var tool = _inventory.EquipedWeapon;
        var pos = _aimComponent.ThrowBeam(tool.ShootingDistance);
        _inventory.EquipedWeapon.Fire(pos);
    }

    public void Rotate(Vector2 inputDirection)
    {
        _mover.Rotate(inputDirection.x);
        _cameraHolder.Incline(inputDirection.y);
    }

    public override void StopMove()
    {
        throw new NotImplementedException();
    }
}
