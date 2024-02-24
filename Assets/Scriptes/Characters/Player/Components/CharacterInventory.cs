using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    [SerializeField] private ItemInfo[] _startItems;
    [SerializeField] private int _inventorySize;

    [SerializeField] public ItemData EquipedItem;
    [SerializeField] public List<ItemData> _canEquipedItems = new List<ItemData>();

    [SerializeField] private InventoryCell[] _inventoryCells;

    private Character _owner;

    public InventoryCell[] InventoryCells { get => _inventoryCells; }

    public event Action onNewItemEqiuped;

    public void Init(Character owner)
    {
        _owner = owner;

        if (_inventoryCells == null)
        {
            _inventoryCells = new InventoryCell[_inventorySize];

            for (int i = 0; i < _inventorySize; i++)
            {
                _inventoryCells[i] = new InventoryCell();
            }
        }
           

        AddStartItems();

        EquipDefaultItem();
    }

    private void EquipDefaultItem()
    {
        if (_canEquipedItems.Count == 0)
        {
            return;
        }

        EquipItem(_canEquipedItems[0]);
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
                    AddToCanBeEquipedItem(itemData);
                    return true;
                }
            }
        }

        foreach (var cell in _inventoryCells)
        {
            if (cell.Info.Item == null)
            {
                cell.Info = itemInfo;
                AddToCanBeEquipedItem(itemData);
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

    public bool RemoveItem(int cellIndex, int count = -1)
    {
        if (cellIndex < 0 || cellIndex > _inventorySize - 1)
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
            _canEquipedItems.Remove(item);
        }
        else
        {
            cell.Info = new ItemInfo(item, cell.Info.Count - count);
        }

        return true;
    }

    public bool RemoveItem(ItemData itemData, int count = -1)
    {
        if (!HasItem(itemData, out int cellIndex))
        {
            return false;
        }

        return RemoveItem(cellIndex, count);
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
            EquipedItem = item;
            onNewItemEqiuped?.Invoke();
            return true;
        }

        return false;
    }

    public bool EquipItem(ItemData item)
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
