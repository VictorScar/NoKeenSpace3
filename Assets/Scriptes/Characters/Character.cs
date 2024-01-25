using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected float _health;
    [SerializeField] protected float _maxHealth;
    [SerializeField] protected float _baseSpeed;
    [SerializeField] protected float _sprintSpeed;

    [SerializeField] protected CharacterMover _mover;
    [SerializeField] protected CharacterScanner _scanner;
    [SerializeField] protected CharacterInventory _inventory;

    protected bool isAlive = true;

    protected float _moveSpeed;
    protected float Health { get => _health; }
    public bool IsAlive { get => isAlive; set => isAlive = value; }
    public abstract bool IsSprinting { get; set; }
    public CharacterInventory Inventory { get => _inventory; }

    public event Action onDied;

    //private void Start()
    //{
    //    Init();
    //}

    public virtual void Init()
    {
        _moveSpeed = _baseSpeed;
    }

    public virtual void Move(Vector2 dir)
    {
        _mover.Move(dir, _moveSpeed);
    }

    public abstract void Rotate(Vector2 inputDirection);

    public abstract void StopMove();

    public virtual void Jump()
    {
        _mover.Jump();
    }

    public virtual void GetDamage(float damage)
    {
        _health -= damage;
        _health = Mathf.Clamp(_health, 0f, 5000f);

        if (_health <= 0f)
        {
            Deth();
        }
    }

    public virtual void Deth()
    {
        onDied?.Invoke();
        IsAlive = false;
    }
}
