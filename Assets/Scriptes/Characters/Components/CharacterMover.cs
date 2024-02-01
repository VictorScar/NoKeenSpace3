using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterMover : MonoBehaviour
{
    protected Character _pawn;

    protected Vector3 moveDirection;
    protected bool _isMoving;
    
    public float GravityForce;

    public bool IsMoving { get => _isMoving; }
    public Vector3 MoveDirection { get => moveDirection; }
   
    public virtual void Init(Character pawn)
    {
        _pawn = pawn;
    }
    
    public abstract void Jump();

    public abstract void StopMoving();
  
}
