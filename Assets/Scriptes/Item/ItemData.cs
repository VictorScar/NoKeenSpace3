using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="Items")]
public class ItemData : ScriptableObject
{
    [SerializeField] protected Image _icon;
    [SerializeField] protected string _itemName;
    [TextArea(0, 3)]
    [SerializeField] protected string _description;
    [SerializeField] protected bool _isCanBeEqipped;
    [SerializeField] private bool _isStackable;

    [SerializeField] private WeaponView _itemView;

    [SerializeField] private string _acion;

    protected int _id = 0;

    public int Id { get => _id; set => _id = value; }
    public Image Icon { get => _icon; set => _icon = value; }
    public string ItemName { get => _itemName; set => _itemName = value; }
    public string Description { get => _description; set => _description = value; }
    public bool IsCanBeEqipped { get => _isCanBeEqipped; set => _isCanBeEqipped = value; }
    public bool IsStackable { get => _isStackable; set => _isStackable = value; }
    public WeaponView ItemView { get => _itemView; }

    public void Use(Character owner)
    {
        
    }
       
}
