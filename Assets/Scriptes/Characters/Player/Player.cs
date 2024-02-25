using System;
using UnityEngine;

public class Player : Character, ICanShoot, ICanUseTools, IPlayerControlable
{
    [SerializeField] private CameraHolder _cameraHolder;
    
    [SerializeField] private PlayerHandsView _hands;
    [SerializeField] protected AnimationController _animController;

    protected CharacterInventory _characterInventory;
    protected PlayerMover _playerMover;
        
    private bool _isSprinting = false;
       

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        //_aimComponent = _scanner.GetComponent<IAimComponent>();
        _aimingComponent.Init();
        _hands.Init(this);
        _inventory.Init(this);
        _animController.Init(this);
        _playerMover = _mover as PlayerMover;

        _characterInventory = _inventory as CharacterInventory;
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

    public WeaponView EquipedWeapon => _hands.WeaponView;

    public ToolView EquipedTool => _hands.ToolView;

    public Character Character => this;

    public void UseEquipedTool()
    {
        if (_characterInventory == null)
        {
            Debug.LogError("Have not CharacterInventory component");
            return;
        }

        var item = _characterInventory.EquipedItem;

        if (item == null)
        {
            return;
        }

        item.Use(this);
    }

    public void Rotate(Vector2 inputDirection)
    {
        if (_playerMover == null)
        {
            return;
        }

        _playerMover.Rotate(inputDirection.x);
        _cameraHolder.Incline(inputDirection.y);
    }

    public override void StopMove()
    {
        throw new NotImplementedException();
    }

    public bool Shoot()
    {
       
        if (EquipedWeapon == null)
        {
            return false;
        }
        else
        {
            EquipedWeapon.Fire();
            return true;
        }
    }

    public void DoAction()
    {
        throw new NotImplementedException();
    }

    public void Move(Vector2 inputDir)
    {
        if (_playerMover == null)
        {
            return;
        }

        _playerMover.Move(inputDir, _moveSpeed);
    }
}
