using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character, ICanShoot, ICanUseTools, IPlayerControlable
{
    [SerializeField] private CameraHolder _cameraHolder;
    
    [SerializeField] private HandsView _hands;
    [SerializeField] protected AnimationController _animController;

    protected PlayerMover _playerMover;
    
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
        _hands.Init(this, _aimComponent);
        _inventory.Init(this);
        _animController.Init(this);
        _playerMover = _mover as PlayerMover;
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

    public Weapon EquipedWeapon => Inventory.EquipedWeapon;

    public Tool EquipedTool => Inventory.EquipedTool;

    public void UseEquipedTool()
    {
        var tool = _inventory.EquipedTool;

        if (tool == null)
        {
            return;
        }

        tool.Use();
    }

    public void Rotate(Vector2 inputDirection)
    {
        _playerMover.Rotate(inputDirection.x);
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

    public void DoAction()
    {
        throw new NotImplementedException();
    }

    public void Move(Vector2 inputDir)
    {
        _playerMover.Move(inputDir, _moveSpeed);
    }
}
