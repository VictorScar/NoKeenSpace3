using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityModifier : MonoBehaviour
{
    [SerializeField] private float _gravity = 9.81f;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private CharacterMover _mover;

    public float Gravity { get => _gravity; }

    //void Start()
    //{
        
    //}

    
    //void Update()
    //{
    //    if (!_characterController.isGrounded)
    //    {
    //        _mover.GravityForce += _gravity * Time.deltaTime;
    //    }
    //    else
    //    {
    //        _mover.GravityForce = 0f;
    //    }
        
    //}
}
