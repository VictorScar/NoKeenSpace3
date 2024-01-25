using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShooter
{
    public IAimComponent AimingComponent { get; }

    public void Shoot();
}
