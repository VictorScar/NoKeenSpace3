using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanUseTools : ICanAiming
{   
    public  ToolView EquipedTool { get; }
    public void UseEquipedTool();
}
