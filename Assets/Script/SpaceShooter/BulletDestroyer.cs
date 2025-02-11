using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    public BulletPool bulletPool;
    public BulletPoo bulletPoo;
    private void Awake()
    {
        bulletPool = FindFirstObjectByType<BulletPool>();
        bulletPoo = FindFirstObjectByType<BulletPoo>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            bulletPool.ReturnBullet(collision.gameObject);
        }
        if (collision.CompareTag("EnemyBullet"))
        {
            bulletPoo.ReturnBullet(collision.gameObject);
        }
    }
}
