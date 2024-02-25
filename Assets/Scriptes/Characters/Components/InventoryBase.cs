using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryBase : MonoBehaviour
{
    protected Character _owner;

    [SerializeField] protected ItemData _equipedItem;
    [SerializeField] protected InventoryCell[] _inventoryCells;
    public ItemData EquipedItem { get => _equipedItem; }

    public event Action onNewItemEqiuped;
   
    public virtual void Init(Character owner)
    {
        _owner = owner;
    }

    public abstract bool EquipItem(ItemData item);

    public virtual bool RemoveItem(int cellIndex, int count = -1)
    {
        if (cellIndex < 0 || cellIndex > _inventoryCells.Length - 1)
        {
            return false;
        }

        var cell = _inventoryCells[cellIndex];
        var item = cell.Info.Item;

        if (item == null)
        {
            return false;
        }

        if (count == -1)
        {
            count = cell.Info.Count;
        }
        else if (count == -2)
        {
            count = (int)(cell.Info.Count * 0.5f);
        }

        if (count >= cell.Info.Count)
        {
            cell.Info = new ItemInfo();
        }
        else
        {
            cell.Info = new ItemInfo(item, cell.Info.Count - count);
        }

        return true;
    }

    protected void OnNewItemEqiuped()
    {
        onNewItemEqiuped?.Invoke();
    }
}
