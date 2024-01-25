using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : CommandController
{
    [SerializeField] private InputService _inputService;

    private Player _pawn;

    public override void SetPawn(Character pawn)
    {
        _pawn = pawn as Player;
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
            _pawn.UseEquipedTool();
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
