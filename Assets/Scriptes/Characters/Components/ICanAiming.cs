using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanAiming
{
    public IAimComponent AimingComponent { get; }
    public Character Character { get; }

}
