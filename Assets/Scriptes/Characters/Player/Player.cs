using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character, ICanShoot, ICanUseTools
{
    [SerializeField] private CameraHolder _cameraHolder;
    
    [SerializeField] private HandsView _hands;
    
    private IAimComponent _aimComponent;

    private bool _isSprinting = false;

    public IAimComponent AimingComponent => _aimComponent;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        _aimComponent = _scanner.GetComponent<IAimComponent>();
        _aimComponent.Init();
        _hands.Init(_inventory, _aimComponent);
        _inventory.Init(this);
    }

    public override bool IsSprinting
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

    public void UseEquipedTool()
    {
        var tool = _inventory.EquipedTool;

        if (tool == null)
        {
            return;
        }

        tool.Use();
    }

    public override void Rotate(Vector2 inputDirection)
    {
        _mover.Rotate(inputDirection.x);
        _cameraHolder.Incline(inputDirection.y);
    }

    public override void StopMove()
    {
        throw new NotImplementedException();
    }

    public bool Shoot()
    {
        var weapon = _inventory.EquipedWeapon;

        if (weapon == null)
        {
            return false;
        }
        else
        {
            weapon.Fire();
            return true;
        }
    }
}
