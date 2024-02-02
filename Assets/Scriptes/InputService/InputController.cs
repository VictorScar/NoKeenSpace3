using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : CommandController
{
    [SerializeField] private InputService _inputService;

    private ICanShoot _shooter;
    private ICanUseTools _toolsUser;
    private IPlayerControlable _controlable;

    private Character _pawn;

    private bool _canUseTool = false;
    private bool _canShoot = false;

    public override void SetPawn(Character pawn)
    {
        _pawn = pawn;
        _shooter = _pawn.GetComponent<ICanShoot>();
        _toolsUser = _pawn.GetComponent<ICanUseTools>();
        _controlable = _pawn.GetComponent<IPlayerControlable>();

        _canUseTool = _toolsUser != null;
        _canShoot = _shooter != null;
    }

    private void MoveCommands()
    {
        if (_controlable != null)
        {
            var moveDir = _inputService.OnMoveInput();
            _controlable.Move(moveDir);
        }
    }

    private void RotateCommands()
    {
        if (_controlable != null)
        {
            var inputRotation = _inputService.OnMouseMotion();
            _controlable.Rotate(inputRotation);
        }
    }

    private void JumpCommand()
    {
        if (_controlable != null)
        {
            var isJumpInput = _inputService.OnJumpInput();

            if (isJumpInput)
            {
                _controlable.Jump();
            }
        }
    }

    private void ProcessUseCommands()
    {
        if (_canShoot)
        {
            if(_shooter.EquipedWeapon != null)
            {
                _shooter.Shoot();
                return;
            }
        }
        if (_canUseTool)
        {
            if (_toolsUser.EquipedTool != null)
            {
                _toolsUser.UseEquipedTool();
            }
        }

    }
       

    private void UseActionCommand()
    {
        var isUseCommand = _inputService.OnUseInput();

        if (isUseCommand)
        {
            ProcessUseCommands();
        }
    }
      

    private void ProcessSprintCommand()
    {
        _pawn.IsSprinting = _inputService.OnSprintInput();

    }

    private void Update()
    {
        if (_pawn == null || !_pawn.IsAlive)
        {
            return;
        }

        ProcessSprintCommand();
        RotateCommands();
        MoveCommands();
        JumpCommand();
        UseActionCommand();
    }

}
