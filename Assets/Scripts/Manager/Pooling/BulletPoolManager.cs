using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;

    public TurretBullet bulletPrefab;
    public int poolSize = 20;

    private Queue<TurretBullet> bulletPool = new Queue<TurretBullet>();

    void Awake()
    {
        Instance = this;

        for (int i = 0; i < poolSize; i++)
        {
            TurretBullet bullet = Instantiate(bulletPrefab);
            bullet.gameObject.SetActive(false);
            bulletPool.Enqueue(bullet);
            //prova
        }
    }

    public TurretBullet GetBullet()
    {
        if (bulletPool.Count > 0)
        {
            TurretBullet bullet = bulletPool.Dequeue();
            bullet.gameObject.SetActive(true);
            return bullet;
        }
        else
        {
            TurretBullet newBullet = Instantiate(bulletPrefab);
            return newBullet;
        }
    }

    public void ReturnBullet(TurretBullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}

