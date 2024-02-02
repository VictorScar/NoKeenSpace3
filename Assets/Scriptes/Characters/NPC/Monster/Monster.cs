using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : NPC_Character, IMeleeFighter
{
    [SerializeField] private float _meleeDamage = 20f;
    [SerializeField] private float _attackDistance = 1f;
    [SerializeField] private float _attackPeriod = 1f;

    [SerializeField] private CombatController _combatController;

    public float MeleeAttackDistance { get => _attackDistance; set => _attackDistance = value; }
    public CombatController MeleeFightController { get => _combatController; }

    public float AttackPeriod => _attackPeriod;

    public float MeleeDamage => _meleeDamage;

    public override void Init()
    {
        base.Init();

        _combatController.Init(this);
    }

    public void Attacking()
    {
        _combatController.Attacking();
        OnAttacking();
    }
}
