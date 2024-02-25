using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : NPC_Character
{
    protected MonsterInventory _monsterInventory;

    public override void Init()
    {
        base.Init();
        _monsterInventory = _inventory as MonsterInventory;
        _monsterInventory.Init(this);
    }
}
