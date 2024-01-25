using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    private IMeleeFighter _fighter;
    private NPC_Character _pawn;
    private Coroutine _attackCoroutine;

    public event Action onStrike;

    public void Init(IMeleeFighter fighter)
    {
        _fighter = fighter;
        _pawn = _fighter as NPC_Character;
    }

    public void Attacking()
    {
        if (_attackCoroutine == null)
        {
            _attackCoroutine = StartCoroutine(AttackingCoroutine());
        }
        
    }

    private IEnumerator AttackingCoroutine()
    {
        Strike();
        yield return new WaitForSeconds(_fighter.AttackPeriod);

        _attackCoroutine = null;
    }

    private void Strike()
    {
        if (_pawn != null)
        {
            _pawn.Target.GetDamage(_fighter.MeleeDamage, _pawn);
            onStrike?.Invoke();
            Debug.Log("Attacking!");
        }
    }
}
