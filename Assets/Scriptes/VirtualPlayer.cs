using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualPlayer : MonoBehaviour
{
    [SerializeField] Player _playerPawn;
    [SerializeField] InputController _controller;

    void Start()
    {
        _controller.SetPawn(_playerPawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
