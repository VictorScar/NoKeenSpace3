using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : NPC_Character
{
    [SerializeField] private MonsterInventory _monsterInventory;
    [SerializeField] protected MonstrHandsView _handsView;

    public override void Init()
    {
        base.Init();
        _monsterInventory = _inventory as MonsterInventory;
        _handsView.Init(this);
    }
}
