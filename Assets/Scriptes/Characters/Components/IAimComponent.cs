using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAimComponent
{
    public Vector3 AimPoint { get; }
    public Vector3 AimDirection { get; }
    public void Init();
    public Vector3 ThrowBeam(float distance);
 
}
