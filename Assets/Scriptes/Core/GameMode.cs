using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameMode
{
    protected GameModeType _modeType;

    public GameModeType ModeType { get => _modeType; }

    public abstract void Start();
}
