using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStorage : MonoBehaviour
{
    [SerializeField] private List<ItemData> _items;

    public List<ItemData> Items { get => _items; }

    public static ItemStorage Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }   
        
        if (_items != null)
        {
            for (int i = 0; i < _items.Count; i++) 
            {               
                _items[i].Id = i;
            }
        }
    }

    public ItemData GetItemByID(int id)
    {
        foreach (ItemData item in _items)
        {
            if (item.Id == id)
            {
                return item;
            }
        }

        return null;
    }

    public int GetIDByItem(ItemData itemData)
    {
        foreach (ItemData item in _items)
        {
            if (item == itemData)
            {
                return item.Id;
            }
        }

        return -1;
    }
}
