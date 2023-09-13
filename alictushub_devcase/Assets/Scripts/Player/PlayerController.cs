using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        float horizontalInput = _joystick.Horizontal;
        float verticalInput = _joystick.Vertical;

        Vector3 moveDirection = new Vector3(horizontalInput * _speed, _rigidbody.velocity.y, verticalInput * _speed);

        if (horizontalInput != 0 || verticalInput != 0)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
            SetIsRunning(true);
        }
        else
        {
            SetIsRunning(false);
        }

        _rigidbody.velocity = moveDirection;
    }

    private void SetIsRunning(bool isRunning)
    {
        _animator.SetBool("isRunning", isRunning);
    }
}
