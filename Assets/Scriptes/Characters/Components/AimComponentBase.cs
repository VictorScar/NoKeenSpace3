using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AimComponentBase : MonoBehaviour, IAimComponent
{
    public abstract Vector3 AimPoint { get; }
    public abstract Vector3 AimDirection { get; }

    public abstract void Init();
    public abstract object ThrowBeam(float distance, out Vector3 impactPoint);
}
