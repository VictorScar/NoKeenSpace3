using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private GameMode[] _gameModes;

    private void Awake()
    {
        _gameModes = new GameMode[1];
        _gameModes[0] = new PlayMode();
    }

    private void Start()
    {
        _gameModes[0].Start();
    }
}
