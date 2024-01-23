using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : CommandController
{
    [SerializeField] protected NPC_Character _pawn;
    private IMeleeFighter _meleeFighter;

    private void Start()
    {
        if (_pawn is IMeleeFighter meleeFighter)
        {
            _meleeFighter = meleeFighter;
        }

        if (_pawn is NPC_Character npc_Pawn)
        {
            _pawn = npc_Pawn;
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
