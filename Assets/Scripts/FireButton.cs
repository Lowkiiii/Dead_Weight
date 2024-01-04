using UnityEngine;
using UnityEngine.EventSystems;

public class FireButton : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float maxDistance = 20f;

    private GameObject currentBullet;

    public void OnPointerDown(PointerEventData eventData)
    {
        FireBullet();
    }

    void FireBullet()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            currentBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(90, 0, 0));
        }
    }

    void DestroyBullet()
    {
        if (currentBullet != null)
        {
            Destroy(currentBullet);
        }
    }

    void Update()
    {
        if (currentBullet != null)
        {
            float distanceTravelled = Vector3.Distance(firePoint.position, currentBullet.transform.position);
            if (distanceTravelled >= maxDistance)
            {
                DestroyBullet();
            }
        }
    }
}
