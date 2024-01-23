using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Mover : CharacterMover
{
    [SerializeField] protected NavMeshAgent _agent;

    public override void Jump()
    {
        throw new System.NotImplementedException();
    }

    public override void Move(Vector2 dir, float moveSpeed)
    {
        throw new System.NotImplementedException();
    }

    public override void MoveTo(Vector3 targetPos, float moveSpeed)
    {
        _agent.speed = moveSpeed;
        _agent.SetDestination(targetPos);
    }

    public override void StopMoving()
    {
        _agent.speed = 0f;
    }

    public override void Rotate(float angle)
    {
        
    }
}
