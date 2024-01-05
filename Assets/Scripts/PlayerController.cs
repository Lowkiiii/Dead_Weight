using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public GameObject CharacterMesh;


    private void Start()
    {
        AudioClip.SetActive(false);
        ambianceSound.Play();
    }

    private void FixedUpdate()
    {

        Vector3 gyroInput = Input.gyro.userAcceleration;
        Vector3 gyroAimDirection = new Vector3(-gyroInput.x, 0f, -gyroInput.y).normalized;

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
            Quaternion lookRotation = Quaternion.LookRotation(firingdirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.fixedDeltaTime * 10f);

            if (currentBullet == null) 
            {
                FireBullet();
                pistolSound.Play();
                lastFireTime = Time.time; 
            }
        }
        if (gyroAimDirection != Vector3.zero)
        {
            Quaternion gyroLookRotation = Quaternion.LookRotation(gyroAimDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, gyroLookRotation, Time.fixedDeltaTime * 10f);

            if (currentBullet == null) 
            {
                FireBullet();
                pistolSound.Play();
                lastFireTime = Time.time; 
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "zombie")
        {
            CharacterMesh.SetActive(false);
            StartCoroutine(LoadLevelAfterDelay("GameOver", 1f));

        }
        else if(collision.gameObject.tag == "FinishLevel"){
            StartCoroutine(LoadLevelAfterDelay("Level Complete", 1f));
        }

    }
    private IEnumerator LoadLevelAfterDelay(string levelName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(levelName);
    }

    public void FireBullet()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            pistolSound.Play();
            AudioClip.SetActive(true);
            StartCoroutine(DeactivateAudioClipAfterDelay());

            currentBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(90, 0, 0));
        }
    }

    private IEnumerator DeactivateAudioClipAfterDelay()
    {
        yield return new WaitForSeconds(ClipLength);

        AudioClip.SetActive(false);
    }
} 