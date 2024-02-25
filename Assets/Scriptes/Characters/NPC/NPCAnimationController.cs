using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimationController : AnimationController
{
    private NPC_Character _npcPawn;

    private bool _isMoving = false;

    private Coroutine _coroutine;

    //private int idleState = "Idle".GetHashCode();
    //private int attackState = "Attack".GetHashCode();
    //private int moveState = "Move".GetHashCode();

    public override void Init(Character pawn)
    {
        base.Init(pawn);
        _npcPawn = pawn as NPC_Character;

        _npcPawn.onMoving += MoveAnimation;
        _npcPawn.onAttacking += AttackAnimation;

        //Test();
    }

    private void Test()
    {
        _coroutine = StartCoroutine(PlayAnimation("Attack"));

    }

    private void DefaultAnimation()
    {
        if (_npcPawn.IsAlive)
            _animator.CrossFade("Idle", 0.1f);
    }

    private void MoveAnimation(bool isMoving)
    {
        if (isMoving == _isMoving)
        {
            return;
        }

        _isMoving = isMoving;

        if (_isMoving)
        {
            _animator.CrossFade("Move", 0.1f);
        }
        else
        {
            _animator.CrossFade("Idle", 0.1f);
        }


    }

    private void AttackAnimation()
    {
        if (_coroutine != null)
        {
            return;
        }

        _coroutine = StartCoroutine(PlayAnimation("Attack"));
    }

    private void OnDestroy()
    {
        _npcPawn.onMoving -= MoveAnimation;
        _npcPawn.onAttacking -= AttackAnimation;
    }

    IEnumerator PlayAnimation(string animation)
    {
        _animator.CrossFade(animation, 0.1f);
        yield return new WaitForSeconds(1f);
        DefaultAnimation();
        _coroutine = null;
        //while (true)
        //{
        //    yield return new WaitForSeconds(2f);
        //    _animator.CrossFade("Idle", 0.1f);
        //    yield return new WaitForSeconds(2f);
        //    _animator.CrossFade("Move", 0.1f);
        //    yield return new WaitForSeconds(2f);
        //    _animator.CrossFade("Attack", 0.1f);
        //}



    }
}
