using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] protected Animator _animator;
    protected int deathState = "Death".GetHashCode();
    private Character _pawn;

    public virtual void Init(Character pawn)
    {
        _pawn = pawn;

        _pawn.onDied += DeathAnimation;
    }

    public void DeathAnimation()
    {
        _animator.CrossFade("Death", 0.1f);
    }

    private void OnDestroy()
    {
        _pawn.onDied -= DeathAnimation;
    }
}
