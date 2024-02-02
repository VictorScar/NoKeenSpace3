using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Mover : CharacterMover
{
    [SerializeField] protected float _rotateSpeed = 2f;
    [SerializeField] protected float _minRequiredAngle = 0.2f;
    [SerializeField] protected NavMeshAgent _agent;
    protected NPC_Character _npcPawn;

    public override void Init(Character pawn)
    {
        base.Init(pawn);
        _npcPawn = _pawn as NPC_Character;

    }

    public override void Jump()
    {
        throw new System.NotImplementedException();
    }


    public void MoveTo(Vector3 targetPos, float moveSpeed)
    {
        _agent.speed = moveSpeed;
        _agent.SetDestination(targetPos);
        IsMoving = true;
    }

    public override void StopMoving()
    {
        _agent.speed = 0f;
       IsMoving = false;
    }

    public bool TurnTo(Vector3 dirTo)
    {

        var angle = Vector3.SignedAngle(transform.forward, dirTo, transform.up);


        var deltRotation = _rotateSpeed * Time.deltaTime;

        if (Mathf.Abs(angle) > _minRequiredAngle)
        {
            transform.rotation *= Quaternion.Euler(0, angle * _rotateSpeed * Time.deltaTime, 0);
            return false;
        }
        else
        {
            return true;
        }
    }
}
