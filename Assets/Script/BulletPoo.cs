using System.Collections.Generic;
using UnityEngine;

public class BulletPoo : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int initialPoolSize = 15;

    private Queue<GameObject> bulletPoo = new Queue<GameObject>();

    void Awake()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.SetActive(false);
            bulletPoo.Enqueue(bullet);
        }
    }

    // Get a damage number from the pool
    public GameObject GetBullet()
    {
        if (bulletPoo.Count > 0)
        {
            GameObject bullet = bulletPoo.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        else
        {
            // Expand the pool if needed
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            return bullet;
        }
    }

    // Return a damage number to the pool
    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPoo.Enqueue(bullet);
    }
}