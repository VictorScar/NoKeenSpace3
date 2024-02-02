using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanShoot: ICanAiming
{
    public Weapon EquipedWeapon { get; }
    public bool Shoot();
}
