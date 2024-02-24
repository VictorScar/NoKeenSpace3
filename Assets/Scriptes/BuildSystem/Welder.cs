using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Welder : Tool
{
    [SerializeField] private float _actionDistance = 1f;

    public Welder(string name, string description, Image icon, int id) : base(name, description, icon, id)
    {
    }

    public override ICanAiming AimingAgent { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public override float ShootingDistance => _actionDistance;

    public override void Equip(Character owner)
    {
        throw new System.NotImplementedException();
    }

    public override void Use()
    {
        
    }
}
