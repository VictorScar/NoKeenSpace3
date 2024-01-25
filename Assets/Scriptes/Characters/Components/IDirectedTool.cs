using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDirectedTool
{
    public ICanAiming AimingAgent { get; set; }
    public float ShootingDistance { get; }
        
 }


