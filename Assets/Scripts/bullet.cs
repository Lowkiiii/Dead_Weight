using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletSpeed = 100;
    public float maxDistance = 20f;
    GameObject barrel;
    Rigidbody rb;

    void Start()
    {
        barrel = GameObject.FindGameObjectWithTag("barrel");

    }

    
    void Update()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Apply force in the forward direction only once upon instantiation
            rb.AddForce(barrel.transform.forward * bulletSpeed);
        }
        else
        {
            Debug.LogError("Rigidbody component not found on the bullet GameObject!");
        }

       
            float distanceTravelled = Vector3.Distance(barrel.transform.position, gameObject.transform.position);

            if (distanceTravelled > maxDistance)
            {
                Destroy(gameObject);
            }

        
    }
}
