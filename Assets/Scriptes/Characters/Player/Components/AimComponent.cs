using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimComponent : CharacterScanner, IAimComponent
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _defaultAimingRange = 100f;

    private Vector2 _screenPoint;
    private Vector3 _aimPoint;

    public Vector3 AimPoint { get => _aimPoint; }
    public Vector3 AimDirection { get => transform.forward; }

    public void Init()
    {
        _screenPoint = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        _aimPoint = _camera.ScreenToWorldPoint(_screenPoint);
    }

    public object ThrowBeam(float distance, out Vector3 impactPoint)
    {        
        var ray = _camera.ScreenPointToRay(_screenPoint);

        if (Physics.Raycast(ray, out RaycastHit hit, distance))
        {
            Debug.Log("DF");
            impactPoint = hit.point;
            return hit.collider.gameObject;
        }
        else
        {
            impactPoint = ray.origin + ray.direction * distance;
            return null;
        }
    }

}
