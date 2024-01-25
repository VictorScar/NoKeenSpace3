using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanShoot: ICanAiming
{
    public bool Shoot();
}
