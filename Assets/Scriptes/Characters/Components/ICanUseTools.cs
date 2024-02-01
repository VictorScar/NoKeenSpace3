using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanUseTools : ICanAiming
{
    //public  Weapon EquipedWeapon { get; }
    public  Tool EquipedTool { get; }
    public void UseEquipedTool();
}
