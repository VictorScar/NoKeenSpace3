using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Character : Character
{
    [SerializeField] Player _target;

    protected NPC_Scanner _npcScanner;

    public override void Init()
    {
        base.Init();
        _npcScanner = _scanner as NPC_Scanner;
    }

    public Player Target { get => _target; set => _target = value; }
    public override bool IsSprinting { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void FindTarget()
    {
        var player = _npcScanner.FindFlayer();

        if (player != null)
        {
            _target = player;
        }
    }

    public void GoToTarget()
    {
        _mover.MoveTo(_target.transform.position, _moveSpeed);
    }

    public override void StopMove()
    {
        _mover.StopMoving();
    }

    public override void Rotate(Vector2 inputDirection)
    {
        throw new NotImplementedException();
    }
}
