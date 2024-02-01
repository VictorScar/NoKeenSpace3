using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_LookPoint : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 10f;
    [SerializeField] private float _minRequiredAngle = 0.1f;

    public bool LeanedTo(Vector3 dirTo)
    {
        var requiredAngle = Vector3.SignedAngle(transform.forward, dirTo, transform.right);


        var deltRotation = _rotateSpeed * Time.deltaTime;
                       
        if (Mathf.Abs(requiredAngle) > _minRequiredAngle)
        {
            transform.rotation *= Quaternion.Euler(requiredAngle * _rotateSpeed * Time.deltaTime, 0, 0);
            return false;
        }
        else
        {
            return true;
        }
    }
}
