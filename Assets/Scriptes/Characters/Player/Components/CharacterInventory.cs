using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterInventory : InventoryBase
{
    [SerializeField] private ItemInfo[] _startItems;
    [SerializeField] private int _inventorySize;
       
    [SerializeField] public List<ItemData> _canEquipedItems = new List<ItemData>();

   
    
    public InventoryCell[] InventoryCells { get => _inventoryCells; }

   

    public override void Init(Character owner)
    {
        base.Init(owner);

        if (_inventoryCells == null)
        {
            _inventoryCells = new InventoryCell[_inventorySize];

            for (int i = 0; i < _inventorySize; i++)
            {
                _inventoryCells[i] = new InventoryCell();
            }
        }

        UpdataCanBeEquipedItems();

        AddStartItems();

        EquipDefaultItem();
    }

    private void UpdataCanBeEquipedItems()
    {
        _canEquipedItems.Clear();

        for (int i = 0; i < _inventoryCells.Length; i++)
        {
            var cell = _inventoryCells[i];

            var item = cell.Info.Item;

            if (item != null && item.IsCanBeEqipped)
            {
                _canEquipedItems.Add(item);
            }      
        }
    }

    private void AddStartItems()
    {
        if (_startItems == null)
        {
            return;
        }

        foreach (var iteminfo in _startItems)
        {
            AddItem(iteminfo);
        }
    }

    public bool AddItem(ItemInfo itemInfo)
    {
        var itemData = itemInfo.Item;

        if (itemData == null)
        {
            return false;
        }

        if (itemData.IsStackable)
        {
            foreach (var cell in _inventoryCells)
            {
                if (cell.Info.Item == itemData)
                {
                    var totalCount = cell.Info.Count + itemInfo.Count;
                    cell.Info = new ItemInfo(itemData, totalCount);
                    UpdataCanBeEquipedItems();
                    return true;
                }
            }
        }

        foreach (var cell in _inventoryCells)
        {
            if (cell.Info.Item == null)
            {
                cell.Info = itemInfo;
                UpdataCanBeEquipedItems();
                return true;
            }
        }

        return false;

    }

    public bool AddItem(ItemData itemData, int count)
    {
        var itemInfo = new ItemInfo(itemData, count);
        return AddItem(itemInfo);
    }

    public override bool RemoveItem(int cellIndex, int count = -1)
    {
        var canRemove = base.RemoveItem(cellIndex, count);

        if (canRemove)
        {
            UpdataCanBeEquipedItems();
        }

        return canRemove;


    }


    public bool RemoveItem(ItemData itemData, int count = -1)
    {
        if (!HasItem(itemData, out int cellIndex))
        {
            return false;
        }

        return RemoveItem(cellIndex, count);
    }

    private void EquipDefaultItem()
    {
        if (_canEquipedItems.Count == 0)
        {
            return;
        }

        EquipItem(_canEquipedItems[0]);
    }

    public bool EquipItem(int cellIndex)
    {
        if (cellIndex < 0 || cellIndex > _inventorySize - 1)
        {
            return false;
        }

        var item = _inventoryCells[cellIndex].Info.Item;

        if (item.IsCanBeEqipped)
        {
            _equipedItem = item;
            OnNewItemEqiuped();
            return true;
        }

        return false;
    }

    public override bool EquipItem(ItemData item)
    {
        if (HasItem(item, out var cellIndex))
        {
            return EquipItem(cellIndex);
        }

        return false;
    }

    private bool HasItem(ItemData itemData, out int cellIndex)
    {
        for (int i = 0; i < _inventoryCells.Length; i++)
        {
            var item = _inventoryCells[i].Info.Item;

            if (item == itemData)
            {
                cellIndex = i;
                return true;
            }
        }
        cellIndex = -1;
        return false;
    }

    private void AddToCanBeEquipedItem(ItemData itemData)
    {
        if (itemData.IsCanBeEqipped)
        {
            _canEquipedItems.Add(itemData);
        }
    }
}

[Serializable]
public struct ItemInfo
{
    public ItemData Item;
    public int Count;

    public ItemInfo(ItemData item, int count)
    {
        Item = item;
        Count = count;
    }
}

[Serializable]
public class InventoryCell
{
    public ItemInfo Info;
}

[Serializable]
public struct StartItemsInfo
{
    public ItemData ItemData;
    public int Count;
}
