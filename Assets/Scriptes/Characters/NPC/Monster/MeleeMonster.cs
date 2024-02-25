using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeMonster : Monster, IMeleeFighter
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
        //_combatController.Attacking();
        var weapon = _handsView.WeaponView;

        if (weapon == null)
        {
            return;
        }

        if (weapon.WeaponType != WeaponType.Melee)
        {
            foreach (var naturalWeapon in _monsterInventory.NaturalWeaponsPrefabs)
            {
                if (naturalWeapon.ItemView.WeaponType == WeaponType.Melee)
                {
                    _inventory.EquipItem(naturalWeapon);
                }
            }
        }
        else
        {
            _handsView.WeaponView.Fire();
            OnAttacking();
        }

        
    }
}
