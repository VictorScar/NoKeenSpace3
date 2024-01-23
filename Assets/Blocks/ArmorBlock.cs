using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBlock : Block
{
    [SerializeField] private float defenence = 10f;

    protected float Defenence { get => defenence; }
}
