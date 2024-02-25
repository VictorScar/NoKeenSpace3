using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Aiming : AimComponentBase
{
    [SerializeField] private Transform _aimPoint;

    public override Vector3 AimPoint => _aimPoint.position;

    public override Vector3 AimDirection => throw new System.NotImplementedException();

    public override void Init()
    {
        throw new System.NotImplementedException();
    }

    public override object ThrowBeam(float distance, out Vector3 impactPoint)
    {
        var aimPosition = _aimPoint.position;
        var ray = new Ray(aimPosition, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, distance))
        {
           // Debug.Log("DF");
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
