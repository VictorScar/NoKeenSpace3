using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService : MonoBehaviour
{
    [SerializeField] private float _mouseSensity = 5f;
   

    //public event Action<Vector2> onMoveInput;
   // public event Action onJumpInput;
   // public event Action onUseItemInput;
   // public event Action onActionInput;

    //private void Update()
    //{
    //   // OnMoveInput();

    //}

    public Vector2 OnMoveInput()
    {
        var inputDirectionZ = 0f;
        var inputDirectionX = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            inputDirectionZ += 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputDirectionZ -= 1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputDirectionX += 1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputDirectionX -= 1f;
        }

        var inputDirection = new Vector2(inputDirectionX, inputDirectionZ);

        //onMoveInput?.Invoke(inputDirection);
        return inputDirection;
    }

    public Vector2 OnMouseMotion()
    {
        Vector2 mouseRotation = Vector2.zero;

        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");

        mouseRotation.x = mouseX * _mouseSensity;
        mouseRotation.y = mouseY * _mouseSensity;

        return mouseRotation;
    }

    public bool OnJumpInput()
    {
        return Input.GetKey(KeyCode.Space);
    }

    public bool OnSprintInput()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }

    public bool OnUseInput()
    {
        return Input.GetMouseButton(0);
    }

    public bool OnAlternativeMouseClick()
    {
        return Input.GetMouseButton(1);
    }
}
