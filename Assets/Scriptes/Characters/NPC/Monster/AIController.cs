using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : CommandController
{
    [SerializeField] protected NPC_Character _pawn;
    private IMeleeFighter _meleeFighter;
    private ICanShoot _shooter;

    private void Start()
    {
        if (_pawn is IMeleeFighter meleeFighter)
        {
            _meleeFighter = meleeFighter;
        }

        if (_pawn is ICanShoot shooter)
        {
            _shooter = shooter;
        }

        if (_pawn is NPC_Character npc_Pawn)
        {
            _pawn = npc_Pawn;
            _pawn.Init();
            StartCoroutine(AILoop());
        }

    }

    private IEnumerator AILoop()
    {
        var requiredDistance = 0f;

        if (_meleeFighter != null)
        {
            requiredDistance = _meleeFighter.MeleeAttackDistance;
        }
        else if (_shooter != null)
        {
            var equipedItem = _shooter.EquipedWeapon;

            if (equipedItem != null)
            {
                requiredDistance = equipedItem.ShootingDistance - 0.5f;
            }


            if (requiredDistance == 0)
            {
                requiredDistance = 9f;
            }
        }

        while (_pawn.IsAlive)
        {
            var target = _pawn.Target;
            if (target == null)
            {
                _pawn.FindTarget();
            }
            else if (target.IsAlive)
            {
                var distanceToTarget = Vector3.Distance(_pawn.Target.transform.position, _pawn.transform.position);

                if (distanceToTarget > requiredDistance)
                {
                    _pawn.GoToTarget();
                }
                else
                {
                    _pawn.StopMove();

                    //if (AimAt(target))
                    //{

                    //}
                    AimAt(target);
                    if (_meleeFighter != null)
                    {
                        _meleeFighter.Attacking();
                    }
                    else if (_shooter != null)
                    {
                        _shooter.Shoot();
                    }



                }

            }
            yield return null;
        }
    }

    public bool AimAt(Character target)
    {
        //var aimPoint = target.transform.position + target.MoveDirection * target.MoveSpeed;
        var aimPoint = target.transform.position;
        return _pawn.LookAt(aimPoint);
    }

 

    public override void SetPawn(Character pawn)
    {
        _pawn = pawn as NPC_Character;
    }
}
