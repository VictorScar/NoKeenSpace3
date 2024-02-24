using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [SerializeField] private PointOfView _pointOfView;
    [SerializeField] private float maxLookAngle = 85f;
    [SerializeField] private float minLookAngle = -85f;

    [SerializeField] float xRotation = 0f;

    public event Action onRotated;

    private void Start()
    {
        xRotation = transform.localRotation.x;
    }

    public void Incline(float angle)
    {
        angle = - angle;
        xRotation += angle;
        xRotation = Mathf.Clamp(xRotation, minLookAngle, maxLookAngle);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        onRotated?.Invoke();
    }
}
