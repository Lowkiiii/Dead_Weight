using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _moveSpeed;

    private void FixedUpdate()
    {
        // Get the input direction with flipped values if needed
        Vector3 direction = new Vector3(-_joystick.Horizontal, 0f, -_joystick.Vertical).normalized;

        if (direction == Vector3.zero)
        {
            _animator.SetBool("isWalking", false);

        }
        else
        {
            _animator.SetBool("isWalking", true);
        }

        // Move the player
        _rigidbody.velocity = direction * _moveSpeed;


        if (direction != Vector3.zero)
        {
            // Rotate the player to face the movement direction
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.fixedDeltaTime * 10f);
        }
    }

} 