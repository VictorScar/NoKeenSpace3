using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item
{
    protected Image _icon;
    protected string _name;
    protected string _description;
    protected int _id;

    public Item(string name, string description, Image icon, int id)
    {
        _name = name;
        _description = description;
        _icon = icon;
        _id = id;
    }

    public int Id { get => _id; }

    public abstract void Use();
}
