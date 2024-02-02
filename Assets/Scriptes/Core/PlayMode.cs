using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayMode : GameMode
{
    public PlayMode()
    {
        _modeType = GameModeType.Play;
    }

    public override void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
