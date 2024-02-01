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

        //var useContext = GetUsingContext();

        //switch (useContext)
        //{
        //    case UseActionsContext.None:
        //        break;
        //    case UseActionsContext.Shooting:
        //        _shooter.Shoot();
        //        break;
        //    case UseActionsContext.UseTools:
        //        _toolsUser.UseEquipedTool();
        //        break;
        //    default:
        //        break;
        //}
    }

    //private UseActionsContext GetUsingContext()
    //{
    //    if (_toolsUser == null)
    //    {
    //        if (_shooter != null)
    //        {
    //            return UseActionsContext.Shooting;
    //        }
    //        return UseActionsContext.None;
    //    }

    //    if (_toolsUser.EquipedWeapon != null)
    //    {
    //        return UseActionsContext.Shooting;
    //    }
    //    else if (_toolsUser.EquipedTool != null)
    //    {
    //        return UseActionsContext.UseTools;
    //    }

    //    return UseActionsContext.None;
    //}

    private void UseActionCommand()
    {
        var isUseCommand = _inputService.OnUseInput();

        if (isUseCommand)
        {
            ProcessUseCommands();
        }
    }

    //private bool ShootCommand()
    //{
    //    if (_shooter != null)
    //    {
    //        return _shooter.Shoot();
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    //private void UseEquipedItemCommand()
    //{
    //    if (_toolsUser != null)
    //    {
    //        _toolsUser.UseEquipedTool();
    //    }
    //}

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
