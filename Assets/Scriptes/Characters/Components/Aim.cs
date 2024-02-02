using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private Player _pawn;
    [SerializeField] private RectTransform _iconTransform;

    private CameraHolder _cameraHolder;
    private Camera _camera;
    private Transform _lockPoint;

    private void Start()
    {
        _cameraHolder = _pawn.CameraHolder;
        _lockPoint = _cameraHolder.LookPoint;
        _camera = _cameraHolder.LookCamera;
        //_cameraHolder.onRotated += AimSetPosition;
    }

    //private void AimSetPosition()
    //{
    //    var worldPos = _lockPoint.transform.position + _lockPoint.transform.forward * 5f;
    //    var aimScreenPos = _camera.WorldToScreenPoint(worldPos);

    //   // _iconTransform.anchoredPosition = new Vector2(aimScreenPos.x, aimScreenPos.y);
    //    _iconTransform.position = aimScreenPos;
    //    ;
    //}
}
