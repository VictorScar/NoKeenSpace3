
using System;
using UnityEngine.UI;

public abstract class Tool : Item, IUsable, IEquipped, IDirectedTool
{
    protected Tool(string name, string description, Image icon, int id) : base(name, description, icon, id)
    {
    }

    public abstract ICanAiming AimingAgent { get; set; }
    public abstract float ShootingDistance { get; }

    public abstract void Equip(Character owner);

    public void OnRemove()
    {
        throw new NotImplementedException();
    }
}