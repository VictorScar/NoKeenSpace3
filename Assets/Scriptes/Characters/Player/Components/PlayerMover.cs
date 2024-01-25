using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMover : CharacterMover
{
    [SerializeField] private CharacterController _charController;
    [SerializeField] private GravityModifier _gravityModifier;

    [SerializeField] private float _jumpHeight = 1.5f;
    [SerializeField] private float _jumpForce = 10f;

    [SerializeField] private AnimationCurve _jumpSpeedCurve;

    private Vector3 _inputDirection;
    private Quaternion _deltaDirection;

    private bool _useGravity = true;
    private bool _isJumping = false;

    public override void Init(Character pawn)
    {
        base.Init(pawn);
        _pawn.onDied += DisableMover;
    }

    private void DisableMover()
    {
        _charController.enabled = false;
    }

    public override void Move(Vector2 dir, float moveSpeed)
    {
        if (dir == Vector2.zero)
        {
            _isMoving = false;
            _inputDirection = Vector3.zero;
            return;
        }

        _isMoving = true;

        _inputDirection = (transform.forward * dir.y + transform.right * dir.x) * moveSpeed;
        //_charController.Move(moveDirection - (transform.up* GravityForce) * moveSpeed * Time.deltaTime);
    }

    public override void MoveTo(Vector3 targetPos, float moveSpeed)
    {

    }

    public override void Jump()
    {
        if (_charController.isGrounded && !_isJumping)
        {
            var jumpPoint = transform.position + transform.up * _jumpHeight;
            StartCoroutine(Jumping(jumpPoint));
        }
    }

    private void Update()
    {
        if (!_charController.isGrounded && _useGravity)
        {
            GravityForce = _gravityModifier.Gravity;
        }
        else
        {
            GravityForce = 0;
        }

        _charController.Move((_inputDirection - (Vector3.up * GravityForce)) * Time.deltaTime);
        transform.rotation *= _deltaDirection;
    }

    private IEnumerator Jumping(Vector3 jumpPoint)
    {
        _useGravity = false;

        var jumpDir = (jumpPoint - transform.position).normalized;
        var jumpForce = _jumpForce;
        var difference = jumpPoint.y - transform.position.y;
        var beginDifference = difference;
        var jumpSpeed = 0f;

        while (difference > 0.01f)
        {
            difference = jumpPoint.y - transform.position.y;
            jumpSpeed = _jumpSpeedCurve.Evaluate(difference / beginDifference);
            Debug.Log(jumpSpeed.ToString());

            _charController.Move(jumpDir * jumpSpeed);
            yield return null;
        }

        _useGravity = true;
        _isJumping = false;

    }

    public override void Rotate(float angle)
    {
        _deltaDirection = Quaternion.AngleAxis(angle, transform.up);
    }

    private IEnumerator MoveToCoroutine(Vector3 targetPosition)
    {
        yield break;
    }

    public override void StopMoving()
    {
        throw new NotImplementedException();
    }

    private void OnDestroy()
    {
        if (_pawn != null)
        {
            _pawn.onDied -= DisableMover;
        }
    }
}
