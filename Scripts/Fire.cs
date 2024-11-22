using UnityEngine;

public class FireScript : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint;
    public float bulletSpeed = 10f; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = transform.right * bulletSpeed; 
        }

        Destroy(bullet, 2f);
    }
}
