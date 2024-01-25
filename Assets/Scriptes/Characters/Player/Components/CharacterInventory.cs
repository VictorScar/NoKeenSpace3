using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    [SerializeField] private Weapon _startWepon;
    [SerializeField] public IEquipped EquipedItem;

    private Weapon _equipedWeapon;
    private Tool _equipedTool;

    private Character _owner;

    public Weapon EquipedWeapon { get => _equipedWeapon; }
    public Tool EquipedTool { get => _equipedTool; }

    public void Init(Character owner)
    {
        _owner = owner;
        EquipItem(_startWepon);
    }

    public void EquipItem(IEquipped item)
    {
        if (item is Weapon weapon)
        {
            _equipedWeapon = weapon;
            _equipedTool = null;
            weapon.Equip(_owner);
        }
        else if (item is Tool tool)
        {
            _equipedTool = tool;
            _equipedWeapon = null;
            tool.Equip(_owner);
        }

    }
        
}
