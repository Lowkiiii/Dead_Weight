using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private PlayerController _player;
    public float DetectionRange;
    public float ChasingSpeed;
    public GameObject BloodPrefab;
    public SpriteRenderer sprite;
    public Sprite deathsprite;
    public Animator animator;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody component not found on the enemy GameObject!");
        }
    }

    void Update()
    {
        if (_player == null)
        {
            _player = FindObjectOfType<PlayerController>();
            return; // If player not found, continue searching
        }

        float distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);

        if (distanceToPlayer <= DetectionRange)
        {
            Vector3 direction = (_player.transform.position - transform.position).normalized;
            _rigidbody.velocity = direction * ChasingSpeed;

            // Rotate towards the player (optional)
            transform.LookAt(_player.transform);
        }
        else
        {
            // Player out of range, stop chasing
            _rigidbody.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            animator.enabled = false;
            sprite.sprite = deathsprite;
            ChasingSpeed = 0;
            DetectionRange = 0;
            Destroy(gameObject, 5f);
            Destroy(other.gameObject);
        }
    }

    public void Die()
    {
        Instantiate(BloodPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
