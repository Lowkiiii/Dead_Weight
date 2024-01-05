using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private FixedJoystick _fireJoystick;

    [SerializeField] private float _moveSpeed;

    [SerializeField] private AudioSource ambianceSound;
    [SerializeField] private AudioSource pistolSound;

    [SerializeField] private FireButton _fireButton;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float maxDistance = 20f;

    private GameObject currentBullet;

    private float lastFireTime; 
    public float fireRate = 5f;

    public float ClipLength = 1f;
    public GameObject AudioClip;


    private void Start()
    {
        AudioClip.SetActive(false);
        ambianceSound.Play();
    }

    private void FixedUpdate()
    {
        
        // Get the input direction with flipped values if needed
        Vector3 direction = new Vector3(-_joystick.Horizontal, 0f, -_joystick.Vertical).normalized;
        Vector3 firingdirection = new Vector3(-_fireJoystick.Horizontal, 0f, -_fireJoystick.Vertical).normalized;
        
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


        if (firingdirection != Vector3.zero)
        {
            
            // Rotate the player to face the movement direction
            Quaternion lookRotation = Quaternion.LookRotation(firingdirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.fixedDeltaTime * 10f);

            if (currentBullet == null) // Check if there's no bullet currently firing
            {
                FireBullet();
                pistolSound.Play();
                lastFireTime = Time.time; // Record the time of the latest bullet fired
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "zombie")
        {
            Destroy(gameObject, 0.5f);
        }
    }
    public void FireBullet()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // Play the firing sound
            pistolSound.Play();

            // Activate the AudioClip GameObject
            AudioClip.SetActive(true);
            StartCoroutine(DeactivateAudioClipAfterDelay());

            // Instantiate the bullet
            currentBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(90, 0, 0));
        }
    }

    private IEnumerator DeactivateAudioClipAfterDelay()
    {
        yield return new WaitForSeconds(ClipLength);

        // Deactivate the AudioClip GameObject after the specified duration
        AudioClip.SetActive(false);
    }
} 