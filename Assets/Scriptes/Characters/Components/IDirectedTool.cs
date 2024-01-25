using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDirectedTool : IUsable
{
    public ICanUseDistanceTools Shooter { get; set; }
    public float ShootingDistance { get; }
    public bool IsEquiped { get; set; }

    public void Init(ICanUseDistanceTools shooter);
 }


