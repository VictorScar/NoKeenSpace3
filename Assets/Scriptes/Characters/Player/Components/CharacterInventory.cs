using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    [SerializeField] private Weapon _startWepon;
    [SerializeField] public IDirectedTool EquipedItem;

    public void Init(ICanUseDistanceTools user)
    {
        EquipedItem = _startWepon;
        EquipedItem?.Init(user);
    }
}
