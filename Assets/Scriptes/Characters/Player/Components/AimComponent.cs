using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimComponent : AimComponentBase
{
    [SerializeField] private Camera _camera;
   
    private Vector2 _screenPoint;
    private Vector3 _aimPoint;
    

    public override Vector3 AimPoint { get => _aimPoint; }
    public override Vector3 AimDirection { get => transform.forward; }

    public override void Init()
    {
        _screenPoint = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        _aimPoint = _camera.ScreenToWorldPoint(_screenPoint);
    }

    public override  object ThrowBeam(float distance, out Vector3 hitPoint)
    {
        _screenPoint = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        _aimPoint = _camera.ScreenToWorldPoint(_screenPoint);
        //var ray = _camera.ScreenPointToRay(_screenPoint);
        var ray = new Ray(_aimPoint, _camera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, distance))
        {
            //Debug.DrawLine(_aimPoint, _aimPoint + _camera.transform.forward * distance, Color.red, 5f);
            hitPoint = hit.point;
            return hit.collider.gameObject;
        }
        else
        {
            hitPoint = ray.origin + ray.direction * distance;
            return null;
        }
    }

}
