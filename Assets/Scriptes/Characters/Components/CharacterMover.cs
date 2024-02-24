using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterMover : MonoBehaviour
{
    protected Character _pawn;

    protected Vector3 _moveDirection;
    protected bool _isMoving;
    
    public float GravityForce;

    public bool IsMoving
    {
        get => _isMoving; 
        protected set
        {
            _isMoving = value;
            _pawn.OnMoving(value);
        }
    }
    public Vector3 MoveDirection { get => _moveDirection; }
   
    public virtual void Init(Character pawn)
    {
        _pawn = pawn;
    }
    
    public abstract void Jump();

    public abstract void StopMoving();
  
}
