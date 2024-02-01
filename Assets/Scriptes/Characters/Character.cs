using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, ITakeDamage
{
    [SerializeField] protected float _health;
    [SerializeField] protected float _maxHealth;
    [SerializeField] protected float _baseSpeed;
    [SerializeField] protected float _sprintSpeed;

    [SerializeField] protected float _removeDeadBodyTime = 15f;

    [SerializeField] protected CharacterMover _mover;
    [SerializeField] protected CharacterScanner _scanner;
    [SerializeField] protected CharacterInventory _inventory;


    [SerializeField] protected bool isImmortal = false;

    protected bool isAlive = true;

    protected float _moveSpeed;
    protected float Health { get => _health; }
    public bool IsAlive { get => isAlive; set => isAlive = value; }
    public abstract bool IsSprinting { get; set; }
    public CharacterInventory Inventory { get => _inventory; }

    public float MoveSpeed { get => _moveSpeed; }
    public Vector3 MoveDirection { get => _mover.MoveDirection; }

    public event Action<bool> onMoving;
    public event Action onDied;



    public virtual void Init()
    {
        _moveSpeed = _baseSpeed;
        _mover.Init(this);
    }

    //public virtual void Move(Vector2 dir)
    //{
    //    _mover.Move(dir, _moveSpeed);
    //}

    //public abstract void Rotate(Vector2 inputDirection);

    public abstract void StopMove();

    public void OnMoving(bool isMoving)
    {
        onMoving?.Invoke(isMoving);
    }

    public virtual void Jump()
    {
        _mover.Jump();
    }



    public virtual void GetDamage(float damage, Character attacker)
    {
        if (isImmortal)
        {
            return;
        }

        _health -= damage;
        _health = Mathf.Clamp(_health, 0f, 5000f);

        if (_health <= 0f)
        {
            Deth();
        }
    }

    public virtual void Deth()
    {
        IsAlive = false;
        onDied?.Invoke();
        StartCoroutine(RemoveBody(_removeDeadBodyTime));
    }

    private IEnumerator RemoveBody(float timeToRemove)
    {
        yield return new WaitForSeconds(timeToRemove);
        Destroy(gameObject);
    }
}
