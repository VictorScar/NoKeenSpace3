using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanUseDistanceTools
{
    public IAimComponent AimingComponent { get; }

    public void UseEquipedTool();
}
