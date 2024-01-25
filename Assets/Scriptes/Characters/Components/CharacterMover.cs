using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterMover : MonoBehaviour
{
    protected Character _pawn;

    protected bool _isMoving;
    public float GravityForce;

    public bool IsMoving { get => _isMoving; }

    public virtual void Init(Character pawn)
    {
        _pawn = pawn;
    }

    public abstract void Move(Vector2 dir, float moveSpeed);
    public abstract void MoveTo(Vector3 targetPos, float moveSpeed);
    public abstract void Rotate(float angle);
    public abstract void Jump();

    public abstract void StopMoving();
  
}
