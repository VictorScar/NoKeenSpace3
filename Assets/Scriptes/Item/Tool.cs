
using System;

public abstract class Tool : Item, IUsable, IEquipped, IDirectedTool
{
    public abstract ICanAiming AimingAgent { get; set; }
    public abstract float ShootingDistance { get; }

    public abstract void Equip(Character owner);
    public abstract void Use();
}