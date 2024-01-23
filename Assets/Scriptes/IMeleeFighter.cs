using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMeleeFighter
{
    public float MeleeAttackDistance { get; set; }
    public float AttackPeriod { get; }
    public float MeleeDamage { get; }
    public CombatController MeleeFightController { get; }
    public void Attacking();
}
