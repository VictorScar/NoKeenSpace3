using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemView : MonoBehaviour
{
    protected ICanAiming _shooter;
    protected Character _owner;
    protected HandsView _hands;

    public ICanAiming AimingAgent { get => _shooter; }

    public void Init(ICanAiming aimAgent, HandsView hands)
    {
        _shooter = aimAgent;
        _hands = hands;
        _owner = aimAgent.Character;
    }

    //public abstract void Use();
}
