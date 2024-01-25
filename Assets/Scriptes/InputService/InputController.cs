using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : CommandController
{
    [SerializeField] private InputService _inputService;

    private ICanShoot _shooter;
    private ICanUseTools _toolsUser;

    private Character _pawn;

    public override void SetPawn(Character pawn)
    {
        _pawn = pawn;
        _shooter = _pawn.GetComponent<ICanShoot>();
        _toolsUser = _pawn.GetComponent<ICanUseTools>();
    }

    private void MoveCommands()
    {
        var moveDir = _inputService.OnMoveInput();
        //Debug.Log(moveDir);
        _pawn.Move(moveDir);
    }

    private void RotateCommands()
    {
        var inputRotation = _inputService.OnMouseMotion();
        _pawn.Rotate(inputRotation);
    }

    private void JumpCommand()
    {
        var isJumpInput = _inputService.OnJumpInput();

        if (isJumpInput)
        {
            _pawn.Jump();
        }

    }

    private void UseIEqiuipedtem()
    {
        var isUseCommand = _inputService.OnUseInput();

        if (isUseCommand)
        {
            if (_shooter!= null)
            {
                if (_shooter.Shoot())
                {
                    if (_toolsUser != null)
                    {
                        _toolsUser.UseEquipedTool();
                    }
                    
                }
            }
            else
            {
                if (_toolsUser != null)
                {
                    _toolsUser.UseEquipedTool();
                }
            }
        }
    }

    private void ProcessSprintCommand()
    {
        _pawn.IsSprinting = _inputService.OnSprintInput();

    }

    private void Update()
    {
        if (_pawn == null)
        {
            return;
        }

        ProcessSprintCommand();
        RotateCommands();
        MoveCommands();
        JumpCommand();
        UseIEqiuipedtem();
    }

}
