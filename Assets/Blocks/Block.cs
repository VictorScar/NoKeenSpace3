using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    [SerializeField] protected float _structuralStrength = 100f;
    [SerializeField] protected float _health = 100f;
    [SerializeField] protected string _blockName;
    [SerializeField] private ConnectPoint[] connects;

    public float StructuralStrength { get => _structuralStrength; }
    public float Health { get => _health; }
    public string BlockName { get => _blockName; set => _blockName = value; }
    protected ConnectPoint[] Connects { get => connects; }
}
