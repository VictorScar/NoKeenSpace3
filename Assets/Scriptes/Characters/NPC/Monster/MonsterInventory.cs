using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInventory : InventoryBase
{
    [SerializeField] private ItemData[] _naturalWeapon;

    public ItemData[] NaturalWeaponsPrefabs { get => _naturalWeapon; }

    public override bool EquipItem(ItemData item)
    {
        if (_naturalWeapon != null && _naturalWeapon.Length > 0)
        {
            _equipedItem = item;
            OnNewItemEqiuped();
            return true;
        }

        return false;

    }



    public override void Init(Character owner)
    {
        base.Init(owner);

        if (_naturalWeapon != null && _naturalWeapon.Length > 0)
        {
            EquipItem(_naturalWeapon[0]);
        }
       
        // _equipedItem = _naturalWeapon[0];
    }
}
