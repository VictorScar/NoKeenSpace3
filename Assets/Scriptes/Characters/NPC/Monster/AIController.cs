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
            var equipedItem = _pawn.Inventory.EquipedWeapon;

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
            if (_pawn.Target == null)
            {
                _pawn.FindTarget();
            }
            else if(_pawn.Target.IsAlive)
            {
                var distanceToTarget = Vector3.Distance(_pawn.Target.transform.position, _pawn.transform.position);

                

                if (distanceToTarget > requiredDistance)
                {
                    _pawn.GoToTarget();
                }
                else
                {
                    _pawn.StopMove();

                    if (_meleeFighter != null)
                    {
                        _meleeFighter.Attacking();
                    }
                    else if (_shooter != null)
                    {
                        var targetPosition = _pawn.Target.transform.position;
                        var dir = targetPosition = (_pawn.transform .position).normalized;
                        var angle = Vector3.Angle(dir, _pawn.transform.forward);
                        var rotateDir = new Vector2(0, angle);
                        _pawn.Rotate(rotateDir);
                        _shooter.Shoot();
                    }
                }
               
            }
            yield return null;
        }
    }

    //private IEnumerator SearchingPlayer()
    //{
    //    if (_pawn == null)
    //    {
    //        yield break;
    //    }

    //    while (_pawn.Target == null)
    //    {
    //        yield return new WaitForSeconds(0.5f);
    //        _pawn.FindTarget();
    //    }

    //    StartCoroutine(ChaesingTarget());

    //}

    //private IEnumerator ChaesingTarget()
    //{
    //    var distanceToTarget = Vector3.Distance(_pawn.Target.transform.position, _pawn.transform.position);
    //    var requiredDistance = 0f;

    //    if(_meleeFighter != null) 
    //    {
    //        requiredDistance = _meleeFighter.MeleeAttackDistance;
    //    }



    //    while (_pawn.Target != null && distanceToTarget > requiredDistance)
    //    {
    //        _pawn.GoToTarget();
    //        yield return null;
    //    }
    //}

    public override void SetPawn(Character pawn)
    {
        _pawn = pawn as NPC_Character;
    }
}
