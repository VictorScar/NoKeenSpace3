using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private Transform _tower;
    [SerializeField] private Transform _muzzle;

    [SerializeField] private float _checkAngle = 0.1f;

    private void Update()
    {
        if (_target == null) return;

        var vecToTarget = _target.position - _muzzle.position;
        var dirTo = vecToTarget.normalized;
        var distance = vecToTarget.sqrMagnitude;

        var angle = Vector3.Angle(_muzzle.transform.forward, dirTo);


        Debug.Log(angle);

        if (_muzzle.forward != dirTo)
        {
            var turn = Quaternion.LookRotation(dirTo, Vector3.up);
            var delta = new Quaternion(turn.x * Time.deltaTime, turn.y * Time.deltaTime, turn.z, turn.w);
            _tower.rotation = turn;
        }
        //if (Mathf.Abs(angle) > _checkAngle)
        //{
        //    _tower.rotation *= Quaternion.Euler(_tower.rotation.x -angle * Time.deltaTime, _tower.rotation.y - angle * Time.deltaTime, 0);
        //}
    }
}